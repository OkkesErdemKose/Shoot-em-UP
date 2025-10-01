using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public partial class Ammo
    {
        private int _x;
        private int _y;
        private int _width = 10;
        private int _heigth = 10;
        private bool _active = true; 

        private Brush _ammoBrush = new SolidBrush(Color.DeepSkyBlue);

    }
}
