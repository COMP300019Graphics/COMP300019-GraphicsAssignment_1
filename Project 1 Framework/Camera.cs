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

        private float speed = 0.005f;


        // Ensures that all objects are being rendered from a consistent viewpoint
        public Camera(Project1Game game)
        {   

            // position of the camera
            this.Position = new Vector3(0, 0, -10);
            // where the camera is looking at
            this.LookAt = new Vector3(0, 0, 10);
            // where the upside of the camera is facing
            this.Up =  Vector3.UnitY;

            View = Matrix.LookAtLH(this.Position, this.Position+this.LookAt, this.Up);
            Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)game.GraphicsDevice.BackBuffer.Width / game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
            this.game = game;
        }

        
       

        // 'update for lookat'
        public  void Update(GameTime gameTime) {
            // update for the projection
            Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)game.GraphicsDevice.BackBuffer.Width / game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);

            // update for camera movements and orientation based on 
            // keyboard and mouse input
            if (game.keyboardState.IsKeyDown(Keys.W))
                this.Position += Vector3.Normalize(this.LookAt - this.Position) * gameTime.ElapsedGameTime.Milliseconds * speed;
            if (game.keyboardState.IsKeyDown(Keys.S))
                this.Position -= Vector3.Normalize(this.LookAt - this.Position) * gameTime.ElapsedGameTime.Milliseconds * speed;

            if (game.keyboardState.IsKeyDown(Keys.A))
                this.Position -= Vector3.Normalize(Vector3.Cross(this.Up, this.LookAt)) * gameTime.ElapsedGameTime.Milliseconds *speed;
            if (game.keyboardState.IsKeyDown(Keys.D))
                this.Position += Vector3.Normalize(Vector3.Cross(this.Up, this.LookAt)) * gameTime.ElapsedGameTime.Milliseconds *speed;


           



            // Yaw rotation

            this.LookAt = Vector3.TransformCoordinate(this.LookAt,
                          Matrix.RotationAxis(this.Up, (float)(-Math.PI / 4) *
                          game.mouseState.DeltaX *
                          gameTime.ElapsedGameTime.Milliseconds * speed*10
                          ));


            // Pitch Rotation
           
            this.LookAt = Vector3.TransformCoordinate(this.LookAt,
                          Matrix.RotationAxis(Vector3.Cross(this.Up, this.LookAt),
                          (float)(-Math.PI / 4) * (game.mouseState.DeltaY) *
                          gameTime.ElapsedGameTime.Milliseconds * speed));
            


            this.Up = Vector3.TransformCoordinate(this.Up,
                      Matrix.RotationAxis(Vector3.Cross(this.Up, this.LookAt),
                      (float)(Math.PI / 4) * (game.mouseState.DeltaY) *
                      gameTime.ElapsedGameTime.Milliseconds * speed));
            
            

            // Roll rotation
            if (game.keyboardState.IsKeyDown(Keys.E))
            {
                this.Up = Vector3.TransformCoordinate(this.Up,
                    Matrix.RotationAxis(this.LookAt,
                    (float)(Math.PI /4) *speed));
            }
            if (game.keyboardState.IsKeyDown(Keys.Q))
            {
                this.Up = Vector3.TransformCoordinate(this.Up,
                    Matrix.RotationAxis(this.LookAt,
                    -(float)(Math.PI / 4)*speed ));
            }
            

            View = Matrix.LookAtLH(this.Position,this.Position+ this.LookAt, this.Up);
            
        }

    }



}
