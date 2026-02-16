# SoundFlip

This repository is a fork of the original [josetr/AudioDeviceSwitcher](https://github.com/josetr/AudioDeviceSwitcher), focused on practical reliability and compatibility improvements for daily use.

![SoundFlip](SoundFlip.png)

## Why this fork exists

I forked the original project for two concrete pain points:

1. Windows/driver updates could change audio endpoint IDs, which forced command/device re-registration.
2. Older runtime/package combinations caused compatibility and maintenance friction on newer toolchains.

## What changed in this fork

### 1) Resilient device reference handling (fixes repeated re-registration)

Problem:
- Commands were tied to raw device IDs, and those IDs can change after Windows updates, driver updates, or audio stack resets.

Implemented changes:
- Added a resilient reference model that stores device identity as encoded metadata (`name + ID hash`) instead of relying only on raw IDs.
- During load/switch, references are resolved back to current device IDs using fallback matching rules.
- Device selection restoration now uses resilient matching logic.

Related commits:
- `bba2605` Update to .NET 10 and add resilient device references

Key code areas:
- `src/SoundFlip.Core/Domain/DeviceReference.cs`
- `src/SoundFlip.Core/Application/AudioSwitcherToggler.cs`
- `src/SoundFlip.Core/Presentation/ViewModels/AudioPageViewModel.cs`

### 2) Runtime and dependency modernization (compatibility improvements)

Problem:
- Legacy dependency/runtime combinations were increasingly brittle in newer Visual Studio/Windows SDK environments.

Implemented changes:
- Upgraded app/runtime targets to modern .NET (`net10.0-windows10.0.18362.0`).
- Updated core packages (including Windows App SDK line) to current maintained versions.
- Applied packaging project adjustments to avoid debug SDK resolution issues on newer build environments.

Related commits:
- `bba2605` Update to .NET 10 and add resilient device references
- `0ec520a` / `549a518` Packaging project compatibility fixes
- `e424410` Solution/metadata update for current toolchain

## Notes

- This fork keeps the original project's intent and workflow, while prioritizing stability after OS/device changes and smoother build/deploy behavior on modern environments.
- Original repository and credit remain with Jose Torres: [josetr/AudioDeviceSwitcher](https://github.com/josetr/AudioDeviceSwitcher).
