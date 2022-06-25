using OrkEngine3D.Components.Core;
using OrkEngine3D.Diagnostics.Logging;
using OrkEngine3D.Graphics.MeshData;
using OrkEngine3D.Graphics.SILK;

namespace OrkEngine3D.Graphics.Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            Logger logger = new Logger("MainLogger", "NoModule");
            logger.Log(LogMessageType.DEBUG, "Teapot");

            GraphicsContext ctx = new GraphicsContext("Hello World", new TestHandler());
            ctx.Run();
        }
    }

    class TestHandler : GraphicsHandler
    {
        Logger logger = new Logger("GraphicsTest", "TestHandler");

        public override void Init()
        {
        }

        public override void Render()
        {
            
        }

        public override void Update()
        {
           
        }

        public override void Resize()
        {
            logger.Log(LogMessageType.INFORMATION, "Resize event");
        }

        public override void Unload()
        {
            logger.Log(LogMessageType.INFORMATION, "Unload event");
        }
    }
}
