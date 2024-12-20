using SDL;

namespace Sdl3Sample;

public struct TextureTransferInfo
{
    public required TransferBuffer TransferBuffer { get; set; }

    public required uint Offset { get; set; }

    public required uint PixelsPerRow { get; set; }

    public required uint RowsPerLayer { get; set; }

    internal unsafe SDL_GPUTextureTransferInfo ToNative()
    {
        return new SDL_GPUTextureTransferInfo
        {
            transfer_buffer = TransferBuffer != null ? TransferBuffer._transferBufferPtr : null,
            offset = Offset,
            pixels_per_row = PixelsPerRow,
            rows_per_layer = RowsPerLayer
        };
    }
}