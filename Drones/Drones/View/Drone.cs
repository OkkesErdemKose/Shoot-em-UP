using Drones.Helpers;
using Drones.Properties;
using System.Resources;

namespace Drones
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Drone
    {
        private Image droneImage = Image.FromFile("./Resources/vaisseau.png");
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);
        public const int ANTIVIRUS_WIDTH = 150;
        public const int ANTIVIRUS_HEIGHT = 150;


        public bool showCheck = true;

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(droneImage, X, Y, ANTIVIRUS_WIDTH, ANTIVIRUS_HEIGHT) ;
            drawingSpace.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 3), 0, AirSpace.ENNEMIS_AREA_HEIGHT, AirSpace.WIDTH - ANTIVIRUS_WIDTH * 2, AirSpace.ENNEMIS_AREA_HEIGHT);
            drawingSpace.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 3), AirSpace.ENNEMIS_AREA_WIDTH, 0, AirSpace.ENNEMIS_AREA_WIDTH, AirSpace.HEIGHT);

            if (showCheck == true)
            {


                using (Pen pen = new Pen(Color.LightSkyBlue, 3))
                {
                    drawingSpace.Graphics.DrawRectangle(pen, AirSpace.WIDTH - 30, 0, 30, 30);
                    //drawingSpace.Graphics.DrawLine(pen, X + (ANTIVIRUS_WIDTH / 2), Y, 0, 0);
                    drawingSpace.Graphics.DrawRectangle(pen, X, Y, ANTIVIRUS_WIDTH, ANTIVIRUS_HEIGHT);

                    drawingSpace.Graphics.DrawLine(pen, X + ANTIVIRUS_HEIGHT / 2, 0, X + ANTIVIRUS_HEIGHT/2, AirSpace.HEIGHT - ANTIVIRUS_WIDTH/2);



                }

            }


            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, X, Y - 35);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name} \nX : {_posX} ; Y : {_posY}";
        }

    }
}
