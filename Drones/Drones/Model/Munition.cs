using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AntiV
{
    public partial class Munition
    {

        private int _posX;                               
        private int _posY;
        private int _ammoSpeed;

        // Constructeur
        public Munition(int posX, int posY, int ammoSpeed)
        {
            _posX = posX;
            _posY = posY;
            _ammoSpeed = ammoSpeed;
        }
        public int X { 
            get { return _posX; }
            set { _posX = value; }
        }
        public int Y { 
            get { return _posY; }
            set { _posY = value; }
        }
        public int AmmoSpeed
        {
            get { return _ammoSpeed; }
            set { _ammoSpeed = value; }
        }



        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            _posY -= 5;


        }

    }
}
