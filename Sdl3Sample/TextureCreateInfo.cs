using SDL;

namespace Sdl3Sample;

public struct TextureCreateInfo
{
    public TextureType Type { get; set; }
    
    public TextureFormat Format { get; set; }
    
    public TextureUsageFlags Usage { get; set; }
    
    public uint Width { get; set; }
    
    public uint Height { get; set; }
    
    public uint LayerCountOrDepth { get; set; }
    
    public uint NumLevels { get; set; }
    
    public SampleCount SampleCount { get; set; }
    
    // public SDL_PropertiesID Props { get; set; }
    
    internal SDL_GPUTextureCreateInfo ToNative()
    {
        return new SDL_GPUTextureCreateInfo
        {
            type = (SDL_GPUTextureType)Type,
            format = (SDL_GPUTextureFormat)Format,
            usage = (SDL_GPUTextureUsageFlags)Usage,
            width = Width,
            height = Height,
            layer_count_or_depth = LayerCountOrDepth,
            num_levels = NumLevels,
            sample_count = (SDL_GPUSampleCount)SampleCount,
            // props = Props
        };
    }
}