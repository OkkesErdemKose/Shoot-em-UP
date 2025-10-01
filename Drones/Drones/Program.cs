

namespace Drones
{
    internal static class Program
    {

        public static List<Ammo> ammo = new List<Ammo>();

        public static List<Virus> virus = new List<Virus>();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            // Création de la flotte de drones
            List<Drone> fleet = new List<Drone>();
            fleet.Add(new Drone(0, AirSpace.HEIGHT - (AirSpace.HEIGHT - AirSpace.ENNEMIS_AREA_HEIGHT - 20), "Antivirus"));


            //AirSpace.ENNEMIS_AREA_HEIGHT / Virus.VIRUS_HEIGHT + 1

            for (int i = 0; i < RandomHelpers.Rnd(2,5); i++)
            {
                virus.Add(new Virus(27 + (Virus.VIRUS_WIDTH + 100)  * i, 0, $"Virus.exe n°{i+1}"));


            }

            foreach (Virus v in virus)
            {
                Console.WriteLine($"{v.Name} - {v.Health}");

            }
            Console.WriteLine($"\n");






            // Démarrage
            Application.Run(new AirSpace(fleet, virus, ammo));
        }
    }
}