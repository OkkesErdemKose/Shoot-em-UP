using AntiV.Helpers;
using AntiV.Properties;
using System.Drawing;

namespace AntiV
{
    public partial class Obstacle
    {
        private Image _obstacleImage = Resources.pare_feu;

        public const int OBSTACLE_WIDTH = 100;
        public const int OBSTACLE_HEIGHT = 100;


        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(_obstacleImage, X, Y, OBSTACLE_WIDTH, OBSTACLE_HEIGHT);


            for (int i = 0; i < Health; i++)
            {
                float rectX = X + i * (25 + 5) + 10; 
                float rectY = Y + OBSTACLE_HEIGHT -10;            

                drawingSpace.Graphics.FillRectangle(Brushes.LimeGreen, rectX, rectY, 25, 10);
                drawingSpace.Graphics.DrawRectangle(Pens.Black, rectX, rectY, 25, 10);
            }
        }
    }
}
