using SDL;

namespace Sdl3Sample;

public unsafe class CopyPass : IDisposable
{
    private readonly CommandBuffer _commandBuffer;
    private readonly SDL_GPUCopyPass* _copyPassPtr;

    internal CopyPass(CommandBuffer commandBuffer, SDL_GPUCopyPass* copyPass)
    {
        _commandBuffer = commandBuffer;
        _copyPassPtr = copyPass;
    }

    public void DownloadFromTexture(TextureRegion source, TextureTransferInfo destination)
    {
        var _source = source.ToNative();
        var _destination = destination.ToNative();
        SDL3.SDL_DownloadFromGPUTexture(_copyPassPtr, &_source, &_destination);
    }
    
    public void Dispose()
    {
        SDL3.SDL_EndGPUCopyPass(_copyPassPtr);
    }
}