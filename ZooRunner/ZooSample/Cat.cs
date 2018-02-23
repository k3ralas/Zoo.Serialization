using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSample
{
    public class Cat : Animal
    {
        Point _direction;
        bool _isRandomWalking;
        public override string Type { get { return "Cat"; } }
        internal Cat(Zoo ctx, string name)
            : base(ctx, name)
        {
            _isRandomWalking = true;
        }

        public void MoveTo(Point destination, double percentSpeed)
        {
            double x = X + (destination.X / percentSpeed);
            double y = Y + (destination.Y / percentSpeed);

            //if (x > 1) x = -1;
            //else if (x < -1) x = 1;
            //if (y > 1) y = -1;
            //else if (y < -1) y = 1;

            if (x > 1.0) Die();
            else if (x < -1.0) Die();
            if (y > 1.0) Die();
            else if (y < -1.0) Die();
            //if (Context.ColorAt(x, y) == System.Drawing.Color.Blue) Die();
            SetPosition(new Point(x, y));
        }

        public void MoveRandom()
        {

        }

        internal override void Update()
        {
            if (_isRandomWalking)
            {
                SetDirection();
                _isRandomWalking = false;
            }
            MoveTo(_direction, 10);
        }

        private void SetDirection()
        {
            double randX = GetRandomNumber(-1, 1);
            double randY = GetRandomNumber(-1, 1);
            _direction = new Point(randX, randY);
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            return Context.Randomizer.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
