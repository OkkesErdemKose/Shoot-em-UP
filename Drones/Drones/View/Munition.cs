using AntiV.Helpers;
using AntiV.Properties;


namespace AntiV
{
    public partial class Munition
    {
        private Image munImage = Resources.munition;

        public const int MUNITION_WIDTH = 30;
        public const int MUNITION_HEIGHT = 30;

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(munImage, _posX, _posY, MUNITION_WIDTH, MUNITION_HEIGHT);



            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, X, Y - 35);
        }

    }
}
