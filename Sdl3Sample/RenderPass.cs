using SDL;

namespace Sdl3Sample;

public unsafe class RenderPass : IDisposable
{
    private readonly CommandBuffer _commandBuffer;
    private readonly SDL_GPURenderPass* _renderPass;
    private readonly ColorTargetInfo[] _colorTargetInfos;
    private readonly DepthStencilTargetInfo? _depthStencilTargetInfo;

    internal RenderPass(
        CommandBuffer commandBuffer, SDL_GPURenderPass* renderPass, ColorTargetInfo[] colorTargetInfos,
        DepthStencilTargetInfo? depthStencilTargetInfo)
    {
        _commandBuffer = commandBuffer;
        _renderPass = renderPass;
        _colorTargetInfos = colorTargetInfos;
        _depthStencilTargetInfo = depthStencilTargetInfo;
    }

    public void Dispose()
    {
        SDL3.SDL_EndGPURenderPass(_renderPass);
    }
}