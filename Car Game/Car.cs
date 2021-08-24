using System.Collections.Generic;


namespace Game
{
    abstract class Car
    {
        public uint AxisX { get; set; }
        public uint AxisY { get; set; }

        public uint Height { get; set; }
        public uint Width { get; set; }


        public Car(uint height, uint width)
        {
            AxisX = 70;
            AxisY = 35;

            Height = height;
            Width = width;

        }

        public abstract void Left();

        public abstract void Right();

        public abstract KeyValuePair<uint, uint> GetMachineLocation();
    }
}
