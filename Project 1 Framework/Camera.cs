using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;
namespace Project1
{
    public class Camera
    {
        public Matrix View;
        public Matrix Projection;
        public Game game;
        public Vector3 cameraPos;
        public Vector3 cameraTarget;
        public Vector3 viewVector;

        // Ensures that all objects are being rendered from a consistent viewpoint
        public Camera(Game game) {
            
            cameraPos = new Vector3(0, 0, -10);
            cameraTarget = new Vector3(0, 0, -1000);
            View = Matrix.LookAtLH(cameraPos, cameraTarget, Vector3.UnitY);
            Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)game.GraphicsDevice.BackBuffer.Width / game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
            this.game = game;
        }

        // If the screen is resized, the projection matrix will change
        public void Update(GameTime gameTime)
        {
            Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)game.GraphicsDevice.BackBuffer.Width / game.GraphicsDevice.BackBuffer.Height, 10.0f, 100.0f);
            //View = Matrix.LookAtLH(new Vector3(1,1,10),new Vector3(1,1,1) , Vector3.UnitY);
            viewVector = cameraTarget - cameraPos;
        }
    }



    // if iskeyDown()
    //
    //




}
