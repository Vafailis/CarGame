using System;
using System.Collections.Generic;

namespace Game
{
    abstract class Way
    {
        public Car user;
        protected Random _ForRand;
        public long Score { get; set; }
        public int Lives { get; set; }

        public List<Obstacle> obstacles { get; set; }

        public Way()
        {
            user = new Player(4, 4);
            obstacles = new List<Obstacle>();
            _ForRand = new Random();
            Score = 0;
            Lives = 2;
        }

        public abstract void AddObstacle(Obstacle obj);

        public abstract void DeleteObstacle();

        public abstract void MoveObstacles();

        public abstract void MoveCar();

        public abstract KeyValuePair<uint, uint> GetCarCoordinate();

        public abstract bool Collision(View view, ref int speed);
    }
}