namespace Game
{
    class Enemy : Obstacle
    {
        public Enemy(uint height, uint width, uint x, uint y) : base(height, width, x, y) { }
    }

    class Bonus : Obstacle
    {
        public Bonus(uint height, uint width, uint x, uint y) : base(height, width, x, y) { }
    }

    class HP : Obstacle
    {
        public HP(uint height, uint width, uint x, uint y) : base(height, width, x, y) { }
    }

    class Speed : Obstacle
    {
        public Speed(uint height, uint width, uint x, uint y) : base(height, width, x, y) { }
    }
}
