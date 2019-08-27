using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class player
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public int collideBlock;
        public int collideIndex;

        public player(Texture2D playerTexture, Vector2 playerPosition)
        {
            texture = playerTexture;
            position = playerPosition;
        }

        public bool IsColliding(Vector2 nextPosition, Board Board)
        {
            float rightX = nextPosition.X + 32;
            float leftX = nextPosition.X;
            float bottomY = nextPosition.Y + 32;
            float topY = nextPosition.Y;
            for (int i = 0; i < Board.Blocks.Count; i++)
            {
                float rightEdge = 250 + Board.Blocks[i].X * 32 + 32;
                float leftEdge = 250 + Board.Blocks[i].X * 32;
                float bottomEdge = 200 + (24 - Board.Blocks[i].Y) * 32;
                float topEdge = 200 + (24 - Board.Blocks[i].Y) * 32 - 32;
                if (rightX <= leftEdge || leftX >= rightEdge || bottomY <= topEdge || topY >= bottomEdge)
                {
                    int check = i + 1;
                }
                else
                {
                    collideBlock = i;
                    return true;
                }
            }
            return false;
        }

        public bool TopColliding(float playerX, float playerY, Board Board)
        {
            for (int i = 0; i < Board.Blocks.Count; i++)
            {
                float topY = playerY;
                float leftX = playerX;
                float rightX = playerX + 32;
                float rightEdge = 250 + Board.Blocks[i].X * 32 + 32;
                float leftEdge = 250 + Board.Blocks[i].X * 32;
                float bottomEdge = 200 + (24 - Board.Blocks[i].Y) * 32;
                // Console.WriteLine("{0},{1}", playerY, bottomEdge);
                if ((topY == bottomEdge && leftX >= leftEdge && leftX <= rightEdge) || (topY == bottomEdge && rightX >= leftEdge && rightX <= rightEdge))
                {
                    collideIndex = i;
                    return true;
                }
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position1)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

