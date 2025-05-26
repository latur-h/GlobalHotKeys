using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys
{
    internal class HotkeyRegistry
    {
        private readonly Dictionary<string, HotkeyCombination> _bindings = new();
        private readonly Dictionary<HotkeyCombination, Func<Task>> _actions = new(new HotkeyCombinationComparer());

        public void Register(string id, HotkeyCombination combo, Func<Task> action)
        {
            if (_bindings.ContainsKey(id))
            {
                var oldCombo = _bindings[id];
                _actions.Remove(oldCombo);
            }

            _bindings[id] = combo;
            _actions[combo] = action;
        }
        public void Register(Bind bind, Func<Task> action) => Register(bind.Id, bind.Combination, action);        

        public void Unregister(string id)
        {
            if (_bindings.TryGetValue(id, out var combo))
            {
                _bindings.Remove(id);
                _actions.Remove(combo);
            }
        }
        public void Unregister(Bind bind) => Unregister(bind.Id);

        public void Change(string id, HotkeyCombination newCombo)
        {
            if (_bindings.TryGetValue(id, out var oldCombo) && _actions.TryGetValue(oldCombo, out var action))
            {
                _bindings[id] = newCombo;
                _actions.Remove(oldCombo);
                _actions[newCombo] = action;
            }
        }
        public void Change(Bind bind, HotkeyCombination newCombo) => Change(bind.Id, newCombo);

        public bool TryGetAction(HashSet<KeyCode> pressedInputs, out Func<Task>? action)
        {
            foreach (var pair in _actions)
            {
                if (pair.Key.Matches(pressedInputs))
                {
                    action = pair.Value;
                    return true;
                }
            }

            action = null;
            return false;
        }

        public void Clear()
        {
            _bindings.Clear();
            _actions.Clear();
        }
    }
}
