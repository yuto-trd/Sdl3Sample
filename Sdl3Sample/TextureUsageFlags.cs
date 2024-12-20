namespace Sdl3Sample;

[Flags]
public enum TextureUsageFlags : uint
{
    Sampler = 1,
    ColorTarget = 2,
    DepthStencilTarget = 4,
    GraphicsStorageRead = 8,
    ComputeStorageRead = 16,
    ComputeStorageWrite = 32
}