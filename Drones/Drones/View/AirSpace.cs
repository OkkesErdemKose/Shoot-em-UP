using AntiV.Helpers;
using System.Runtime.InteropServices;

namespace AntiV
{
    public partial class AirSpace : Form
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public static readonly int WIDTH = 1400;
        public static readonly int HEIGHT = 700;

        public int score = 0;

        public static int ENNEMIS_AREA_WIDTH = AirSpace.WIDTH - 300;
        public static int ENNEMIS_AREA_HEIGHT = AirSpace.HEIGHT - Antivirus.ANTIVIRUS_HEIGHT - 30;

        private List<Antivirus> fleet;
        private List<Virus> viruses;
        public List<Munition> munitions = new List<Munition>();

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        public AirSpace(List<Antivirus> fleet, List<Virus> virus, List<Munition> munitions)
        {
            InitializeComponent();
            currentContext = BufferedGraphicsManager.Current;
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            this.KeyPreview = true;

            this.fleet = fleet;
            this.viruses = virus;
            this.munitions = munitions;
        }

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
                    munitions.Add(new Munition(av.X + (Antivirus.ANTIVIRUS_HEIGHT / 2) - (Munition.MUNITION_HEIGHT / 2), av.Y, 10));
                }

                if ((GetAsyncKeyState((int)Keys.Escape) & 0x8000) != 0)
                    Close();
            }
        }

        private void Render()
        {
            airspace.Graphics.Clear(Color.GhostWhite);

            foreach (Antivirus av in fleet)
                av.Render(airspace);

            foreach (Virus virus in viruses)
            {
                if (!virus.IsDead)
                    virus.Render(airspace);
            }

            foreach (Munition mun in munitions)
                mun.Render(airspace);

            // Affichage du score
            airspace.Graphics.DrawString(
                $"Score : {score}",
                TextHelpers.drawFont,
                TextHelpers.writingBrush,
                10, 10
            );

            airspace.Render();
        }

        private void Update(int interval)
        {
            foreach (Antivirus av in fleet)
                av.Update(interval);

            foreach (Virus viru in viruses)
                viru.Update(interval);

            foreach (Munition mun in munitions)
                mun.Update(interval);

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
                            score += 10; 
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

        private void NewFrame(object sender, EventArgs e)
        {
            ticker.Interval = 1;

            DeplacementKeyState();
            this.Update(ticker.Interval);
            this.Render();
        }
    }
}
