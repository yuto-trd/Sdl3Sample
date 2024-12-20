using SDL;
using Sdl3Sample;
using static SDL.SDL3;

if (!SDL_Init(SDL_InitFlags.SDL_INIT_VIDEO))
{
    Console.WriteLine("Failed to initialize SDL: {0}", SDL_GetError());
    return -1;
}

// GPU デバイスの作成
using var device = Device.Create(ShaderFormat.Dxil, false, null);
// コマンドバッファの取得
var commandBuffer = device.AcquireCommandBuffer();
// オフスクリーン用のテクスチャを作成
using var offscreenTexture = device.CreateTexture(new TextureCreateInfo
{
    Format = TextureFormat.R8G8B8A8_UNORM,
    Width = 512,
    Height = 512,
    Usage = TextureUsageFlags.ColorTarget | TextureUsageFlags.Sampler,
    Type = TextureType.Texture2D,
    LayerCountOrDepth = 1,
    NumLevels = 1,
    SampleCount = SampleCount.SampleCount1
});

var colorTargetInfo = new ColorTargetInfo
{
    Texture = offscreenTexture,
    LoadOp = LoadOp.Clear,
    StoreOp = StoreOp.Store,
    ClearColor = new ColorF { R = 1, G = 1, B = 1, A = 1 }
};
using (var renderPass = commandBuffer.BeginRenderPass([colorTargetInfo], null))
{
    // ここで描画操作を行う
    // 例: SDL_DrawGPUPrimitives(...);
}

// コマンドバッファの送信
// commandBuffer.Submit();

// 結果の処理
// 例: オフスクリーンテクスチャをファイルに保存する、ウィンドウに表示するなど
using (var transferBuffer = device.CreateDownloadBuffer(512 * 512 * 4))
{
    using (var copyPass = commandBuffer.BeginCopyPass())
    {
        var source = offscreenTexture.GetRegion(0, 0, 512, 512);
        var destination = new TextureTransferInfo
        {
            Offset = 0,
            PixelsPerRow = 512,
            RowsPerLayer = 512,
            TransferBuffer = transferBuffer
        };
        copyPass.DownloadFromTexture(source, destination);
    }

    // コマンドバッファの送信
    commandBuffer.Submit();

    using (var mapped = transferBuffer.Map())
    {
        var buffer = mapped.Span.ToArray();
        File.WriteAllBytes("./output", buffer);
    }
}

// リソースの解放
SDL_Quit();
return 0;