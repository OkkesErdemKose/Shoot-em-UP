namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone
    {
        //public static readonly int FULLCHARGE = 100;   // Charge maximale de la batterie
        private int _charge;                            // La charge actuelle de la batterie
        private string _name;                           // Un nom
        private int _posX;                                 // Position en X depuis la gauche de l'espace aérien
        private int _posY;                                 // Position en Y depuis le haut de l'espace aérien


        // Constructeur
        public Drone(int posX, int posY, string name)
        {
            _posX = posX;
            _posY = posY;
            _name = name;
            //_charge = GlobalHelpers.alea.Next(FULLCHARGE); // La charge initiale de la batterie est choisie aléatoirement
        }
        public int X { get { return _posX; } }
        public int Y { get { return _posY; } }
        public string Name { get { return _name;} }

        public int deplacement = 10;

        public void MoveLeft() => _posX -= deplacement;
        public void MoveRight() => _posX += deplacement;

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            if (_posX < 0)
            {
                _posX = 0;
            }
            else if (_posX > AirSpace.WIDTH - ANTIVIRUS_WIDTH * 3)
            {
                _posX = AirSpace.WIDTH - ANTIVIRUS_WIDTH * 3;

            }

        }

    }
}
