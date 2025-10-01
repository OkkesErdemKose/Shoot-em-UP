

using Drones.Helpers;
using System.Runtime.InteropServices;

namespace Drones
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient



    public partial class AirSpace : Form
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);


        public static readonly int WIDTH = 1400;        // Dimensions of the airspace
        public static readonly int HEIGHT = 700;


        public static int ENNEMIS_AREA_WIDTH = AirSpace.WIDTH - 300;
        public static int ENNEMIS_AREA_HEIGHT = AirSpace.HEIGHT - Drone.ANTIVIRUS_HEIGHT - 30;

        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private List<Drone> fleet;
        private List<Virus> virus;
        private List<Ammo> ammo;

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        public static int ENNEMIS_AREA_WEIGHT { get; internal set; }

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public AirSpace(List<Drone> fleet, List<Virus> virus, List<Ammo> ammo)
        {
            InitializeComponent();
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.

            this.KeyPreview = true; // Ensures the form captures key events before child controls
            //this.KeyDown += Form1_KeyDown;

            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.fleet = fleet;
            this.virus = virus;
            
        }


        private void DeplacementKeyState()
        {
            foreach (Drone drone in fleet)
            {
                if ((GetAsyncKeyState((int)Keys.Left) & 0x8000) != 0)
                    drone.MoveLeft();

                if ((GetAsyncKeyState((int)Keys.Right) & 0x8000) != 0)
                    drone.MoveRight();

               if ((GetAsyncKeyState((int)Keys.Enter) & 0x101) != 0)
                {
                    continue;
                }

                if ((GetAsyncKeyState((int)Keys.Escape) & 0x8000) != 0)
                    continue;
            }
        }




        // Affichage de la situation actuelle
        private void Render()
        {
            Pen brushBlack = new Pen(new SolidBrush(Color.Black), 3);
            airspace.Graphics.Clear(Color.GhostWhite);

            airspace.Graphics.DrawString($"Bonus", TextHelpers.drawFontH1, TextHelpers.writingBrush, (AirSpace.ENNEMIS_AREA_WIDTH + AirSpace.WIDTH) / 2 - 50, 30);

            airspace.Graphics.DrawRectangle(brushBlack, (AirSpace.ENNEMIS_AREA_WIDTH + AirSpace.WIDTH) / 2 - 100, 100, 200, 60);

            airspace.Graphics.DrawRectangle(brushBlack, (AirSpace.ENNEMIS_AREA_WIDTH + AirSpace.WIDTH) / 2 - 100, 210, 200, 60);

            airspace.Graphics.DrawRectangle(brushBlack, (AirSpace.ENNEMIS_AREA_WIDTH + AirSpace.WIDTH) / 2 - 100, 320, 200, 60);



            airspace.Graphics.DrawString($"Score", TextHelpers.drawFontH2, TextHelpers.writingBrush, AirSpace.ENNEMIS_AREA_WIDTH + 20, 30);


            //airspace.Graphics.DrawString($"Nombre de virus : {Program.virus.Count}", TextHelpers.drawFont2, TextHelpers.writingBrush, AirSpace.ENNEMIS_AREA_WIDTH + 30, 30);

            // draw drones
            foreach (Drone drone in fleet)
            {
                drone.Render(airspace);
            }

            foreach (Virus virus in virus)
            {
                if(!virus.IsDead)
                {
                    virus.Render(airspace);


                }

            }

            foreach (Ammo ammo in ammo)
            {
                ammo.Render(airspace);
            }

        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (Drone drone in fleet)
            {
                drone.Update(interval);
            }
            foreach (Virus virus in virus)
            {
                virus.Update(interval);
            }
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            ticker.Interval = 1;

            DeplacementKeyState();
            this.Update(ticker.Interval);
            this.Render();
        }
    }
}