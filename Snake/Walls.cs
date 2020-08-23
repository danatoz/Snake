using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        private List<Figure> walList;

        public Walls(int mapWidth, int mapHeight)
        {
            walList = new List<Figure>();

            HorizontalLine hWallUp = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine hWallDown = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine vWallLeft = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine vWallRight = new VerticalLine(0, mapHeight - 1, mapWidth, '+');

            walList.Add(hWallUp);
            walList.Add(hWallDown);
            walList.Add(vWallLeft);
            walList.Add(vWallRight);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in walList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in walList)
            {
                wall.Draw();
            }
        }
    }
}
