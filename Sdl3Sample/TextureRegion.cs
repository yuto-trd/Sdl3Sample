using SDL;

namespace Sdl3Sample;

public struct TextureRegion
{
    public required Texture Texture { get; set; }
    
    public required uint MipLevel { get; set; }
    
    public required uint Layer { get; set; }
    
    public required uint X { get; set; }
    
    public required uint Y { get; set; }
    
    public required uint Z { get; set; }
    
    public required uint Width { get; set; }
    
    public required uint Height { get; set; }
    
    public required uint Depth { get; set; }
    
    internal unsafe SDL_GPUTextureRegion ToNative()
    {
        return new SDL_GPUTextureRegion
        {
            texture = Texture.TexturePtr,
            mip_level = MipLevel,
            layer = Layer,
            x = X,
            y = Y,
            z = Z,
            w = Width,
            h = Height,
            d = Depth
        };
    }
}