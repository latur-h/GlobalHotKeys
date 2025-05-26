using GlobalHotKeys.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys.Core
{
    internal class HotkeyCombinationComparer : IEqualityComparer<HotkeyCombination>
    {
        public bool Equals(HotkeyCombination x, HotkeyCombination y) => x.IgnoreKeys == y.IgnoreKeys && x.Keys.SetEquals(y.Keys);
        
        public int GetHashCode(HotkeyCombination obj)
        {
            int hash = 17;

            foreach (var key in obj.Keys)
                hash = hash * 31 + key.GetHashCode();

            hash = hash * 31 + obj.IgnoreKeys.GetHashCode();

            return hash;
        }
    }
}
