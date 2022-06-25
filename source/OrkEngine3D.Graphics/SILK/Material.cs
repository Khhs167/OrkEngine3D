using OrkEngine3D.Graphics.SILK.Resources;
using OrkEngine3D.Mathematics;

namespace OrkEngine3D.Graphics.SILK;

public class Material
{
    public Color3 ambient = new Color3(1.0f, 1.0f, 1.0f);
    public Color3 diffuse = new Color3(1.0f, 1.0f, 1.0f);
    public Color3 specular = new Color3(1.0f, 1.0f, 1.0f);
    public float shininess = 64f;
    public ID[] textures = new ID[0];
}