# GlobalHotKeys

A **universal C# library** for handling **global hotkeys** using **keyboard and mouse combinations** at a low level. Built with modularity, cross-project reuse, and developer ergonomics in mind.

---

## ✅ Features

- 📦 Global low-level input hook (keyboard + mouse)
- 🔀 Unified `KeyCode` enum for keyboard and mouse
- 🧠 Combo logic with support for modifier + button combos (e.g. `Ctrl + Shift + XButton1`)
- 🔧 Easy registration using `Bind` and `HotkeyCombination`
- 🔁 Trigger-once execution until all keys are released
- 🧼 Clean modular architecture (fully self-contained)
- 🪟 Built on Win32 `SendInput` and `SetWindowsHookEx`

---

## 📂 Project Structure

| File | Description |
|------|-------------|
| `KeyCode.cs` | Universal enum for all keyboard/mouse keys (like `A`, `F5`, `XButton1`) |
| `HotkeyCombination.cs` | Represents a set of keys that define a hotkey |
| `Bind.cs` | Simplifies registration by bundling an ID + combo |
| `ActiveCombination.cs` | Tracks active/completed state of an input combo |
| `HotkeyRegistry.cs` | Maps IDs and combos to actions |
| `HookLifecycle.cs` | Manages low-level Win32 hooks (start, stop, dispose) |
| `Interop.cs` | Isolated Win32 imports and constants |
| `HotKeys.cs` | High-level manager for using all of the above |

---

## 🚀 Quick Start

```bash
dotnet add package GlobalHotKeys.Latur
```

```csharp
using GlobalHotKeys;
using GlobalHotKeys.Structs;

var manager = new GlobalHotKeys.HotKeys();

manager.Register(new Bind("screenshot", KeyCode.Control, KeyCode.F5), async () =>
{
    Console.WriteLine("Screenshot triggered!");
});

manager.Start();
```

---

## 🧠 How It Works

1. Low-level hooks are installed using Win32 APIs
2. Keys and mouse buttons are unified into a `HashSet<KeyCode>`
3. When a combination is pressed, it's matched against registered actions
4. The action is only invoked once per full press-release cycle
5. You can dynamically register, update, or remove combos during runtime

---

## 🔧 Example Usage

### Register a Hotkey:

```csharp
manager.Register(new Bind("open-dev", KeyCode.LControl, KeyCode.LShift, KeyCode.D), async () =>
{
    Console.WriteLine("Dev Tools Opened");
});
```

### Change an Existing Combo:

```csharp
manager.Change("open-dev", new HotkeyCombination(false, KeyCode.Control, KeyCode.F1));
```

### Remove a Combo:

```csharp
manager.Unregister("open-dev");
```

---

## 🔒 Limitations

- Windows-only (relies on `SetWindowsHookEx`)
- Must run on STA thread for hook reliability
- Cannot detect keys consumed by some protected fullscreen games

---

## 🧱 Building from Source

```bash
git clone https://github.com/latur-h/GlobalHotKeys
cd GlobalHotKeys
dotnet build -c Release
```

---

## 📜 License

MIT — free for personal and commercial use.
