

using System.Runtime.InteropServices;


namespace AntiV
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

        public int score;

        public static int ENNEMIS_AREA_WIDTH = AirSpace.WIDTH - 300;
        public static int ENNEMIS_AREA_HEIGHT = AirSpace.HEIGHT - Antivirus.ANTIVIRUS_HEIGHT - 30;

        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private List<Antivirus> fleet;
        private List<Virus> viruses;
        public List<Munition> munitions = new List<Munition>();

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public AirSpace(List<Antivirus> fleet, List<Virus> virus, List<Munition> munitions)
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
            this.viruses = virus;
            this.munitions = munitions;

        }

        //public void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    foreach (Drone drone in fleet)
        //    {
        //
        //
        //        if ((GetAsyncKeyState((int)Keys.Left) & 0x8000) != 0)
        //            drone.MoveLeft();
        //
        //        if ((GetAsyncKeyState((int)Keys.Right) & 0x8000) != 0)
        //            drone.MoveRight();
        //
        //        if ((GetAsyncKeyState((int)Keys.Escape) & 0x8000) != 0)
        //            Close();
        //
        //    }
        //}

        private void DeplacementKeyState()
        {
            foreach (Antivirus av in fleet)
            {
                if ((GetAsyncKeyState((int)Keys.Left) & 0x8000) != 0)
                    av.MoveLeft();

                if ((GetAsyncKeyState((int)Keys.Right) & 0x8000) != 0)
                    av.MoveRight();


                if ((GetAsyncKeyState((int)Keys.Space) & 0x101) != 0)
                {
                    munitions.Add(new Munition(av.X + (Antivirus.ANTIVIRUS_HEIGHT / 2) - (Munition.MUNITION_HEIGHT / 2), av.Y, 1));
                }



                if ((GetAsyncKeyState((int)Keys.Escape) & 0x8000) != 0)
                    Close();
            }
        }




        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.Clear(Color.GhostWhite);

            // draw drones
            foreach (Antivirus av in fleet)
            {
                av.Render(airspace);
            }

            foreach (Virus virus in viruses)
            {
                if(!virus.IsDead)
                {
                    virus.Render(airspace);

                }

            }

            foreach (Munition mun in munitions)
            {
                mun.Render(airspace);


            }



            airspace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (Antivirus av in fleet)
            {
                av.Update(interval);
            }

            foreach (Virus viru in viruses)
            {
                viru.Update(interval);
            }

            foreach (Munition mun in munitions)
            {
                mun.Update(interval);
            }

            List<Munition> munitionsToRemove = new List<Munition>();
            List<Virus> virusToRemove = new List<Virus>();

            foreach (Munition mun in munitions)
            {
                Rectangle munRect = new Rectangle(mun.X, mun.Y, Munition.MUNITION_WIDTH, Munition.MUNITION_HEIGHT);

                foreach (Virus virus in viruses)
                {
                    if (virus.IsDead) continue;

                    Rectangle virusRect = new Rectangle(virus.X, virus.Y, Virus.VIRUS_WIDTH, Virus.VIRUS_HEIGHT);

                    if (munRect.IntersectsWith(virusRect))
                    {
                        virus.Health -= 1; 
                        munitionsToRemove.Add(mun); 

                        if (virus.Health <= 0)
                        {
                            virus.IsDead = true;
                            virusToRemove.Add(virus);
                        }

                        break; 
                    }
                }
            }

            foreach (var m in munitionsToRemove)
                munitions.Remove(m);

            foreach (var v in virusToRemove)
                viruses.Remove(v);
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