namespace OrkEngine3D.Graphics.SILK.Resources;

public enum ShaderType
{
    ComputeShader = Silk.NET.OpenGL.ShaderType.ComputeShader,
    FragmentShader = Silk.NET.OpenGL.ShaderType.FragmentShader,
    VertexShader = Silk.NET.OpenGL.ShaderType.VertexShader,
    FragmentShaderArb = Silk.NET.OpenGL.ShaderType.FragmentShaderArb,
    VertexShaderArb = Silk.NET.OpenGL.ShaderType.VertexShaderArb,
    GeometryShader = Silk.NET.OpenGL.ShaderType.GeometryShader,
    TessControlShader = Silk.NET.OpenGL.ShaderType.TessControlShader,
    TessEvaluationShader = Silk.NET.OpenGL.ShaderType.TessEvaluationShader
}