using GlobalHotKeys.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys.Core
{
    internal class ActiveCombination
    {
        public HashSet<KeyCode> PressedInputs { get; }

        public bool IsExecuting { get; set; }
        public bool IsFinished { get; set; }
        public bool IsReleased { get; set; }

        public ActiveCombination(HashSet<KeyCode> pressedInputs)
        {
            PressedInputs = new HashSet<KeyCode>(pressedInputs);
            IsExecuting = true;
            IsFinished = false;
            IsReleased = false;
        }
    }
}
