using SDL;

namespace Sdl3Sample;

public struct ColorTargetInfo
{
    public Texture Texture { get; set; }
    public uint MipLevel { get; set; }
    public uint LayerOrDepthPlane { get; set; }
    public ColorF ClearColor { get; set; }
    public LoadOp LoadOp { get; set; }
    public StoreOp StoreOp { get; set; }
    public Texture ResolveTexture { get; set; }
    public uint ResolveMipLevel { get; set; }
    public uint ResolveLayer { get; set; }
    public bool Cycle { get; set; }
    public bool CycleResolveTexture { get; set; }
    public byte Padding1 { get; set; }
    public byte Padding2 { get; set; }

    internal unsafe SDL_GPUColorTargetInfo ToNative()
    {
        return new SDL_GPUColorTargetInfo
        {
            texture = Texture != null ? Texture.TexturePtr : null,
            mip_level = MipLevel,
            layer_or_depth_plane = LayerOrDepthPlane,
            clear_color = new SDL_FColor
            {
                r = ClearColor.R,
                g = ClearColor.G,
                b = ClearColor.B,
                a = ClearColor.A
            },
            load_op = (SDL_GPULoadOp)LoadOp,
            store_op = (SDL_GPUStoreOp)StoreOp,
            resolve_texture = ResolveTexture != null ? ResolveTexture.TexturePtr : null,
            resolve_mip_level = ResolveMipLevel,
            resolve_layer = ResolveLayer,
            cycle = Cycle,
            cycle_resolve_texture = CycleResolveTexture,
            padding1 = Padding1,
            padding2 = Padding2
        };
    }
}