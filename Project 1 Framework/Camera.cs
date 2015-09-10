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
    /*
     * Glory Wiguno (690810) 
     * Graphics and Interactions Project1
     * A very simple and naive implementation of 
     * controlable camera. (In this current state)
     */
    public class Camera
    {   
        /*
         * Very simple implementation of moving camera;
         * still cant work as a proper 6-degree-of-freedom camera 
         * that is desired in the project spec;
         * it stil doesnt even work as a proper first person camera
         */
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
            this.Up =  new Vector3 (0,1,0);

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
                
                this.Position.Z += gameTime.ElapsedGameTime.Milliseconds * speed;
            }
            // Move backward
            if (game.keyboardState.IsKeyDown(Keys.S)){
                this.Position.Z -= gameTime.ElapsedGameTime.Milliseconds * speed;
               
            }


            // move right
            if (game.keyboardState.IsKeyDown(Keys.D)){
                this.Position.X -= gameTime.ElapsedGameTime.Milliseconds * speed;
                this.LookAt.X -= gameTime.ElapsedGameTime.Milliseconds * speed;
            }

            // move left
            if (game.keyboardState.IsKeyDown(Keys.A)){
                this.Position.X += gameTime.ElapsedGameTime.Milliseconds * speed;
                this.LookAt.X += gameTime.ElapsedGameTime.Milliseconds * speed;
            }



            // roll left
            if (game.keyboardState.IsKeyDown(Keys.Q)){
                this.Up.Z += gameTime.ElapsedGameTime.Milliseconds * speed;
            }

            // roll right
            if (game.keyboardState.IsKeyDown(Keys.E)){
                this.Up.Z -= gameTime.ElapsedGameTime.Milliseconds * speed;

            }


            
            // for yaw and pitch,
            // the camera movement is still a bit slow
            
            if (game.mouseState.X == 0){
                this.LookAt.X += gameTime.ElapsedGameTime.Milliseconds * speed;
            }
            if (game.mouseState.X == 1)
            {
                this.LookAt.X -= gameTime.ElapsedGameTime.Milliseconds * speed;
            }

            if (game.mouseState.Y ==1 ){
                this.LookAt.Y += gameTime.ElapsedGameTime.Milliseconds * speed;
                
            }
            if (game.mouseState.Y == 0)
            {
                this.LookAt.Y -= gameTime.ElapsedGameTime.Milliseconds * speed;
            }
            



            View = Matrix.LookAtLH(this.Position, this.LookAt, this.Up);
            
        }

    }



}
