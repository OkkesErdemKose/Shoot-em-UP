namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Virus
    {

        private int _health;                          
        private string _name;                         
        private int _posX;                               
        private int _posY;

        // Constructeur
        public Virus(int posX, int posY, string name)
        {
            _posX = posX;
            _posY = posY;
            _name = name;
            //_charge = GlobalHelpers.alea.Next(FULLCHARGE); // La charge initiale de la batterie est choisie aléatoirement
        }
        public int X { get { return _posX; } }
        public int Y { get { return _posY; } }
        public string Name { get { return _name;} }



        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {


            if (!(_posY == AirSpace.ENNEMIS_AREA_HEIGHT - VIRUS_HEIGHT))
            {
                _posY += 1;
            }


        }


    }
}
