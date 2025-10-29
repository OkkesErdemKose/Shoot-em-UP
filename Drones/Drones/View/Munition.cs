using AntiV.Helpers;
using AntiV.Properties;


namespace AntiV
{
    public partial class Munition
    {
        private Image munImage = Resources.munition;

        private Pen rectangleBrush = new Pen(new SolidBrush(Color.Purple), 3);

        public const int MUNITION_WIDTH = 30;
        public const int MUNITION_HEIGHT = 30;

        public bool isIntersects = false;

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(munImage, _posX, _posY, MUNITION_WIDTH, MUNITION_HEIGHT);

            Rectangle munitionRectangle = new Rectangle(_posX, _posY, MUNITION_WIDTH, MUNITION_HEIGHT);

            drawingSpace.Graphics.DrawRectangle(rectangleBrush, munitionRectangle);      
            


            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, X, Y - 35);
        }

        public bool IsIntersects()
        {
            return isIntersects;
        }

    }
}
