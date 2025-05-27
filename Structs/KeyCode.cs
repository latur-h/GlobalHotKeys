using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalHotKeys.Structs
{
    /// <summary>
    /// Represents virtual key codes used for keyboard and mouse input.
    /// Combines standard alphanumeric keys, function keys, modifiers, symbols, navigation, numpad, and mouse buttons.
    /// Compatible with Win32 virtual key codes.
    /// </summary>
    public enum KeyCode : ushort
    {
        // Letters
        /// <summary>Key A</summary>
        A = 0x41,
        /// <summary>Key B</summary>
        B = 0x42,
        /// <summary>Key C</summary>
        C = 0x43,
        /// <summary>Key D</summary>
        D = 0x44,
        /// <summary>Key E</summary>
        E = 0x45,
        /// <summary>Key F</summary>
        F = 0x46,
        /// <summary>Key G</summary>
        G = 0x47,
        /// <summary>Key H</summary>
        H = 0x48,
        /// <summary>Key I</summary>
        I = 0x49,
        /// <summary>Key J</summary>
        J = 0x4A,
        /// <summary>Key K</summary>
        K = 0x4B,
        /// <summary>Key L</summary>
        L = 0x4C,
        /// <summary>Key M</summary>
        M = 0x4D,
        /// <summary>Key N</summary>
        N = 0x4E,
        /// <summary>Key O</summary>
        O = 0x4F,
        /// <summary>Key P</summary>
        P = 0x50,
        /// <summary>Key Q</summary>
        Q = 0x51,
        /// <summary>Key R</summary>
        R = 0x52,
        /// <summary>Key S</summary>
        S = 0x53,
        /// <summary>Key T</summary>
        T = 0x54,
        /// <summary>Key U</summary>
        U = 0x55,
        /// <summary>Key V</summary>
        V = 0x56,
        /// <summary>Key W</summary>
        W = 0x57,
        /// <summary>Key X</summary>
        X = 0x58,
        /// <summary>Key Y</summary>
        Y = 0x59,
        /// <summary>Key Z</summary>
        Z = 0x5A,

        // Numbers (Top Row)
        /// <summary>Number key 0 (top row)</summary>
        D0 = 0x30,
        /// <summary>Number key 1</summary>
        D1 = 0x31,
        /// <summary>Number key 2</summary>
        D2 = 0x32,
        /// <summary>Number key 3</summary>
        D3 = 0x33,
        /// <summary>Number key 4</summary>
        D4 = 0x34,
        /// <summary>Number key 5</summary>
        D5 = 0x35,
        /// <summary>Number key 6</summary>
        D6 = 0x36,
        /// <summary>Number key 7</summary>
        D7 = 0x37,
        /// <summary>Number key 8</summary>
        D8 = 0x38,
        /// <summary>Number key 9</summary>
        D9 = 0x39,

        // Function Keys
        /// <summary>Function key F1</summary>
        F1 = 0x70,
        /// <summary>Function key F2</summary>
        F2 = 0x71,
        /// <summary>Function key F3</summary>
        F3 = 0x72,
        /// <summary>Function key F4</summary>
        F4 = 0x73,
        /// <summary>Function key F5</summary>
        F5 = 0x74,
        /// <summary>Function key F6</summary>
        F6 = 0x75,
        /// <summary>Function key F7</summary>
        F7 = 0x76,
        /// <summary>Function key F8</summary>
        F8 = 0x77,
        /// <summary>Function key F9</summary>
        F9 = 0x78,
        /// <summary>Function key F10</summary>
        F10 = 0x79,
        /// <summary>Function key F11</summary>
        F11 = 0x7A,
        /// <summary>Function key F12</summary>
        F12 = 0x7B,

        // Modifier Keys
        /// <summary>Generic Shift key</summary>
        Shift = 0x10,
        /// <summary>Generic Control key</summary>
        Control = 0x11,
        /// <summary>Generic Alt key</summary>
        Alt = 0x12,
        /// <summary>Left Shift</summary>
        LShift = 0xA0,
        /// <summary>Right Shift</summary>
        RShift = 0xA1,
        /// <summary>Left Control</summary>
        LControl = 0xA2,
        /// <summary>Right Control</summary>
        RControl = 0xA3,
        /// <summary>Left Alt</summary>
        LAlt = 0xA4,
        /// <summary>Right Alt</summary>
        RAlt = 0xA5,

        // Navigation Keys
        /// <summary>Tab key</summary>
        Tab = 0x09,
        /// <summary>Enter key</summary>
        Enter = 0x0D,
        /// <summary>Escape key</summary>
        Escape = 0x1B,
        /// <summary>Spacebar</summary>
        Space = 0x20,
        /// <summary>Backspace</summary>
        Backspace = 0x08,
        /// <summary>Insert key</summary>
        Insert = 0x2D,
        /// <summary>Delete key</summary>
        Delete = 0x2E,
        /// <summary>Home key</summary>
        Home = 0x24,
        /// <summary>End key</summary>
        End = 0x23,
        /// <summary>Page Up key</summary>
        PageUp = 0x21,
        /// <summary>Page Down key</summary>
        PageDown = 0x22,
        /// <summary>Arrow Left key</summary>
        ArrowLeft = 0x25,
        /// <summary>Arrow Up key</summary>
        ArrowUp = 0x26,
        /// <summary>Arrow Right key</summary>
        ArrowRight = 0x27,
        /// <summary>Arrow Down key</summary>
        ArrowDown = 0x28,

        // Numpad
        /// <summary>Numpad 0</summary>
        NumPad0 = 0x60,
        /// <summary>Numpad 1</summary>
        NumPad1 = 0x61,
        /// <summary>Numpad 2</summary>
        NumPad2 = 0x62,
        /// <summary>Numpad 3</summary>
        NumPad3 = 0x63,
        /// <summary>Numpad 4</summary>
        NumPad4 = 0x64,
        /// <summary>Numpad 5</summary>
        NumPad5 = 0x65,
        /// <summary>Numpad 6</summary>
        NumPad6 = 0x66,
        /// <summary>Numpad 7</summary>
        NumPad7 = 0x67,
        /// <summary>Numpad 8</summary>
        NumPad8 = 0x68,
        /// <summary>Numpad 9</summary>
        NumPad9 = 0x69,
        /// <summary>Numpad Multiply</summary>
        NumPadMultiply = 0x6A,
        /// <summary>Numpad Add</summary>
        NumPadAdd = 0x6B,
        /// <summary>Numpad Subtract</summary>
        NumPadSubtract = 0x6D,
        /// <summary>Numpad Decimal</summary>
        NumPadDecimal = 0x6E,
        /// <summary>Numpad Divide</summary>
        NumPadDivide = 0x6F,

        // Symbols
        /// <summary>Semicolon key (;)</summary>
        Semicolon = 0xBA,
        /// <summary>Equal key (=)</summary>
        Equal = 0xBB,
        /// <summary>Comma key (,)</summary>
        Comma = 0xBC,
        /// <summary>Minus key (-)</summary>
        Minus = 0xBD,
        /// <summary>Period key (.)</summary>
        Period = 0xBE,
        /// <summary>Slash key (/)</summary>
        Slash = 0xBF,
        /// <summary>Backtick key (`)</summary>
        Backtick = 0xC0,
        /// <summary>Open bracket key ([)</summary>
        OpenBracket = 0xDB,
        /// <summary>Backslash key (\\)</summary>
        Backslash = 0xDC,
        /// <summary>Close bracket key (])</summary>
        CloseBracket = 0xDD,
        /// <summary>Quote key (')</summary>
        Quote = 0xDE,

        // Mouse buttons
        /// <summary>Left mouse button</summary>
        LButton = 0x01,
        /// <summary>Right mouse button</summary>
        RButton = 0x02,
        /// <summary>Middle mouse button</summary>
        MButton = 0x04,
        /// <summary>Extra mouse button 1</summary>
        XButton1 = 0x05,
        /// <summary>Extra mouse button 2</summary>
        XButton2 = 0x06,
    }
}
