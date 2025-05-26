using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys.Structs
{
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
