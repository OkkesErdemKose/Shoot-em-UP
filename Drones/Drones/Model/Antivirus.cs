namespace AntiV
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Antivirus
    {
        //public static readonly int FULLCHARGE = 100;   // Charge maximale de la batterie
        private int _charge;                            // La charge actuelle de la batterie
        private string _name;                           // Un nom
        private float _posX;                                 // Position en X depuis la gauche de l'espace aérien
        private float _posY;                                 // Position en Y depuis le haut de l'espace aérien
        private int _vitesse;                                 // Vitesse de déplacement
        private int _coins;

        // Constructeur
        public Antivirus(float posX, float posY, string name)
        {
            _posX = posX;
            _posY = posY;
            _name = name;
            _vitesse = 15;
            //_charge = GlobalHelpers.alea.Next(FULLCHARGE); // La charge initiale de la batterie est choisie aléatoirement
        }
        public float X
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public float Y {
            get { return _posY; } 
            set { _posY = value; }
        }
        public string Name { 
            get { return _name;}
            set { _name = value; }
        }


        public void MoveLeft() => _posX -= _vitesse;
        public void MoveRight() => _posX += _vitesse;

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
