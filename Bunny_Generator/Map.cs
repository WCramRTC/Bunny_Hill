using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunny_Generator
{
    internal class Map
    {
        Bunny[,] _map;
        int _height;
        int _width;

        int _centerX;
        int _centerY;

        ConsoleColor original;

        public Map(int height, int width)
        {
            _height = height;
            _width = width;
            _centerX = _width / 2;
            _centerY = _height / 2;
            _map = new Bunny[height, width];

            original = ConsoleColor.Green;
        }

        public void DisplayMap()
        {
            Console.Clear();
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i,j] != null)
                    {
                        Bunny b = _map[i, j];
                        Console.ForegroundColor = b.BunnyColor;
                        Console.Write("V");
                        Console.ForegroundColor = original;
                    }
                    else
                    {
                        Console.Write("w");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        private Point Origin
        {
            get => new Point(_centerX, _centerY);
        }

        public void GenerateBunny()
        {
            if (_map[_centerY, _centerX] == null)
            {
                Bunny b = new Bunny(Origin);
                _map[_centerY, _centerX] = b;
            }
            
        }

        public void UpdateMap()
        {

            for (int y  = 0; y < _map.GetLength(0); y++)
            {
                for (int x = 0; x < _map.GetLength(1); x++)
                {
                    if (_map[y, x] != null && !_map[y,x].HasMoved)
                    {
                        Bunny b = _map[y, x];
                        b.UpdateLocation();

                        if (!OnEdge(b))
                        {
                            _map[b.Y, b.X] = b;
                        }        

                        _map[y, x] = null;
                    }
                }
            }
        }

        public bool OnEdge(Bunny b)
        {
            return b.Y < 0 || b.Y >= _height || b.X < 0 || b.X >= _width;
        }

        public void ClearMoves()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] != null)
                    {
                        Bunny b = _map[i, j];
                        b.ClearMove();
                    }
                }
            }
        }

        public void FullMove()
        {
            UpdateMap();
            ClearMoves();
            DisplayMap();
        }
    }
}
