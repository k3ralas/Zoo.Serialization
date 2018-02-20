using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooRunner.GUI;

namespace ZooRunner
{
    public class ViewPort
    {
        Map _map;
        readonly int _minDisplayWidth;
        Rectangle _viewPort;
        double _userZoomFactor;
        int _maxClientSize;
        float _clientScaleFactor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m">The map to visualize.</param>
        /// <param name="minDisplayMeters">The minimum width and height for this viewport.</param>
        public ViewPort(Map m, int minDisplayMeters)
        {
            _map = m;
            _viewPort = m.Area;
            _userZoomFactor = 0.0;
            _minDisplayWidth = minDisplayMeters * 100;
        }

        public Map Map => _map; 

        public double MinActualZoomFactor
        {
            get { return (double)_minDisplayWidth / (double)_map.MapWidth; }
        }

        /// <summary>
        /// Gets or sets whether grid lines should be displayed
        /// when drawing boxes.
        /// </summary>
        public bool ShowGridLines { get; set; }

        /// <summary>
        /// Gets the current area of this ViewPort (in centimeters).
        /// </summary>
        public Rectangle Area => _viewPort; 

        /// <summary>
        /// Fires whenever <see cref="Area"/> has changed.
        /// </summary>
        public event EventHandler AreaChanged;

        /// <summary>
        /// Gets or sets the zoom factor from 0.0 (seeing the whole map) to 1.0 (closest).
        /// This is the reverse of the <see cref="ActualZoomFactor"/> and in the range [0.0,1.0].
        /// </summary>
        public double UserZoomFactor
        {
            get { return _userZoomFactor; }
            set
            {
                if( value <= 0 )
                {
                    _userZoomFactor = 0.0;
                    SetActualZoomFactor( 1.0 );
                }
                else if( value >= 1.0 )
                {
                    _userZoomFactor = 1.0;
                    SetActualZoomFactor( MinActualZoomFactor );
                }
                else
                {
                    _userZoomFactor = value;
                    SetActualZoomFactor( (1.0 - value) * (1.0 - MinActualZoomFactor) + MinActualZoomFactor );
                }
            }
        }

        /// <summary>
        /// Gets the zoom factor between <see cref="MinActualZoomFactor"/> (closest) and 1.0 (seeing the whole map).
        /// </summary>
        public double ActualZoomFactor
        {
            get { return (double)Math.Max(_viewPort.Width, _viewPort.Height) / (double)_map.MapWidth; }
        }

        public float ClientScaleFactor => _clientScaleFactor; 

        public void MoveBy( int deltaX, int deltaY )
        {
            if( DoMove( ref _viewPort, deltaX, deltaY ) )
            {
                AreaChanged?.Invoke( this, EventArgs.Empty );
            }
        }

        public void MoveTo( int x, int y )
        {
            MoveBy( x - _viewPort.X, y - _viewPort.Y );
        }

        bool SetActualZoomFactor(double value)
        {
            Debug.Assert(_map.Area.Contains(_viewPort));
            if (value > 1.0) value = 1.0;
            else if (value < MinActualZoomFactor) value = MinActualZoomFactor;
            if (Math.Abs(value - ActualZoomFactor) <= double.Epsilon) return false;

            double grow = value / ActualZoomFactor;
            int newWidth = (int)Math.Round(_viewPort.Width * grow);
            if (newWidth < _minDisplayWidth) newWidth = _minDisplayWidth;
            int newHeight = (int)Math.Round(_viewPort.Height * grow);
            if (newHeight < _minDisplayWidth) newHeight = _minDisplayWidth;
            int deltaW = (newWidth - _viewPort.Width) / 2;
            int deltaH = (newHeight - _viewPort.Height) / 2;
            if (deltaW == 0 && deltaH == 0) return false;
            _viewPort.Width = newWidth;
            _viewPort.Height = newHeight;
            DoMove(ref _viewPort, -deltaW, -deltaW);
            Debug.Assert(_map.Area.Contains(_viewPort));
            _clientScaleFactor = _maxClientSize / (float)Math.Max(_viewPort.Width, _viewPort.Height);
            AreaChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }

        bool DoMove(ref Rectangle r, int deltaX, int deltaY)
        {
            int prevX = r.X;
            int prevY = r.Y;
            r.Offset(deltaX, deltaY);
            if (r.X < 0) r.X = 0;
            else
            {
                int overflow = r.Right - _map.MapWidth;
                if (overflow > 0)
                {
                    r.X -= overflow;
                    if (r.X < 0)
                    {
                        r.X = 0;
                        r.Width = _map.MapWidth;
                    }
                }
            }
            if (r.Y < 0) r.Y = 0;
            else
            {
                int overflow = r.Bottom - _map.MapWidth;
                if (overflow > 0)
                {
                    r.Y -= overflow;
                    if (r.Y < 0)
                    {
                        r.Y = 0;
                        r.Height = _map.MapWidth;
                    }
                }
            }
            Debug.Assert(_map.Area.Contains(r));
            return prevX != r.X || prevY != r.Y;
        }

        internal void SetClientSize( Size client )
        {
            Debug.Assert( _map.Area.Contains( _viewPort ) );
            _maxClientSize = Math.Max( client.Width, client.Height );
            Rectangle newViewPort = _viewPort;
            bool keepH = _viewPort.Height > _viewPort.Width || (_viewPort.Height == _viewPort.Width && client.Height > client.Width);
            if( keepH )
            {
                _clientScaleFactor = (float)_maxClientSize / _viewPort.Height;
                newViewPort.Width = (int)Math.Ceiling( _viewPort.Height * client.Width / (double)_maxClientSize );
                if( newViewPort.Width < _minDisplayWidth ) newViewPort.Width = _minDisplayWidth;
                if( newViewPort.Right > _map.MapWidth )
                {
                    DoMove( ref newViewPort, _map.MapWidth - newViewPort.Right, 0 );
                }
            }
            else
            {
                _clientScaleFactor = (float)_maxClientSize / _viewPort.Width;
                newViewPort.Height = (int)Math.Ceiling( _viewPort.Width * client.Height / (double)_maxClientSize );
                if( newViewPort.Height < _minDisplayWidth ) newViewPort.Height = _minDisplayWidth;
                if( newViewPort.Bottom > _map.Area.Height )
                {
                    DoMove( ref newViewPort, 0, _map.Area.Height - newViewPort.Bottom );
                }
            }
            Debug.Assert( _map.Area.Contains( newViewPort ) );
            _viewPort = newViewPort;
            _clientScaleFactor = (float)_maxClientSize / Math.Max( _viewPort.Width, _viewPort.Height );
            AreaChanged?.Invoke( this, EventArgs.Empty );
        }

        internal void Draw( Graphics g )
        {
            Debug.Assert( _map.Area.Contains( _viewPort ) );
            _map.Draw( g, _viewPort, _clientScaleFactor, ShowGridLines );
        }

        public void DriversAssignment(ZooAdapter zoo, List<AnimalAdapter> animals, AnimalsRedering animalsShapes)
        {
            UnsetDriversAnimals();

            for (int n = 0; n < animals.Count; n++)
            {
                bool shortCut = false;

                double supBoundaryX = -1;
                double infBoundaryX = -1;

                double supBoundaryY = 1;
                double infBoundaryY = 1;

                decimal interval = 2m / (decimal)_map.BoxCount;

                for (int i = 0; i < _map.BoxCount; i++)
                {
                    if (i == _map.BoxCount - 1)
                    {
                        infBoundaryY = -1;
                    }
                    else
                    {
                        infBoundaryY -= (double)interval;
                    }
                    for (int y = 0; y < _map.BoxCount; y++)
                    {
                        if (y == _map.BoxCount - 1)
                        {
                            supBoundaryX = 1;
                        }
                        else
                        {
                            supBoundaryX += (double)interval;
                        }
                        if (animals[n].X >= infBoundaryX && animals[n].X <= supBoundaryX && animals[n].Y <= supBoundaryY && animals[n].Y >= infBoundaryY)
                        {
                            _map[i, y].Driver.AddAnimal(animals[n]);
                            _map[i, y].Driver.CastAnimalsRedering = animalsShapes;

                            shortCut = true;
                            break;
                        }
                        infBoundaryX += (double)interval;
                    }
                    if (shortCut == true) break;

                    supBoundaryY -= (double)interval;
                    infBoundaryX = -1;
                    supBoundaryX = -1;
                }
            }
        }

        public void UnsetDriversAnimals()
        {
            for (int i = 0; i < _map.BoxCount; i++)
            {
                for (int n = 0; n < _map.BoxCount; n++)
                {
                    _map[i, n].Driver.ClearAnimals();
                }
            }
        }

        public void SetDriver(ZooAdapter zoo)
        {
            double supBoundaryX = -1;
            double infBoundaryX = -1;

            double supBoundaryY = 1;
            double infBoundaryY = 1;

            decimal interval = 2m / (decimal)_map.BoxCount;

            for (int i = 0; i < _map.BoxCount; i++)
            {
                infBoundaryY -= (double)interval;

                for (int y = 0; y < _map.BoxCount; y++)
                {
                    supBoundaryX += (double)interval;

                    Driver driver = new Driver();
                    driver.InferiorBoundaryX = infBoundaryX;
                    driver.SuperiorBoundaryY = supBoundaryY;
                    driver.Interval = (double)interval;
                    driver.Zoo = zoo;
                    _map[i, y].Driver = driver;

                    infBoundaryX += (double)interval;
                }
                supBoundaryY -= (double)interval;
                infBoundaryX = -1;
                supBoundaryX = -1;
            }
        }

        public void CreateAndSaveBackgroundImage(string path)
        {
            using (Bitmap bmp = new Bitmap(_map.Area.Width, _map.Area.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    for(int i = 0; i < _map.BoxCount; i++)
                    {
                        for (int n = 0; n < _map.BoxCount; n++)
                        {
                            g.DrawImage(_map[n,i].Driver.BackGround, _map[n, i].Area.X, _map[n, i].Area.Y, _map[n, i].Area.Width, _map[n, i].Area.Height);
                        }
                    } 
                    bmp.Save(path);
                }
            }
        }
    }
}
