using System.Collections.Generic;

namespace Game
{
    class Player : Car
    {
        public Player(uint hight, uint width) : base(hight, width) { }

        public override void Left() { AxisX = AxisX - 2; }

        public override void Right() { AxisX = AxisX + 2; }

        public override KeyValuePair<uint, uint> GetMachineLocation() { return (new KeyValuePair<uint, uint>(AxisX, AxisY)); }
    }
}
