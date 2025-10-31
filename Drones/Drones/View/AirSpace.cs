using AntiV.Helpers;
using AntiV.Properties;
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
        public int coins = 0;


        private int baseDamage = 2;

        private float damageMultiplier = 1.0f;

        private int damagePrice = 10;
        private int barrierPrice = 100;

        public int level = 1;
        public int kills = 0;
        public int shootCount = 0;
        public int ammo = 0;
        public float virusSpeed = 0.3f; 

        static public int barrerHealth = 1;

        public static int ENNEMIS_AREA_WIDTH = WIDTH - 300;
        public static int ENNEMIS_AREA_HEIGHT = HEIGHT - Antivirus.ANTIVIRUS_HEIGHT - 30;

        private List<Antivirus> fleet;
        private List<Virus> viruses;
        public List<Munition> munitions = new List<Munition>();

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        private bool qDownPrev = false;
        private bool wDownPrev = false;

        private DateTime startTime;

        public AirSpace(List<Antivirus> fleet, List<Virus> virus, List<Munition> munitions)
        {
            InitializeComponent();
            currentContext = BufferedGraphicsManager.Current;
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.KeyPreview = true;

            this.fleet = fleet;
            this.viruses = virus;
            this.munitions = munitions;

            startTime = DateTime.Now;
        }

        private void DeplacementKeyState()
        {
            foreach (Antivirus av in fleet)
            {
                if ((GetAsyncKeyState((int)Keys.Left) & 0x8000) != 0)
                    av.MoveLeft();

                if ((GetAsyncKeyState((int)Keys.Right) & 0x8000) != 0)
                    av.MoveRight();

                if ((GetAsyncKeyState((int)Keys.Space) & 0x8000) != 0)
                {
                    munitions.Add(new Munition(av.X + (Antivirus.ANTIVIRUS_HEIGHT / 2) - (Munition.MUNITION_HEIGHT / 2), av.Y, 10));


                }


                if ((GetAsyncKeyState((int)Keys.Escape) & 0x8000) != 0)
                    Close();
            }


            bool qDown = (GetAsyncKeyState((int)Keys.Q) & 0x8000) != 0;
            if (qDown && !qDownPrev)
                BuyDamageBonus();
            qDownPrev = qDown;

            bool wDown = (GetAsyncKeyState((int)Keys.W) & 0x8000) != 0;
            if (wDown && !wDownPrev)
                BuyBarrierBonus();
            wDownPrev = wDown;
        }

        private void BuyDamageBonus()
        {
            if (coins >= damagePrice)
            {
                coins -= damagePrice;
                damageMultiplier += 2.3f;

                int augmentePrice = (int)(damagePrice * 0.15f) + (level * 3);
                damagePrice += Math.Max(1, augmentePrice);
            }
        }

        private void BuyBarrierBonus()
        {
            if (coins >= barrierPrice)
            {
                coins -= barrierPrice;
                barrerHealth += 1;

                int augmentePrice = (int)(barrierPrice * 0.5f) + (level * 20);
                barrierPrice += Math.Max(1, augmentePrice);
            }
        }

        private int munitionsDamage => (int)(baseDamage * damageMultiplier);

        private void Render()
        {
            airspace.Graphics.Clear(Color.GhostWhite);

            foreach (Antivirus av in fleet)
                av.Render(airspace);

            foreach (Virus virus in viruses)
                if (!virus.IsDead)
                    virus.Render(airspace);

            foreach (Munition mun in munitions)
                mun.Render(airspace);

            int rightPanelX = ENNEMIS_AREA_WIDTH + 10;

            Rectangle bonusRect1 = new Rectangle(rightPanelX + 50, HEIGHT - 600, 180, 80);
            airspace.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), bonusRect1);
            airspace.Graphics.DrawRectangle(Pens.Gray, bonusRect1);

            airspace.Graphics.DrawString($"Prix : {damagePrice}", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX + 60, HEIGHT - 590);
            airspace.Graphics.DrawString($"x{damageMultiplier:F1}", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX + 180, HEIGHT - 590);
            airspace.Graphics.DrawString($"Dégâts : {munitionsDamage}", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX + 60, HEIGHT - 560);
            airspace.Graphics.DrawString("[Q]", TextHelpers.h4, TextHelpers.writingBrush, rightPanelX + 190, HEIGHT - 540);

            Rectangle bonusRect2 = new Rectangle(rightPanelX + 50, HEIGHT - 500, 180, 80);
            airspace.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), bonusRect2);
            airspace.Graphics.DrawRectangle(Pens.Gray, bonusRect2);

            airspace.Graphics.DrawString($"Prix : {barrierPrice}", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX + 60, HEIGHT - 490);
            airspace.Graphics.DrawString($"+1 vie", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX + 180, HEIGHT - 490);
            airspace.Graphics.DrawString($"Barrière", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX + 60, HEIGHT - 460);
            airspace.Graphics.DrawString("[W]", TextHelpers.h4, TextHelpers.writingBrush, rightPanelX + 190, HEIGHT - 440);

            airspace.Graphics.DrawString($"Compteurs", TextHelpers.h1, TextHelpers.writingBrush, rightPanelX, HEIGHT - 320);
            airspace.Graphics.DrawString($"Niveau :                 {level}", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX, HEIGHT - 260);
            airspace.Graphics.DrawString($"Éliminées :             {kills}", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX, HEIGHT - 230);
            airspace.Graphics.DrawString($"Vie du barrière :      {barrerHealth}", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX, HEIGHT - 200);
            airspace.Graphics.DrawString($"Coins : {coins}", TextHelpers.h1, TextHelpers.writingBrush, rightPanelX, HEIGHT - 140);
            airspace.Graphics.DrawString($"Score : {score}", TextHelpers.h1, TextHelpers.writingBrush, rightPanelX, HEIGHT - 70);

            TimeSpan elapsed = DateTime.Now - startTime;  
            string elapsedStr = string.Format("{0:D2}:{1:D2}:{2:D2}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
            airspace.Graphics.DrawString($"Temps de jeux : {elapsedStr}", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX, 15);
            airspace.Graphics.DrawString($"Dégats actuel : {munitionsDamage}", TextHelpers.h3, TextHelpers.writingBrush, rightPanelX, 40);

            airspace.Render();
        }

        private void Update(int interval)
        {
            foreach (Antivirus av in fleet)
                av.Update(interval);

            foreach (Virus viru in viruses)
            {
                if (!viru.IsDead)
                    viru.Update(interval, this);
            }

            foreach (Munition mun in munitions)
                mun.Update(interval);

            List<Munition> munitionsToRemove = new List<Munition>();
            List<Virus> virusToRemove = new List<Virus>();

            foreach (Munition mun in munitions)
            {
                Rectangle munRect = new Rectangle((int)mun.X, (int)mun.Y, Munition.MUNITION_WIDTH, Munition.MUNITION_HEIGHT);

                foreach (Virus virus in viruses)
                {
                    if (virus.IsDead) continue;

                    Rectangle virusRect = new Rectangle((int)virus.X, (int)virus.Y, Virus.VIRUS_WIDTH, Virus.VIRUS_HEIGHT);

                    if (munRect.IntersectsWith(virusRect))
                    {
                        virus.Health -= munitionsDamage;
                        munitionsToRemove.Add(mun);

                        if (virus.Health <= 0)
                        {
                            virus.IsDead = true;
                            virusToRemove.Add(virus);

                            score += RandomHelpers.Rnd(7, 14);
                            coins += RandomHelpers.Rnd(3, 7);
                            kills++;
                        }

                        break;
                    }
                }
            }

            foreach (var m in munitionsToRemove)
                munitions.Remove(m);

            foreach (var v in virusToRemove)
            {
                v.Texture = Resources.explosion;
                viruses.Remove(v);
            }

            if (viruses.All(v => v.IsDead))
                NextLevel();
        }

        public void RemoveHealthToBarrer()
        {
            barrerHealth--;

            if (barrerHealth <= 0)
            {
                barrerHealth = 0;
                ticker.Stop();
                MessageBox.Show("La barrière s'est cassée, le jeu est finis !");
                Application.Exit();
            }
        }

        private void NextLevel()
        {
            level++;
            barrerHealth += 1;
            int newVirusCount = RandomHelpers.Rnd(4, 20);
            int newMaxHealth = 5 + level;
            virusSpeed += 0.1f;

            viruses.Clear();

            for (int i = 0; i < newVirusCount; i++)
            {
                int x = RandomHelpers.Rnd(0, ENNEMIS_AREA_WIDTH - Virus.VIRUS_WIDTH);
                int y = RandomHelpers.Rnd(0, 100);

                Virus newVirus = new Virus(x, y, $"Virus.exe n°{i + 1}")
                {
                    MaxHealth = newMaxHealth,
                    Health = newMaxHealth
                };
                newVirus.Speed = virusSpeed;
                viruses.Add(newVirus);
            }
        }

        private void NewFrame(object sender, EventArgs e)
        {
            ticker.Interval = 1;

            DeplacementKeyState();
            Update(ticker.Interval);
            Render();
        }
    }
}
