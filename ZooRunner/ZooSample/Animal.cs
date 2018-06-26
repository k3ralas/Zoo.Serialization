using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZooSample
{
    [Serializable]
    public abstract class Animal
    {
        Zoo _ctx;
        string _name;
        Point _pos;
        public abstract string Type { get; }
        protected Animal( Zoo context, string name )
        {
            _ctx = context;
            _name = name;
        }

        public string Name => _name;

        public Point Position => _pos;

        public double X => _pos.X;

        public double Y => _pos.Y;

        /// <summary>
        /// Only concrete animals can set their position. 
        /// </summary>
        /// <param name="newPosition">The new position of this animal.</param>
        protected void SetPosition( Point newPosition )
        {
            _pos = newPosition;
        }

        protected Zoo Context => _ctx;

        public bool Rename( string newName )
        {
            if( _name != newName )
            {
                if( !_ctx.Rename( this, newName ) ) return false;
                _name = newName;
            }
            return true;
        }

        public void Die()
        {
            _ctx.Die( this );
            _ctx = null;
        }

        internal abstract void Update();

        public bool IsAlive => _ctx != null;
    }
}
