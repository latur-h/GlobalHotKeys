using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys
{
    public readonly struct HotkeyCombination
    {
        public HashSet<KeyCode> Keys { get; }
        public bool IgnoreKeys { get; }

        public HotkeyCombination(bool ignoreKeys = false, params KeyCode[] keys)
        {
            Keys = new HashSet<KeyCode>(keys);
            IgnoreKeys = ignoreKeys;
        }

        public bool Matches(HashSet<KeyCode> pressed)
        {
            return IgnoreKeys || Keys.IsSubsetOf(pressed);
        }
    }
    public readonly struct Bind
    {
        public string Id { get; }
        public HotkeyCombination Combination { get; }

        public Bind(string id, params KeyCode[] keys)
        {
            Id = id;
            Combination = new HotkeyCombination(false, keys);
        }
    }
}
