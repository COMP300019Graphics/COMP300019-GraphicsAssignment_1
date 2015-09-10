using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Toolkit;


namespace Project1
{
    using SharpDX.Toolkit.Graphics;
    public class Landscape : ColoredGameObject
    {   
        public Camera camera;
        public Landscape(Game game, Camera camera)
        {   // added camera class here, since the Landscape
            // somehow still inherits Game eventhough
            // i tried to change the parameter from constructor 
            // from Game into Project1Game
            
            Vector3 frontBottomLeft = new Vector3(-1.0f, -1.0f, -1.0f);
            Vector3 frontTopLeft = new Vector3(-1.0f, 1.0f, -1.0f);
            Vector3 frontTopRight = new Vector3(1.0f, 1.0f, -1.0f);
            Vector3 frontBottomRight = new Vector3(1.0f, -1.0f, -1.0f);
            Vector3 backBottomLeft = new Vector3(-1.0f, -1.0f, 1.0f);
            Vector3 backBottomRight = new Vector3(1.0f, -1.0f, 1.0f);
            Vector3 backTopLeft = new Vector3(-1.0f, 1.0f, 1.0f);
            Vector3 backTopRight = new Vector3(1.0f, 1.0f, 1.0f);

            Vector3 frontBottomLeftNormal = new Vector3(-0.333f, -0.333f, -0.333f);
            Vector3 frontTopLeftNormal = new Vector3(-0.333f, 0.333f, -0.333f);
            Vector3 frontTopRightNormal = new Vector3(0.333f, 0.333f, -0.333f);
            Vector3 frontBottomRightNormal = new Vector3(0.333f, -0.333f, -0.333f);
            Vector3 backBottomLeftNormal = new Vector3(-0.333f, -0.333f, 0.333f);
            Vector3 backBottomRightNormal = new Vector3(0.333f, -0.333f, 0.333f);
            Vector3 backTopLeftNormal = new Vector3(-0.333f, 0.333f, 0.333f);
            Vector3 backTopRightNormal = new Vector3(0.333f, 0.333f, 0.333f);

            vertices = Buffer.Vertex.New(
                            game.GraphicsDevice,
                            new[]
                    {
                    new VertexPositionNormalColor(frontBottomLeft, frontBottomLeftNormal, Color.Orange), // Front
                    new VertexPositionNormalColor(frontTopLeft, frontTopLeftNormal, Color.Orange),
                    new VertexPositionNormalColor(frontTopRight, frontTopRightNormal, Color.Orange),
                    new VertexPositionNormalColor(frontBottomLeft, frontBottomLeftNormal, Color.Orange),
                    new VertexPositionNormalColor(frontTopRight, frontTopRightNormal, Color.Orange),
                    new VertexPositionNormalColor(frontBottomRight, frontBottomRightNormal, Color.Orange),
                    new VertexPositionNormalColor(backBottomLeft, backBottomLeftNormal, Color.Blue), // BACK
                    new VertexPositionNormalColor(backTopRight, backTopRightNormal, Color.Blue),
                    new VertexPositionNormalColor(backTopLeft, backTopLeftNormal, Color.Blue),
                    new VertexPositionNormalColor(backBottomLeft, backBottomLeftNormal, Color.Blue),
                    new VertexPositionNormalColor(backBottomRight, backBottomRightNormal, Color.Blue),
                    new VertexPositionNormalColor(backTopRight, backTopRightNormal, Color.Blue),
                    new VertexPositionNormalColor(frontTopLeft, frontTopLeftNormal, Color.OrangeRed), // Top
                    new VertexPositionNormalColor(backTopLeft, backTopLeftNormal, Color.OrangeRed),
                    new VertexPositionNormalColor(backTopRight, backTopRightNormal, Color.OrangeRed),
                    new VertexPositionNormalColor(frontTopLeft, frontTopLeftNormal, Color.OrangeRed),
                    new VertexPositionNormalColor(backTopRight, backTopRightNormal, Color.OrangeRed),
                    new VertexPositionNormalColor(frontTopRight, frontTopRightNormal, Color.OrangeRed),
                    new VertexPositionNormalColor(frontBottomLeft, frontBottomLeftNormal, Color.Red), // Bottom
                    new VertexPositionNormalColor(backBottomRight, backBottomRightNormal, Color.Red),
                    new VertexPositionNormalColor(backBottomLeft, backBottomLeftNormal, Color.Red),
                    new VertexPositionNormalColor(frontBottomLeft, frontBottomLeftNormal, Color.Red),
                    new VertexPositionNormalColor(frontBottomRight, frontBottomRightNormal, Color.Red),
                    new VertexPositionNormalColor(backBottomRight, backBottomRightNormal, Color.Red),
                    new VertexPositionNormalColor(frontBottomLeft, frontBottomLeftNormal, Color.Green), // Left
                    new VertexPositionNormalColor(backBottomLeft, backBottomLeftNormal, Color.Green),
                    new VertexPositionNormalColor(backTopLeft, backTopLeftNormal, Color.Green),
                    new VertexPositionNormalColor(frontBottomLeft, frontBottomLeftNormal, Color.Green),
                    new VertexPositionNormalColor(backTopLeft, backTopLeftNormal, Color.Green),
                    new VertexPositionNormalColor(frontTopLeft, frontTopLeftNormal, Color.Green),
                    new VertexPositionNormalColor(frontBottomRight, frontBottomRightNormal, Color.White), // Right
                    new VertexPositionNormalColor(backTopRight, backTopRightNormal, Color.White),
                    new VertexPositionNormalColor(backBottomRight, backBottomRightNormal, Color.White),
                    new VertexPositionNormalColor(frontBottomRight, frontBottomRightNormal, Color.White),
                    new VertexPositionNormalColor(frontTopRight, frontTopRightNormal, Color.White),
                    new VertexPositionNormalColor(backTopRight, backTopRightNormal, Color.White),
                });

            basicEffect = new BasicEffect(game.GraphicsDevice)
            {
                VertexColorEnabled = true,
                View = camera.View,
                Projection = camera.Projection,
                World = Matrix.Identity
            };

            inputLayout = VertexInputLayout.FromBuffer(0, vertices);
            this.game = game;
            this.camera = camera;
        }



        public override void Update(GameTime gameTime)
        {   
            // update, not sure if it is the right way
            basicEffect.View = this.camera.View;
        }

        public override void Draw(GameTime gameTime)
        {
            // Setup the vertices
            game.GraphicsDevice.SetVertexBuffer(vertices);
            game.GraphicsDevice.SetVertexInputLayout(inputLayout);

            // Apply the basic effect technique and draw the rotating cube
            basicEffect.CurrentTechnique.Passes[0].Apply();
            game.GraphicsDevice.Draw(PrimitiveType.TriangleList, vertices.ElementCount);
        }
    }
}
