using AntiV.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AntiV
{
    public partial class Obstacle
    {

        private float _posX;
        private float _posY;
        private float _health;
        private bool _isBroken;

        // Constructeur
        public Obstacle(float posX, float posY)
        {
            _posX = posX;
            _posY = posY;
            _health = 3;
        }
        public float X
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public float Y
        {
            get { return _posY; }
            set { _posY = value; }
        }
        public float Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public bool IsBroken
        {
            get { return _isBroken; }
            set { _isBroken = value; }
        }



        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {

            foreach (Virus virus in AirSpace.viruses)
            {
                Rectangle obstacleRectange = new Rectangle((int)_posX, (int)_posY, OBSTACLE_WIDTH, OBSTACLE_HEIGHT);
                Rectangle virusRectangle = new Rectangle((int)virus.X, (int)virus.Y, Virus.VIRUS_WIDTH, Virus.VIRUS_HEIGHT);

                if (obstacleRectange.IntersectsWith(virusRectangle) && !virus.IsDead)
                {
                    _health -= 1;
                    virus.IsDead = true;
                    virus.Texture = Resources.explosion;
                    Console.WriteLine("Obstacle touchée");

                    if (_health <= 0)
                    {
                        _isBroken = true;
                        Console.WriteLine("Obstacle détruits ");
                    }

                }

            }


        }

    }
}
