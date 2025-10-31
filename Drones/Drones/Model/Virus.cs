using AntiV.Properties;

namespace AntiV
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Virus
    {

        private int _health;                          
        private int _maxHealth = 5;                          
        private string _name;                         
        private float _posX;                               
        private float _posY;
        private bool _isDead = false;
        private float _speed= 0.3f;
        private Image _texture;

        // Constructeur
        public Virus(int posX, int posY, string name)
        {
            _posX = posX;
            _posY = posY;
            _health = 5;
            _name = name;
            _texture = Resources.virus;
            //_charge = GlobalHelpers.alea.Next(FULLCHARGE); // La charge initiale de la batterie est choisie aléatoirement
        }
        public Image Texture
        {
            get { return _texture; }
            set { _texture = value; }
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
        public bool IsDead { 
            get { return _isDead; }
            set { _isDead = value; }
        }
        public float Speed
        { 
            get { return _speed; }
            set { _speed = value; }
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval, AirSpace airSpace)
        {
            if (_posY < AirSpace.ENNEMIS_AREA_HEIGHT - VIRUS_HEIGHT)
            {
                _posY += _speed;
            }
            else
            {
                _texture = Resources.explosion;
                _posY = AirSpace.ENNEMIS_AREA_HEIGHT - VIRUS_HEIGHT;
                _isDead = true;

                airSpace.RemoveHealthToBarrer();

                Console.WriteLine($"{Name} a touché le bord et a explosé");
            }
        }



    }
}
