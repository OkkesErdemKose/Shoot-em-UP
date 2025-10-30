namespace AntiV
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Virus
    {

        private int _health;                          
        private int _maxHealth = 5;                          
        private string _name;                         
        private int _posX;                               
        private int _posY;
        private bool _isDead = false;

        // Constructeur
        public Virus(int posX, int posY, string name)
        {
            _posX = posX;
            _posY = posY;
            _health = 5;
            _name = name;
            //_charge = GlobalHelpers.alea.Next(FULLCHARGE); // La charge initiale de la batterie est choisie aléatoirement
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }
        public int X
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public int Y { 
            get { return _posY; }
            set { _posY = value; }
        }
        public string Name { 
            get { return _name;}
            set { _name = value; }
        }
        public bool IsDead { 
            get { return _isDead; }
            set { _isDead = value; }
        }


        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {


            if (!(_posY == AirSpace.ENNEMIS_AREA_HEIGHT - VIRUS_HEIGHT))
            {
                _posY += 1;
            }
            else
            {
                _posY = AirSpace.ENNEMIS_AREA_HEIGHT - VIRUS_HEIGHT;
                _isDead = true;
                Console.WriteLine($"{Name} a touché le bord et à explosé");
            }




        }


    }
}
