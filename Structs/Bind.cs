using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys.Structs
{
    /// <summary>
    /// Represents a hotkey binding identified by a string ID and a key combination.
    /// Used to simplify registration and management of hotkeys.
    /// </summary>
    public readonly struct Bind
    {
        /// <summary>
        /// The unique identifier for this binding.
        /// Used for registration, change, and unregistration operations.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// The key combination associated with this bind.
        /// </summary>
        public HotkeyCombination Combination { get; }

        /// <summary>
        /// 
        /// </summary>
        public Func<Task> Action { get; }

        /// <summary>
        /// Constructs a new <see cref="Bind"/> with a unique ID and key combination.
        /// </summary>
        /// <param name="id">The unique identifier for the hotkey binding.</param>
        /// <param name="action">Action to execute on hotkey.</param>
        /// <param name="keys">The key combination to bind to the ID.</param>
        public Bind(string id, Func<Task> action, params KeyCode[] keys)
        {
            Id = id;
            Action = action;
            Combination = new HotkeyCombination(false, keys);
        }
    }
}
