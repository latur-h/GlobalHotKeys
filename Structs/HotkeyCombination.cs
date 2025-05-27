using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys.Structs
{
    /// <summary>
    /// Represents a hotkey combination made up of one or more keys.
    /// Can optionally ignore all key matching if desired.
    /// </summary>
    public readonly struct HotkeyCombination
    {
        /// <summary>
        /// The set of keys that make up the hotkey combination.
        /// </summary>
        public HashSet<KeyCode> Keys { get; }
        /// <summary>
        /// If true, the combination will match any input set regardless of actual keys.
        /// Useful for wildcard behavior or temporary overrides.
        /// </summary>
        public bool IgnoreKeys { get; }

        /// <summary>
        /// Constructs a new <see cref="HotkeyCombination"/> with optional ignore behavior.
        /// </summary>
        /// <param name="ignoreKeys">If true, ignores key matching entirely.</param>
        /// <param name="keys">The keys that make up the combination.</param>
        public HotkeyCombination(bool ignoreKeys = false, params KeyCode[] keys)
        {
            Keys = new HashSet<KeyCode>(keys);
            IgnoreKeys = ignoreKeys;
        }
        /// <summary>
        /// Checks whether the combination matches a given set of currently pressed inputs.
        /// </summary>
        /// <param name="pressed">The set of currently pressed <see cref="KeyCode"/> values.</param>
        /// <returns>True if the combination matches; otherwise, false.</returns>
        public bool Matches(HashSet<KeyCode> pressed)
        {
            return IgnoreKeys || Keys.IsSubsetOf(pressed);
        }
    }
}
