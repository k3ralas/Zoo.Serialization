using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooSample
{
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
        public Animal()
        {

        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Point Position => _pos;

        public double X
        {
            get
            {
                return _pos.X;
            }
            set
            {
                _pos.X = value;
            }
        }

        public double Y {
            get
            {
                return _pos.Y;
            }
            set
            {
                _pos.Y = value;
            }
        }

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

        public static XElement ToXElement<T>()
        {
            throw new NotImplementedException();
        }
    }
}
