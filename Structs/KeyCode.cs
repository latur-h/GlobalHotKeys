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
        /// <summary>Key A Up</summary>
        AUp = 0x1041,
        /// <summary>Key B</summary>
        B = 0x42,
        /// <summary>Key B Up</summary>
        BUp = 0x1042,
        /// <summary>Key C</summary>
        C = 0x43,
        /// <summary>Key C Up</summary>
        CUp = 0x1043,
        /// <summary>Key D</summary>
        D = 0x44,
        /// <summary>Key D Up</summary>
        DUp = 0x1044,
        /// <summary>Key E</summary>
        E = 0x45,
        /// <summary>Key E Up</summary>
        EUp = 0x1045,
        /// <summary>Key F</summary>
        F = 0x46,
        /// <summary>Key F Up</summary>
        FUp = 0x1046,
        /// <summary>Key G</summary>
        G = 0x47,
        /// <summary>Key G Up</summary>
        GUp = 0x1047,
        /// <summary>Key H</summary>
        H = 0x48,
        /// <summary>Key H Up</summary>
        HUp = 0x1048,
        /// <summary>Key I</summary>
        I = 0x49,
        /// <summary>Key I Up</summary>
        IUp = 0x1049,
        /// <summary>Key J</summary>
        J = 0x4A,
        /// <summary>Key J Up</summary>
        JUp = 0x104A,
        /// <summary>Key K</summary>
        K = 0x4B,
        /// <summary>Key K Up</summary>
        KUp = 0x104B,
        /// <summary>Key L</summary>
        L = 0x4C,
        /// <summary>Key L Up</summary>
        LUp = 0x104C,
        /// <summary>Key M</summary>
        M = 0x4D,
        /// <summary>Key M Up</summary>
        MUp = 0x104D,
        /// <summary>Key N</summary>
        N = 0x4E,
        /// <summary>Key N Up</summary>
        NUp = 0x104E,
        /// <summary>Key O</summary>
        O = 0x4F,
        /// <summary>Key O Up</summary>
        OUp = 0x104F,
        /// <summary>Key P</summary>
        P = 0x50,
        /// <summary>Key P Up</summary>
        PUp = 0x1050,
        /// <summary>Key Q</summary>
        Q = 0x51,
        /// <summary>Key Q Up</summary>
        QUp = 0x1051,
        /// <summary>Key R</summary>
        R = 0x52,
        /// <summary>Key R Up</summary>
        RUp = 0x1052,
        /// <summary>Key S</summary>
        S = 0x53,
        /// <summary>Key S Up</summary>
        SUp = 0x1053,
        /// <summary>Key T</summary>
        T = 0x54,
        /// <summary>Key T Up</summary>
        TUp = 0x1054,
        /// <summary>Key U</summary>
        U = 0x55,
        /// <summary>Key U Up</summary>
        UUp = 0x1055,
        /// <summary>Key V</summary>
        V = 0x56,
        /// <summary>Key V Up</summary>
        VUp = 0x1056,
        /// <summary>Key W</summary>
        W = 0x57,
        /// <summary>Key W Up</summary>
        WUp = 0x1057,
        /// <summary>Key X</summary>
        X = 0x58,
        /// <summary>Key X Up</summary>
        XUp = 0x1058,
        /// <summary>Key Y</summary>
        Y = 0x59,
        /// <summary>Key Y Up</summary>
        YUp = 0x1059,
        /// <summary>Key Z</summary>
        Z = 0x5A,
        /// <summary>Key Z Up</summary>
        ZUp = 0x105A,

        // Numbers (Top Row)
        /// <summary>Key D0</summary>
        D0 = 0x30,
        /// <summary>Key D0 Up</summary>
        D0Up = 0x1030,
        /// <summary>Key D1</summary>
        D1 = 0x31,
        /// <summary>Key D1 Up</summary>
        D1Up = 0x1031,
        /// <summary>Key D2</summary>
        D2 = 0x32,
        /// <summary>Key D2 Up</summary>
        D2Up = 0x1032,
        /// <summary>Key D3</summary>
        D3 = 0x33,
        /// <summary>Key D3 Up</summary>
        D3Up = 0x1033,
        /// <summary>Key D4</summary>
        D4 = 0x34,
        /// <summary>Key D4 Up</summary>
        D4Up = 0x1034,
        /// <summary>Key D5</summary>
        D5 = 0x35,
        /// <summary>Key D5 Up</summary>
        D5Up = 0x1035,
        /// <summary>Key D6</summary>
        D6 = 0x36,
        /// <summary>Key D6 Up</summary>
        D6Up = 0x1036,
        /// <summary>Key D7</summary>
        D7 = 0x37,
        /// <summary>Key D7 Up</summary>
        D7Up = 0x1037,
        /// <summary>Key D8</summary>
        D8 = 0x38,
        /// <summary>Key D8 Up</summary>
        D8Up = 0x1038,
        /// <summary>Key D9</summary>
        D9 = 0x39,
        /// <summary>Key D9 Up</summary>
        D9Up = 0x1039,

        // Function Keys
        /// <summary>Key F1</summary>
        F1 = 0x70,
        /// <summary>Key F1 Up</summary>
        F1Up = 0x1070,
        /// <summary>Key F2</summary>
        F2 = 0x71,
        /// <summary>Key F2 Up</summary>
        F2Up = 0x1071,
        /// <summary>Key F3</summary>
        F3 = 0x72,
        /// <summary>Key F3 Up</summary>
        F3Up = 0x1072,
        /// <summary>Key F4</summary>
        F4 = 0x73,
        /// <summary>Key F4 Up</summary>
        F4Up = 0x1073,
        /// <summary>Key F5</summary>
        F5 = 0x74,
        /// <summary>Key F5 Up</summary>
        F5Up = 0x1074,
        /// <summary>Key F6</summary>
        F6 = 0x75,
        /// <summary>Key F6 Up</summary>
        F6Up = 0x1075,
        /// <summary>Key F7</summary>
        F7 = 0x76,
        /// <summary>Key F7 Up</summary>
        F7Up = 0x1076,
        /// <summary>Key F8</summary>
        F8 = 0x77,
        /// <summary>Key F8 Up</summary>
        F8Up = 0x1077,
        /// <summary>Key F9</summary>
        F9 = 0x78,
        /// <summary>Key F9 Up</summary>
        F9Up = 0x1078,
        /// <summary>Key F10</summary>
        F10 = 0x79,
        /// <summary>Key F10 Up</summary>
        F10Up = 0x1079,
        /// <summary>Key F11</summary>
        F11 = 0x7A,
        /// <summary>Key F11 Up</summary>
        F11Up = 0x107A,
        /// <summary>Key F12</summary>
        F12 = 0x7B,
        /// <summary>Key F12 Up</summary>
        F12Up = 0x107B,

        // Modifier Keys
        /// <summary>Key Shift</summary>
        Shift = 0x10,
        /// <summary>Key Shift Up</summary>
        ShiftUp = 0x1010,
        /// <summary>Key Control</summary>
        Control = 0x11,
        /// <summary>Key Control Up</summary>
        ControlUp = 0x1011,
        /// <summary>Key Alt</summary>
        Alt = 0x12,
        /// <summary>Key Alt Up</summary>
        AltUp = 0x1012,
        /// <summary>Key LShift</summary>
        LShift = 0xA0,
        /// <summary>Key LShift Up</summary>
        LShiftUp = 0x10A0,
        /// <summary>Key RShift</summary>
        RShift = 0xA1,
        /// <summary>Key RShift Up</summary>
        RShiftUp = 0x10A1,
        /// <summary>Key LControl</summary>
        LControl = 0xA2,
        /// <summary>Key LControl Up</summary>
        LControlUp = 0x10A2,
        /// <summary>Key RControl</summary>
        RControl = 0xA3,
        /// <summary>Key RControl Up</summary>
        RControlUp = 0x10A3,
        /// <summary>Key LAlt</summary>
        LAlt = 0xA4,
        /// <summary>Key LAlt Up</summary>
        LAltUp = 0x10A4,
        /// <summary>Key RAlt</summary>
        RAlt = 0xA5,
        /// <summary>Key RAlt Up</summary>
        RAltUp = 0x10A5,

        // Navigation Keys
        /// <summary>Key Enter</summary>
        Enter = 0x0D,
        /// <summary>Key Enter Up</summary>
        EnterUp = 0x100D,
        /// <summary>Key Escape</summary>
        Escape = 0x1B,
        /// <summary>Key Escape Up</summary>
        EscapeUp = 0x101B,
        /// <summary>Key Tab</summary>
        Tab = 0x09,
        /// <summary>Key Tab Up</summary>
        TabUp = 0x1009,
        /// <summary>Key Space</summary>
        Space = 0x20,
        /// <summary>Key Space Up</summary>
        SpaceUp = 0x1020,
        /// <summary>Key Backspace</summary>
        Backspace = 0x08,
        /// <summary>Key Backspace Up</summary>
        BackspaceUp = 0x1008,
        /// <summary>Key Insert</summary>
        Insert = 0x2D,
        /// <summary>Key Insert Up</summary>
        InsertUp = 0x102D,
        /// <summary>Key Delete</summary>
        Delete = 0x2E,
        /// <summary>Key Delete Up</summary>
        DeleteUp = 0x102E,
        /// <summary>Key Home</summary>
        Home = 0x24,
        /// <summary>Key Home Up</summary>
        HomeUp = 0x1024,
        /// <summary>Key End</summary>
        End = 0x23,
        /// <summary>Key End Up</summary>
        EndUp = 0x1023,
        /// <summary>Key PageUp</summary>
        PageUp = 0x21,
        /// <summary>Key PageUp Up</summary>
        PageUpUp = 0x1021,
        /// <summary>Key PageDown</summary>
        PageDown = 0x22,
        /// <summary>Key PageDown Up</summary>
        PageDownUp = 0x1022,
        /// <summary>Key ArrowLeft</summary>
        ArrowLeft = 0x25,
        /// <summary>Key ArrowLeft Up</summary>
        ArrowLeftUp = 0x1025,
        /// <summary>Key ArrowUp</summary>
        ArrowUp = 0x26,
        /// <summary>Key ArrowUp Up</summary>
        ArrowUpUp = 0x1026,
        /// <summary>Key ArrowRight</summary>
        ArrowRight = 0x27,
        /// <summary>Key ArrowRight Up</summary>
        ArrowRightUp = 0x1027,
        /// <summary>Key ArrowDown</summary>
        ArrowDown = 0x28,
        /// <summary>Key ArrowDown Up</summary>
        ArrowDownUp = 0x1028,

        // Numpad
        /// <summary>Key NumPad0</summary>
        NumPad0 = 0x60,
        /// <summary>Key NumPad0 Up</summary>
        NumPad0Up = 0x1060,
        /// <summary>Key NumPad1</summary>
        NumPad1 = 0x61,
        /// <summary>Key NumPad1 Up</summary>
        NumPad1Up = 0x1061,
        /// <summary>Key NumPad2</summary>
        NumPad2 = 0x62,
        /// <summary>Key NumPad2 Up</summary>
        NumPad2Up = 0x1062,
        /// <summary>Key NumPad3</summary>
        NumPad3 = 0x63,
        /// <summary>Key NumPad3 Up</summary>
        NumPad3Up = 0x1063,
        /// <summary>Key NumPad4</summary>
        NumPad4 = 0x64,
        /// <summary>Key NumPad4 Up</summary>
        NumPad4Up = 0x1064,
        /// <summary>Key NumPad5</summary>
        NumPad5 = 0x65,
        /// <summary>Key NumPad5 Up</summary>
        NumPad5Up = 0x1065,
        /// <summary>Key NumPad6</summary>
        NumPad6 = 0x66,
        /// <summary>Key NumPad6 Up</summary>
        NumPad6Up = 0x1066,
        /// <summary>Key NumPad7</summary>
        NumPad7 = 0x67,
        /// <summary>Key NumPad7 Up</summary>
        NumPad7Up = 0x1067,
        /// <summary>Key NumPad8</summary>
        NumPad8 = 0x68,
        /// <summary>Key NumPad8 Up</summary>
        NumPad8Up = 0x1068,
        /// <summary>Key NumPad9</summary>
        NumPad9 = 0x69,
        /// <summary>Key NumPad9 Up</summary>
        NumPad9Up = 0x1069,
        /// <summary>Key NumPadMultiply</summary>
        NumPadMultiply = 0x6A,
        /// <summary>Key NumPadMultiply Up</summary>
        NumPadMultiplyUp = 0x106A,
        /// <summary>Key NumPadAdd</summary>
        NumPadAdd = 0x6B,
        /// <summary>Key NumPadAdd Up</summary>
        NumPadAddUp = 0x106B,
        /// <summary>Key NumPadSubtract</summary>
        NumPadSubtract = 0x6D,
        /// <summary>Key NumPadSubtract Up</summary>
        NumPadSubtractUp = 0x106D,
        /// <summary>Key NumPadDecimal</summary>
        NumPadDecimal = 0x6E,
        /// <summary>Key NumPadDecimal Up</summary>
        NumPadDecimalUp = 0x106E,
        /// <summary>Key NumPadDivide</summary>
        NumPadDivide = 0x6F,
        /// <summary>Key NumPadDivide Up</summary>
        NumPadDivideUp = 0x106F,

        // Symbols
        /// <summary>Key Semicolon</summary>
        Semicolon = 0xBA,
        /// <summary>Key Semicolon Up</summary>
        SemicolonUp = 0x10BA,
        /// <summary>Key Equal</summary>
        Equal = 0xBB,
        /// <summary>Key Equal Up</summary>
        EqualUp = 0x10BB,
        /// <summary>Key Comma</summary>
        Comma = 0xBC,
        /// <summary>Key Comma Up</summary>
        CommaUp = 0x10BC,
        /// <summary>Key Minus</summary>
        Minus = 0xBD,
        /// <summary>Key Minus Up</summary>
        MinusUp = 0x10BD,
        /// <summary>Key Period</summary>
        Period = 0xBE,
        /// <summary>Key Period Up</summary>
        PeriodUp = 0x10BE,
        /// <summary>Key Slash</summary>
        Slash = 0xBF,
        /// <summary>Key Slash Up</summary>
        SlashUp = 0x10BF,
        /// <summary>Key Backtick</summary>
        Backtick = 0xC0,
        /// <summary>Key Backtick Up</summary>
        BacktickUp = 0x10C0,
        /// <summary>Key OpenBracket</summary>
        OpenBracket = 0xDB,
        /// <summary>Key OpenBracket Up</summary>
        OpenBracketUp = 0x10DB,
        /// <summary>Key Backslash</summary>
        Backslash = 0xDC,
        /// <summary>Key Backslash Up</summary>
        BackslashUp = 0x10DC,
        /// <summary>Key CloseBracket</summary>
        CloseBracket = 0xDD,
        /// <summary>Key CloseBracket Up</summary>
        CloseBracketUp = 0x10DD,
        /// <summary>Key Quote</summary>
        Quote = 0xDE,
        /// <summary>Key Quote Up</summary>
        QuoteUp = 0x10DE,

        // Mouse buttons
        /// <summary>Key LButton</summary>
        LButton = 0x01,
        /// <summary>Key LButton Up</summary>
        LButtonUp = 0x1001,
        /// <summary>Key RButton</summary>
        RButton = 0x02,
        /// <summary>Key RButton Up</summary>
        RButtonUp = 0x1002,
        /// <summary>Key MButton</summary>
        MButton = 0x04,
        /// <summary>Key MButton Up</summary>
        MButtonUp = 0x1004,
        /// <summary>Key XButton1</summary>
        XButton1 = 0x05,
        /// <summary>Key XButton1 Up</summary>
        XButton1Up = 0x1005,
        /// <summary>Key XButton2</summary>
        XButton2 = 0x06,
        /// <summary>Key XButton2 Up</summary>
        XButton2Up = 0x1006,
    }
}
