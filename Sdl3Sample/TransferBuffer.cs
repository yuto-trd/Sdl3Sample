using SDL;

namespace Sdl3Sample;

public unsafe class TransferBuffer : IDisposable
{
    internal readonly Device _device;
    internal readonly SDL_GPUTransferBuffer* _transferBufferPtr;
    internal readonly TransferBufferCreateInfo _createInfo;

    internal TransferBuffer(Device device, SDL_GPUTransferBuffer* transferBuffer, TransferBufferCreateInfo createInfo)
    {
        _device = device;
        _transferBufferPtr = transferBuffer;
        _createInfo = createInfo;
    }
    
    public MappedBuffer Map(bool cycle = false)
    {
        var ptr = SDL3.SDL_MapGPUTransferBuffer(_device.DevicePtr, _transferBufferPtr, cycle);
        return new MappedBuffer(ptr, this);        
    }
    
    public void Dispose()
    {
        SDL3.SDL_ReleaseGPUTransferBuffer(_device.DevicePtr, _transferBufferPtr);
    }
}