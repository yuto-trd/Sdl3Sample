namespace Sdl3Sample;

[Flags]
public enum ShaderFormat
{
    Private = 1,
    Spirv = 2,
    Dxbc = 4,
    Dxil = 8,
    Msl = 16,
    Metallib = 32
}