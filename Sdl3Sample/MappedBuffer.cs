using SDL;

namespace Sdl3Sample;

public unsafe class MappedBuffer : IDisposable
{
    private readonly TransferBuffer _transferBuffer;

    internal MappedBuffer(IntPtr ptr, TransferBuffer transferBuffer)
    {
        Ptr = ptr;
        _transferBuffer = transferBuffer;
    }
    
    public IntPtr Ptr { get; }
    
    public Span<byte> Span=> new(Ptr.ToPointer(), (int)_transferBuffer._createInfo.Size);

    public void Dispose()
    {
        SDL3.SDL_UnmapGPUTransferBuffer(_transferBuffer._device.DevicePtr, _transferBuffer._transferBufferPtr);
    }
}