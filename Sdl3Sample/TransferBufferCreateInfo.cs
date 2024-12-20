using SDL;

namespace Sdl3Sample;

public struct TransferBufferCreateInfo
{
    public TransferBufferUsage Usage { get; set; }
    public uint Size { get; set; }
    // public SDL_PropertiesID Props;

    public static TransferBufferCreateInfo CreateDownload(uint size)
    {
        return new TransferBufferCreateInfo
        {
            Usage = TransferBufferUsage.Download,
            Size = size
        };
    }

    public static TransferBufferCreateInfo CreateUpload(uint size)
    {
        return new TransferBufferCreateInfo
        {
            Usage = TransferBufferUsage.Upload,
            Size = size
        };
    }

    public SDL_GPUTransferBufferCreateInfo ToNative()
    {
        return new()
        {
            usage = (SDL_GPUTransferBufferUsage)Usage,
            size = Size,
            // props = Props
        };
    }
}