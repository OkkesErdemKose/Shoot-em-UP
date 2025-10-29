using AntiV.Helpers;
using AntiV.Properties;

namespace AntiV
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Virus
    {

        private Pen virusBrush = new Pen(new SolidBrush(Color.Purple), 3);
        private Pen virusHealthBrushRectangle = new Pen(new SolidBrush(Color.Black), 1);
        private Brush virusHealthBrush = new SolidBrush(Color.Green);
        private Image virusImage = Resources.virus;

        public const int VIRUS_WIDTH = 90;
        public const int VIRUS_HEIGHT = 90;

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(virusImage, _posX, _posY, VIRUS_WIDTH, VIRUS_HEIGHT);

            // drawingSpace.Graphics.DrawRectangle(virusBrush, _posX, _posY, VIRUS_WIDTH, VIRUS_HEIGHT);

            drawingSpace.Graphics.FillRectangle(virusHealthBrush, _posX + VIRUS_WIDTH + (VIRUS_WIDTH /2) - 30, _posY, 7, VIRUS_HEIGHT);
            drawingSpace.Graphics.DrawRectangle(virusHealthBrushRectangle, _posX + VIRUS_WIDTH + (VIRUS_WIDTH / 2) - 30, _posY, 7, VIRUS_HEIGHT);


            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, X, Y - 35);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name} \nY : {_posY} ; X : {_posX}";
        }

    }
}
