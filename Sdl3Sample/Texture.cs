using SDL;

namespace Sdl3Sample;

public unsafe class Texture : IDisposable
{
    private readonly Device _device;
    private readonly TextureCreateInfo _createInfo;

    internal Texture(Device device, SDL_GPUTexture* texture, TextureCreateInfo createInfo)
    {
        _device = device;
        _createInfo = createInfo;
        TexturePtr = texture;
    }

    public SDL_GPUTexture* TexturePtr { get; set; }
    
    public TextureRegion GetRegion(uint x, uint y, uint width, uint height)
    {
        return new TextureRegion
        {
            Texture = this,
            MipLevel = 0,
            Layer = 0,
            X = x,
            Y = y,
            Z = 0,
            Width = width,
            Height = height,
            Depth = 1
        };
    }

    public void Dispose()
    {
        SDL3.SDL_ReleaseGPUTexture(_device.DevicePtr, TexturePtr);
    }
}