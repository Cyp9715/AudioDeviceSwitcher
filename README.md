# SoundFlip

This repository is a fork of the original [josetr/AudioDeviceSwitcher](https://github.com/josetr/AudioDeviceSwitcher), focused on practical reliability and compatibility improvements for daily use.

<p align="center">
  <img src="SoundFlip.png" alt="SoundFlip" width="300" height="300" />
</p>

## Why this fork exists

- Windows/driver updates can change audio endpoint IDs, which caused repeated command/device re-registration.
- Older runtime/package combinations created compatibility and maintenance issues on modern toolchains.

## What changed in this fork

### 1) Resilient device reference handling (fixes repeated re-registration)

- Commands now use resilient device references (`name + ID hash`) instead of only raw IDs.
- During load/switch, references are resolved to current device IDs with fallback matching.
- Existing command mappings survive endpoint ID churn more reliably.

### 2) Runtime and dependency modernization (compatibility improvements)

- Upgraded target framework/runtime to `net10.0-windows10.0.26100.0` (Windows 11 24H2+).
- Updated core dependencies (including Windows App SDK) to maintained versions.
- Applied packaging/build adjustments for better compatibility in newer environments.

## Notes

- Original project and credit: [josetr/AudioDeviceSwitcher](https://github.com/josetr/AudioDeviceSwitcher).
