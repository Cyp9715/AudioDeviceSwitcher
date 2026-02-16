// Copyright (c) 2021 Jose Torres. All rights reserved. Licensed under the Apache License, Version 2.0. See LICENSE.md file in the project root for full license information.

namespace SoundFlip;

public interface IHotkeyManager
{
    void RegisterHotkey(int id, Hotkey hotkey);
    void UnregisterHotkey(int id);
}
