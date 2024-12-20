using SDL;

namespace Sdl3Sample;

public unsafe class Device : IDisposable
{
    private Device(SDL_GPUDevice* device)
    {
        DevicePtr = device;
    }

    public SDL_GPUDevice* DevicePtr { get; set; }

    public CommandBuffer AcquireCommandBuffer()
    {
        var commandBuffer = SDL3.SDL_AcquireGPUCommandBuffer(DevicePtr);
        if (commandBuffer == null)
        {
            throw new InvalidOperationException(SDL3.SDL_GetError());
        }

        return new CommandBuffer(commandBuffer);
    }

    public Texture CreateTexture(TextureCreateInfo createInfo)
    {
        var _createInfo = createInfo.ToNative();
        var texture = SDL3.SDL_CreateGPUTexture(DevicePtr, &_createInfo);
        if (texture == null)
        {
            throw new InvalidOperationException(SDL3.SDL_GetError());
        }

        return new Texture(this, texture, createInfo);
    }

    public TransferBuffer CreateTransferBuffer(TransferBufferCreateInfo createInfo)
    {
        var _createInfo = createInfo.ToNative();
        var transferBuffer = SDL3.SDL_CreateGPUTransferBuffer(DevicePtr, &_createInfo);
        if (transferBuffer == null)
        {
            throw new InvalidOperationException(SDL3.SDL_GetError());
        }

        return new TransferBuffer(this, transferBuffer, createInfo);
    }

    public TransferBuffer CreateDownloadBuffer(uint size)
    {
        return CreateTransferBuffer(TransferBufferCreateInfo.CreateDownload(size));
    }
    
    public TransferBuffer CreateUploadBuffer(uint size)
    {
        return CreateTransferBuffer(TransferBufferCreateInfo.CreateUpload(size));
    }

    public static Device Create(ShaderFormat formatFlags, bool debugMode, string? name)
    {
        var device = SDL3.SDL_CreateGPUDevice((SDL_GPUShaderFormat)formatFlags, debugMode, name);
        if (device == null)
        {
            throw new InvalidOperationException(SDL3.SDL_GetError());
        }

        return new Device(device);
    }

    public void Dispose()
    {
        SDL3.SDL_DestroyGPUDevice(DevicePtr);
    }
}