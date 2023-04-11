using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunny_Generator
{
    internal class Bunny
    {
        Point _location;
        int _sX;
        int _sY;
        bool _hasMoved;
        ConsoleColor _bunnyColor;

        public Bunny(Point location)
        {
            Random rand = new Random();
            _location = location;
            _sX = rand.Next(-2, 3);

            do
            {
                _sY = rand.Next(-2, 3);

            } while (_sY == 0 && _sX == 0);

            int color = rand.Next(0, 16);
            _bunnyColor = (ConsoleColor)color;
        }

        public int X
        {
            get => _location.X;
        }

        public int Y
        {
            get => _location.Y;
        }
        public bool HasMoved { get => _hasMoved; }
        public ConsoleColor BunnyColor { get => _bunnyColor; set => _bunnyColor = value; }

        public void UpdateLocation()
        {
            _location += new Point(_sX, _sY);
            _hasMoved = true;
        }

        public void ClearMove()
        {
            _hasMoved = false;
        }
    }
}
