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

        private float _posX;                               
        private float _posY;
        private float _ammoSpeed;

        // Constructeur
        public Munition(float posX, float posY, float ammoSpeed)
        {
            _posX = posX;
            _posY = posY;
            _ammoSpeed = ammoSpeed;
        }
        public float X { 
            get { return _posX; }
            set { _posX = value; }
        }
        public float Y { 
            get { return _posY; }
            set { _posY = value; }
        }
        public float AmmoSpeed
        {
            get { return _ammoSpeed; }
            set { _ammoSpeed = value; }
        }



        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            _posY -= _ammoSpeed;



        }

    }
}
