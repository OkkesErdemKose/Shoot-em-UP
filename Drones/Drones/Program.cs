

namespace AntiV
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
            List<Antivirus> fleet = new List<Antivirus>();
            fleet.Add(new Antivirus(0, AirSpace.HEIGHT - (AirSpace.HEIGHT - AirSpace.ENNEMIS_AREA_HEIGHT - 20), "Antivirus"));
	 		
            List<Virus> virus = new List<Virus>();
	        List<Munition> munitions = new List<Munition>();

            //AirSpace.ENNEMIS_AREA_HEIGHT / Virus.VIRUS_HEIGHT + 1

            for (int i = 0; i < RandomHelpers.Rnd(2,4); i++)
            {
                virus.Add(new Virus(27 + (Virus.VIRUS_WIDTH + 100)  * i, 0, $"Virus.exe n°{i+1}"));

            }

            // Démarrage
            Application.Run(new AirSpace(fleet, virus, munitions));
        }
    }
}
