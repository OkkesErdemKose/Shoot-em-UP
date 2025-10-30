using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AntiV
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var fleet = InitializeFleet();
            var virus = GenerateViruses(RandomHelpers.Rnd(5, 7));
            var munitions = new List<Munition>();

            Application.Run(new AirSpace(fleet, virus, munitions));
        }

        private static List<Antivirus> InitializeFleet()
        {
            var fleet = new List<Antivirus>
            {
                new Antivirus(0, AirSpace.HEIGHT - (AirSpace.HEIGHT - AirSpace.ENNEMIS_AREA_HEIGHT - 20), "Antivirus")
            };

            return fleet;
        }

        private static List<Virus> GenerateViruses(int virusCount)
        {
            var virusList = new List<Virus>();

            for (int i = 0; i < virusCount; i++)
            {
                int x = RandomHelpers.Rnd(0, AirSpace.ENNEMIS_AREA_WIDTH - Virus.VIRUS_WIDTH);
                int y = RandomHelpers.Rnd(0, 100);

                virusList.Add(new Virus(x, y, $"Virus.exe n°{i + 1}"));
            }

            return virusList;
        }
    }
}
