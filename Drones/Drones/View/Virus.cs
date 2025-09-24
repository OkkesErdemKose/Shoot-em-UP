using Drones.Helpers;

namespace Drones
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Virus
    {

        private Image virusImage = Image.FromFile("./Resources/virus.png");

        public const int VIRUS_WIDTH = 90;
        public const int VIRUS_HEIGHT = 90;

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(virusImage, _posX, _posY, VIRUS_WIDTH, VIRUS_HEIGHT);

            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, X, Y - 35);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name} \nY : {_posY} ; X : {_posX}";
        }

    }
}
