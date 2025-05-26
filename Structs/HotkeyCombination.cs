using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys.Structs
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
}
