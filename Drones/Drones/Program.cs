

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
            fleet.Add(new Drone(0, AirSpace.HEIGHT - 100, "Antivirus"));


            List<Virus> virus = new List<Virus>();
            virus.Add(new Virus(0, 0, "Virus.exe"));




            // Démarrage
            Application.Run(new AirSpace(fleet, virus));
        }
    }
}