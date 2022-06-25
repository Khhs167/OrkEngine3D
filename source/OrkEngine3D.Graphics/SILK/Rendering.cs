using OrkEngine3D.Components.Core;
using OrkEngine3D.Graphics.SILK.Resources;
using OrkEngine3D.Mathematics;

namespace OrkEngine3D.Graphics.SILK;



public static class Rendering
{
        public static void BindCamera(Camera camera)
        {
            
        }

        public static void BindContext(GraphicsContext ctx)
        {
            
        }

        public static void BindLightning(LightScene light)
        {
            
        }

        public static void BindMaterial(Material material)
        {
            
        }

        public static void BindMaterials(params Material[] materials)
        {
            
        }

        public static void BindTransform(Transform t)
        {
            
        }

        public static void BindTarget(ID id)
        {
            
        }

        public static void ResetTarget()
        {

        }

        public static void ClearTarget()
        {

        }

        public static void SwapBuffers()
        {

        }

        public static void Render(){

        }

        public static void BindRenderable(ID id){

        }

        public static void BindResourceManager(GLResourceManager manager){

        }

        public static ID CreateMesh()
        {
            return new ID();
        }

        public static ID UpdateMeshVerticies(ID id, Vector3[] verticies){
            return id;
        }

        public static ID UpdateMeshTriangles(ID id, uint[] triangles){
            return id;
        }

        public static ID UpdateMeshUVs(ID id, Vector2[] uv){
            return id;
        }

        public static ID UpdateMeshNormals(ID id, Vector3[] normals){
            return id;
        }

        public static ID UpdateMeshMaterials(ID id, int[] materials){
            return id;
        }

        public static ID UpdateMeshShader(ID id, ID shader){
            return id;
        }

        public static void UpdateMeshGLData(ID id){
        }

        public static ID CreateTexture(TextureData data){
            return new ID();
        }

        public static ID CreateShaderProgram(params ID[] shaders){

            return new ID();
        }

        public static ID CreateShader(string source, ShaderType type){
            return new ID();
        }

        public static ID CreateRenderBuffer(int width, int height){
            return new ID();
        }

        public static void EnableWireframe()
        {
        }
        
        public static void DisableWireframe()
        {
        }

        public static ID CreateShadowManager()
        {
            return new ID();
        }

        public static void BindShadowManager(ID id)
        {

        }

        public static void EnterShadowMode()
        {
        }

        public static void ExitShadowMode()
        {
        }
}