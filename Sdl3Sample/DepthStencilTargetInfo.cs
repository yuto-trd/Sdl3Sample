using SDL;

namespace Sdl3Sample;

public struct DepthStencilTargetInfo
{
    public Texture Texture { get; set; }
    public float ClearDepth { get; set; }
    public LoadOp LoadOp { get; set; }
    public StoreOp StoreOp { get; set; }
    public LoadOp StencilLoadOp { get; set; }
    public StoreOp StencilStoreOp { get; set; }
    public bool Cycle { get; set; }
    public byte ClearStencil { get; set; }
    public byte Padding1 { get; set; }
    public byte Padding2 { get; set; }

    internal unsafe SDL_GPUDepthStencilTargetInfo ToNative()
    {
        return new SDL_GPUDepthStencilTargetInfo
        {
            texture = Texture != null ? Texture.TexturePtr : null,
            clear_depth = ClearDepth,
            load_op = (SDL_GPULoadOp)LoadOp,
            store_op = (SDL_GPUStoreOp)StoreOp,
            stencil_load_op = (SDL_GPULoadOp)StencilLoadOp,
            stencil_store_op = (SDL_GPUStoreOp)StencilStoreOp,
            cycle = Cycle,
            clear_stencil = ClearStencil,
            padding1 = Padding1,
            padding2 = Padding2
        };
    }
}