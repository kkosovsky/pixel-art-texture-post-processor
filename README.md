# PAT (Pixel Art Texture) Post Processor

A Unity Editor tool that automatically applies pixel-perfect import settings to sprite textures based on configurable path rules and naming conventions.

![Unity Version](https://img.shields.io/badge/Unity-2020.3%2B-blue)
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
3. Enter: `https://github.com/kkosovsky/pixel-art-texture-post-processor.git`

### Manual Installation

1. Download the latest release
2. Extract to your project (recommended: `Assets/PixelArtTexturePostProcessor/` or `Packages/`)
3. Unity will automatically detect and import the package

## Quick Start

1. When you add PAT to your project, it auto-creates default settings at `Assets/PAT_DefaultSettings.asset` and activates them
2. Find the settings asset in your Project window (you can move it anywhere you want)
3. Configure your settings (PPU, paths, etc.) in the Inspector
4. Import your pixel art - settings apply automatically!

> **Note**  
> - You can have multiple setting assets and switch between them, more in [Working with Multiple Settings](#working-with-multiple-settings)
> - If you close Unity Editor when there are NO existing settings assets, PAT will auto-create default settings on the next launch
> - If you close Unity Editor when there ARE existing settings, nothing will happen - PAT will use last active settings

## Configuration

### Creating Settings

There are three ways to create settings:

**Method 1: Right-Click Menu**  
`Right-click in Project → Create > PAT Post Processor > Settings`

**Method 2: Tools Menu**  
`Tools → PAT Post Processor → Create Default Settings` (opens save dialog)

**Method 3: Automatic**  
Settings are auto-created at `Assets/PAT_DefaultSettings.asset` and activated if none exist when Unity starts

### Working with Multiple Settings

You can create multiple settings configurations for different workflows:

1. Create new settings using any of the methods above
2. Configure the settings as needed
3. Select the settings in the Inspector
4. Click **"Activate Settings"** to make it active
5. Only one settings object can be active at a time (others are automatically deactivated)

**Active Settings Indicator:**
- Active settings show: "This settings object is currently ACTIVE" (blue info box) with **"Deactivate Settings"** button
- Inactive settings show: "This settings object is currently INACTIVE" (yellow warning box) with **"Activate Settings"** button

**Deactivating Settings:**
- Click **"Deactivate Settings"** to turn off the post-processor without deleting the settings
- When no settings are active, textures are imported with default Unity settings
- You can reactivate the same settings later

**Loading Priority on Startup:**
1. Settings marked as active (uses first if multiple found)
2. First available settings file (auto-activated as fallback)
3. Creates default settings if none exist and activates them

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
Default: `["Animation", "Anim"]`  
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
PPU: 32
Min Texture Size: 32
```

### Example 2: Mixed Asset Types
```
Include Paths: ["Assets/Art/Characters/", "Assets/Art/Environment/"]
Exclude Paths: ["Assets/Art/Environment/HD/"]
Full Rect Mesh Substrings: ["UI", "9Slice"]
Multiple Sprite Mode Substrings: ["Animation", "Spritesheet"]
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

### Settings Lifecycle Management

The system monitors settings assets and handles lifecycle events:

- **On Startup**: Loads active settings or creates defaults if none exist
- **On Activation**: Automatically deactivates other settings to ensure only one is active
- **On Deactivation**: Post-processor becomes inactive; textures use Unity's default import settings
- **On Deletion**: If active settings are deleted, post-processor immediately becomes inactive and logs a warning
- **Multiple Settings**: You can maintain multiple configuration profiles and switch between them anytime

## Requirements

- Unity 2020.3 or higher
- No external dependencies

## Compatibility

- ✅ Unity 2020.3 LTS+
- ✅ All render pipelines (Built-in, URP, HDRP)
- ✅ All platforms

## Troubleshooting

**Q: My sprites aren't being processed**  
A: Check the following:
- Ensure at least one settings object exists and is active (blue info box in Inspector)
- Verify your sprite path is in `Include Paths` and not in `Exclude Paths`
- Check the Console for any PAT warning messages

**Q: Can I have multiple settings files?**  
A: Yes! Create multiple settings configurations. Only one can be active at a time.

**Q: How do I switch between different settings?**  
A: Select the settings you want to activate in the Inspector and click the **"Activate Settings"** button. The system automatically deactivates all other settings and activates the selected one.

**Q: How do I temporarily disable the post-processor?**  
A: Select your active settings and click **"Deactivate Settings"**. This keeps the settings file but stops processing textures. You can reactivate it anytime without losing your configuration.

**Q: What happens if I delete the active settings?**  
A: The post-processor becomes inactive immediately. The system will NOT auto-create new settings. To resume processing, either:
- Create new settings manually via the right-click menu or Tools menu
- Reactivate any existing inactive settings

**Q: How do I reset to defaults?**  
A: Use `Tools → PAT Post Processor → Create Default Settings` to create a fresh settings file with default values. Then activate it.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

### Workflow

1. Clone the repository
2. Create your feature branch (see branch naming below)
3. Commit your changes (see commit conventions below)
4. Push to the branch
5. Open a Pull Request

### Branch Naming Convention

We follow **semantic branch naming** with type prefixes:

```
<type>/<short-description>
```

**Types:**
- `feat/` - New features (e.g., `feat/add-animator-support`)
- `fix/` - Bug fixes (e.g., `fix/resolve-reentrancy-error`)
- `docs/` - Documentation changes (e.g., `docs/update-readme`)
- `refactor/` - Code refactoring (e.g., `refactor/simplify-settings-loader`)
- `test/` - Adding or updating tests
- `chore/` - Maintenance tasks (e.g., `chore/update-dependencies`)

**Examples:**
```bash
git checkout -b feat/add-multiple-ppu-support
git checkout -b fix/path-matching-bug
git checkout -b docs/improve-installation-guide
```

### Commit Message Convention

We use **[Conventional Commits](https://www.conventionalcommits.org/)** format:

```
<type>[optional scope]: <description>

[optional body]

[optional footer]
```

**Rules:**
- Summary line must be **50 characters or less**
- Use imperative mood ("add feature" not "added feature")
- No period at the end of the summary
- Body wraps at 72 characters (if needed)

**Types:**
- `feat` - New feature
- `fix` - Bug fix
- `docs` - Documentation
- `refactor` - Code refactoring
- `test` - Tests
- `chore` - Maintenance

**Examples:**
```bash
# Good (under 50 chars)
git commit -m "feat: add sprite mesh configuration"
git commit -m "fix: resolve AssetDatabase reentrancy error"
git commit -m "docs: update installation instructions"

# With scope
git commit -m "fix(loader): prevent nested refresh calls"
git commit -m "feat(settings): add multiple PPU support"

# With body
git commit -m "feat: add active settings management

- Implement SetActiveSettings method
- Add visual indicators in Inspector
- Auto-deactivate conflicting settings"
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

**Kamil Kosowski**  
📧 kosowski.ka@gmail.com  
👾 Discord: `kosowski`

## Acknowledgments

Built for the Unity pixel art community 🎮✨

---

⭐ If this tool helps your project, consider giving it a star!

