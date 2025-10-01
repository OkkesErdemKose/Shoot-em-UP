using Drones.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drones.View
{
    public partial class Ammo
    {

        private Pen virusBrush = new Pen(new SolidBrush(Color.Purple), 3);
        private Pen blackPen = new Pen(new SolidBrush(Color.Black), 5);
        private Brush healthBrush = new SolidBrush(Color.Green);
        private Image virusImage = Image.FromFile("./Resources/virus.png");

        public const int VIRUS_WIDTH = 90;
        public const int VIRUS_HEIGHT = 90;

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(virusImage, _posX, _posY, VIRUS_WIDTH, VIRUS_HEIGHT);

            //drawingSpace.Graphics.DrawRectangle(virusBrush, _posX, _posY, VIRUS_WIDTH, VIRUS_HEIGHT);


            drawingSpace.Graphics.DrawRectangle(blackPen, _posX + VIRUS_WIDTH + 10, _posY, 10, VIRUS_HEIGHT);
            drawingSpace.Graphics.FillRectangle(healthBrush, _posX + VIRUS_WIDTH + 10, _posY, 10, VIRUS_HEIGHT);

            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFontH4, TextHelpers.writingBrush, X, Y - 35);

        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name} ";
            //return $"{Name} \nY : {_posY} ; X : {_posX}";
        }
    }
}
