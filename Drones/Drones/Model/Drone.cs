namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone
    {
        //public static readonly int FULLCHARGE = 100;   // Charge maximale de la batterie
        private int _charge;                            // La charge actuelle de la batterie
        private string _name;                           // Un nom
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        private int _vx;
        private int _vy;

        // Constructeur
        public Drone(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;
            //_charge = GlobalHelpers.alea.Next(FULLCHARGE); // La charge initiale de la batterie est choisie aléatoirement
        }
        public int X { get { return _x;} }
        public int Y { get { return _y;} }
        public int Vx { get { return _vx; } }
        public int Vy { get { return _vy; } }
        public string Name { get { return _name;} }

        public int deplacement = 1;

        public void MoveLeft() => _x -= deplacement;
        public void MoveRight() => _x += deplacement;

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            _x += Vx;
            _y += Vy;

            if (_x < 0)
            {
                _x = 0;
            }
            else if (_x > AirSpace.WIDTH - ANTIVIRUS_WIDTH * 3)
            {
                _x = AirSpace.WIDTH - ANTIVIRUS_WIDTH * 3;

            }

        }

    }
}
