using System.Collections.Generic;
namespace Game
{
    abstract class Obstacle
    {
        public uint AxisX { get; set; }
        public uint AxisY { get; set; }

        public uint Height { get; set; }
        public uint Width { get; set; }

        public Obstacle(uint height, uint width, uint x, uint y)
        {
            AxisX = x;
            AxisY = y;

            Height = height;
            Width = width;
        }

        public void Move()
        {
            ++AxisY;
        }

        public KeyValuePair<uint, uint> GetObstacleLocation() { return (new KeyValuePair<uint, uint>(AxisX, AxisY)); }

    }
}
