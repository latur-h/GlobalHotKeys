using GlobalHotKeys.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GlobalHotKeys.Core
{
    internal class HotkeyRegistry
    {
        private readonly Dictionary<string, HotkeyCombination> _bindings = new Dictionary<string, HotkeyCombination>();
        private readonly Dictionary<HotkeyCombination, Dictionary<string, Bind>> _actions = new Dictionary<HotkeyCombination, Dictionary<string, Bind>>(new HotkeyCombinationComparer());

        public void Register(Bind bind)
        {
            if (_bindings.ContainsKey(bind.Id))
            {
                var comparer = new HotkeyCombinationComparer();

                if (!comparer.Equals(_bindings[bind.Id], bind.Combination))
                {
                    _actions[_bindings[bind.Id]].Remove(bind.Id);

                    if (_actions[_bindings[bind.Id]].Count == 0)
                        _actions.Remove(_bindings[bind.Id]);
                }
            }

            _bindings[bind.Id] = bind.Combination;

            if (!_actions.TryGetValue(bind.Combination, out var actionDict))
            {
                actionDict = new Dictionary<string, Bind>();
                _actions[bind.Combination] = actionDict;
            }

            _actions[_bindings[bind.Id]][bind.Id] = bind;
        }
        public void Register(string id, HotkeyCombination combo, Func<Task> action)
        {
            var bind = new Bind(id, action, combo.Keys.ToArray());
            Register(bind);
        }

        public void Unregister(string id)
        {
            if (_bindings.TryGetValue(id, out var combo))
            {
                _actions[_bindings[id]].Remove(id);

                if (_actions[_bindings[id]].Count == 0)
                    _actions.Remove(_bindings[id]);
            }

            _bindings.Remove(id);
        }
        public void Unregister(Bind bind) => Unregister(bind.Id);

        public void Change(string id, HotkeyCombination newCombo)
        {
            if (_bindings.TryGetValue(id, out var oldCombo))
            {
                _bindings.Remove(id);

                if (_actions[oldCombo].TryGetValue(id, out var bind))
                {
                    _actions[oldCombo].Remove(id);

                    if (_actions[oldCombo].Count == 0)
                        _actions.Remove(oldCombo);

                    var newBind = new Bind(id, bind.Action, newCombo.Keys.ToArray());

                    Register(newBind);
                }
            }
        }
        public void Change(string id, Func<Task> action)
        {
            if (_bindings.TryGetValue(id, out var oldCombo))
            {
                _bindings.Remove(id);

                if (_actions[oldCombo].TryGetValue(id, out var bind))
                {
                    _actions[oldCombo].Remove(id);

                    if (_actions[oldCombo].Count == 0)
                        _actions.Remove(oldCombo);

                    var newBind = new Bind(id, action, bind.Combination.Keys.ToArray());

                    Register(newBind);
                }
            }
        }

        public void Change(Bind bind)
        {
            if (_bindings.TryGetValue(bind.Id, out var oldCombo))
            {
                _bindings.Remove(bind.Id);

                if (_actions[oldCombo].TryGetValue(bind.Id, out var _bind))
                {
                    _actions[oldCombo].Remove(_bind.Id);

                    if (_actions[oldCombo].Count == 0)
                        _actions.Remove(oldCombo);

                    Register(bind);
                }
            }
        }

        public bool TryGetAction(HashSet<KeyCode> pressedInputs, out IEnumerable<Bind>? actions)
        {
            var result = new List<Bind>();

            foreach (var pair in _actions)
            {
                if (pair.Key.Matches(pressedInputs))
                {
                    result.AddRange(pair.Value.Values);
                }
            }

            if (result.Count > 0)
            {
                actions = result;
                return true;
            }

            actions = null;
            return false;
        }

        public void Clear()
        {
            _bindings.Clear();
            _actions.Clear();
        }
    }
}
