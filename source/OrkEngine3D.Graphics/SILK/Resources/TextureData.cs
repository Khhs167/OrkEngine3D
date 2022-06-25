namespace OrkEngine3D.Graphics.SILK.Resources;

/// <summary>
/// The data of a texture, contains width, height and pixels
/// </summary>
public struct TextureData{
    /// <summary>
    /// Width of the texture
    /// </summary>
    public int width;

    /// <summary>
    /// Height of the texture
    /// </summary>
    public int height;

    /// <summary>
    /// Pixels in bytes, RGBA format
    /// </summary>
    public byte[] pixels;

    /// <summary>
    /// Generate a texture data struct
    /// </summary>
    /// <param name="width">The texture height</param>
    /// <param name="height">The tetxure width</param>
    /// <param name="pixels">The pixels in bytes, RGBA format</param>
    public TextureData(int width, int height, byte[] pixels){
        this.width = width;
        this.height = height;
        this.pixels = pixels;
    }
}