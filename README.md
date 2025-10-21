# Pixel Art Texture Post Processor

A Unity Editor tool that automatically applies pixel-perfect import settings to sprite textures based on configurable path rules and naming conventions.

![Unity Version](https://img.shields.io/badge/Unity-6000.2%2B-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Version](https://img.shields.io/badge/version-1.0.0-orange)

## Features

✨ **Automatic Import Configuration** - No more manual texture import settings  
🎯 **Pixel-Perfect Rendering** - Point filtering and uncompressed textures by default  
📏 **Smart Texture Sizing** - Automatically sets max texture size to nearest power of two  
🎨 **Configurable PPU** - Set pixels-per-unit globally across your sprites  
📂 **Path-Based Rules** - Include/exclude specific paths from processing  
🔲 **Sprite Mesh Control** - Configure FullRect vs Tight mesh based on naming or paths  
🎬 **Sprite Mode Detection** - Automatically set Single vs Multiple mode for animation sheets  
⚙️ **Zero Manual Work** - Once configured, all new sprites are processed automatically

## Installation

### Via Git URL (Unity Package Manager)

1. Open Unity Package Manager (`Window > Package Manager`)
2. Click the `+` button → `Add package from git URL`
3. Enter: `https://github.com/yourusername/pixel-art-texture-post-processor.git`

### Manual Installation

1. Download the latest release
2. Extract to your project's `Packages` folder
3. Unity will automatically import the package

## Quick Start

1. The package auto-creates default settings on first import
2. Configure settings via `Assets > PixelArtTexturePostProcessor > Editor > Settings > Assets > PAT_DefaultSettings`
3. Add your sprite paths to `Include Paths` (e.g., `Assets/Sprites/`)
4. Import your pixel art - settings apply automatically!

## Configuration

### Settings Location

Settings are stored at:
```
Assets/PixelArtTexturePostProcessor/Editor/Settings/Assets/PAT_DefaultSettings.asset
```

You can also create custom settings via:  
`Right-click in Project → Create > PixelArtPostProcessor > Settings`

### Base Settings

| Setting | Default | Description |
|---------|---------|-------------|
| **PPU** | 32 | Pixels Per Unit for all sprites |
| **Min Texture Size** | 32 | Minimum texture size (power of two) |
| **Is Readable** | true | Enable/disable Read/Write on textures |
| **Post Process Order** | 0 | Execution order relative to other postprocessors |

### Path Configuration

**Include Paths**  
Array of paths to process (e.g., `Assets/Sprites/`)

**Exclude Paths**  
Default: `["Packages/", "Assets/Gizmos/", "Assets/StreamingAssets/"]`  
Array of paths to skip even if in include paths

> **Note:** Only textures in `includePaths` AND not in `excludePaths` will be processed. By default, Unity packages, editor gizmos, and streaming assets are excluded to prevent unintended processing.

### Sprite Mesh Type

Control whether sprites use `FullRect` or `Tight` mesh generation:

**Full Rect Mesh Substrings**  
Default: `["9Slice"]`  
Any texture path containing these strings uses FullRect mesh

**Full Rect Mesh Paths**  
Specific paths that should use FullRect mesh

> Textures not matching these rules use `Tight` mesh type.

### Sprite Mode

Control whether sprites are imported as `Single` or `Multiple`:

**Multiple Sprite Mode Substrings**  
Default: `["Animation"]`  
Any texture path containing these strings uses Multiple sprite mode (for sprite sheets)

**Multiple Sprite Mode Paths**  
Specific paths that should use Multiple sprite mode

> Textures not matching these rules use `Single` sprite mode.

## What Gets Applied

When a texture is processed, the following settings are automatically configured:

```csharp
// Texture Settings
textureCompression = Uncompressed
filterMode = Point
maxTextureSize = NearestPowerOfTwo(actualSize)
isReadable = [from settings]
spritePixelsPerUnit = [from settings]

// Sprite Settings
spriteMeshType = FullRect or Tight (based on rules)
spriteMode = Single or Multiple (based on rules)
```

## Use Cases

### Example 1: Basic Pixel Art Game
```
Include Paths: ["Assets/Sprites/"]
PPU: 16
Min Texture Size: 32
```

### Example 2: Mixed Asset Types
```
Include Paths: ["Assets/Art/Characters/", "Assets/Art/Environment/"]
Exclude Paths: ["Assets/Art/Environment/HD/"]
Full Rect Mesh Substrings: ["UI", "9Slice"]
Multiple Sprite Mode Substrings: ["Animation", "Spritesheet"]
```

### Example 3: High-Res Pixel Art
```
PPU: 64
Min Texture Size: 64
Include Paths: ["Assets/PixelArt/"]
```

## How It Works

The tool uses Unity's `AssetPostprocessor` to intercept texture imports. When a texture is imported:

1. Path is checked against include/exclude rules
2. If valid, optimal pixel art settings are applied
3. Sprite mesh type determined by naming/path rules
4. Sprite mode determined by naming/path rules
5. Texture size rounded to nearest power of two
6. Settings applied before import completes

**Result:** Zero manual configuration needed! ✨

## Requirements

- Unity 6000.2 or higher
- No external dependencies

## Compatibility

- ✅ Unity 6000.2+
- ✅ All render pipelines (Built-in, URP, HDRP)
- ✅ All platforms

## Troubleshooting

**Q: My sprites aren't being processed**  
A: Check that your sprite path is in `Include Paths` and not in `Exclude Paths`

**Q: Can I have multiple settings files?**  
A: Yes, but only the first one found will be used. The tool searches for any `PATSettings` asset in your project.

**Q: How do I reset to defaults?**  
A: Delete the settings asset - it will be recreated with defaults on next import.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feat/amazing-feature`)
3. Commit your changes (`git commit -m 'feat: add amazing feature'`)
4. Push to the branch (`git push origin feat/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

**Kamil Kosowski**  
📧 kosowski.ka@gmail.com

## Acknowledgments

Built for the Unity pixel art community 🎮✨

---

⭐ If this tool helps your project, consider giving it a star!

