using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Input;

namespace Project1
{
    public class Camera
    {
        public Matrix View;
        public Matrix Projection;
        public Project1Game game;

        public Vector3 Position;
        public Vector3 LookAt;
        public Vector3 Up;

        private float speed = 0.006f;


        // Ensures that all objects are being rendered from a consistent viewpoint
        public Camera(Project1Game game)
        {
            this.Position = new Vector3(0, 0, -10);
            this.LookAt = new Vector3(0, 0, 0);
            this.Up =  Vector3.UnitY;

            View = Matrix.LookAtLH(this.Position, this.LookAt, this.Up);
            Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)game.GraphicsDevice.BackBuffer.Width / game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
            this.game = game;
        }

        
        public void Update()
        {   // update for projection
            Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)game.GraphicsDevice.BackBuffer.Width / game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
        }

        // 'update for lookat'
        public  void UpdatePoV(GameTime gameTime) { 
            
            // Move forward
            if (game.keyboardState.IsKeyDown(Keys.W)){
                Console.WriteLine("ataaaaaaaaaas");
                this.Position.Z += gameTime.ElapsedGameTime.Milliseconds * speed;
            }
            // Move backward
            if (game.keyboardState.IsKeyDown(Keys.S)){
                this.Position.Z -= gameTime.ElapsedGameTime.Milliseconds * speed;
                Console.WriteLine("bawah");
            }


            // move right
            if (game.keyboardState.IsKeyDown(Keys.D)){
                this.Position.X += gameTime.ElapsedGameTime.Milliseconds * speed;
                this.LookAt.X += gameTime.ElapsedGameTime.Milliseconds * speed;
            }

            // move left
            if (game.keyboardState.IsKeyDown(Keys.A)){
                this.Position.X -= gameTime.ElapsedGameTime.Milliseconds * speed;
                this.LookAt.X -= gameTime.ElapsedGameTime.Milliseconds * speed;
            }



            // roll left
            if (game.keyboardState.IsKeyDown(Keys.Q)){

            }

            // roll right
            if (game.keyboardState.IsKeyDown(Keys.E)){

            }





            /*
            // for yaaaaws
            // 
            if (game.keyboardState.IsKeyDown(){

            }

            if (game.keyboardState.IsKeyDown(){

            }
             */



            View = Matrix.LookAtLH(this.Position, this.LookAt, this.Up);
            
        }

    }



}
