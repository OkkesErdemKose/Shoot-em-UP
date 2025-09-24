

namespace Drones
{
    internal static class Program
    {

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


            List<Virus> virus = new List<Virus>();

            for (int i = 0; i < AirSpace.ENNEMIS_AREA_HEIGHT / Virus.VIRUS_HEIGHT + 1; i++)
            {
                virus.Add(new Virus(27 + (Virus.VIRUS_WIDTH + 100)  * i, 0, $"Virus.exe n°{i+1}"));

            }






            // Démarrage
            Application.Run(new AirSpace(fleet, virus));
        }
    }
}