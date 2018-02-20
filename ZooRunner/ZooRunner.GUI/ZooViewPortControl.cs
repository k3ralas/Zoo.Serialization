using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ZooRunner.GUI;

namespace ZooRunner
{
    public class ZooViewPortControl : Control
    {
        const double _mouseWheelFactor = 0.001;

        readonly Stopwatch _drawWatch;
        readonly Stopwatch _zooWatch;
        readonly Timer _timer;

        ZooAdapter _zoo;
        Map _map;
        ViewPort _viewPort;
        int _boxCount;
        Point _grabMouseOrigin;
        Point _grabViewPortOrigin;

        static readonly Cursor _grabCursor;
        static readonly Cursor _handCursor;

        static ZooViewPortControl()
        {
            using( Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream( "ZooRunner.GUI.Icons.grab.cur" ) )
            {
                _grabCursor = new Cursor( s );
            }
            using( Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream( "ZooRunner.GUI.Icons.hand.cur" ) )
            {
                _handCursor = new Cursor( s );
            }
        }

        public ZooViewPortControl()
        {
            DoubleBuffered = true;
            _boxCount = 10;
            _map = new Map( 10, 11 );
            _viewPort = new ViewPort( _map, 1 );
            _viewPort.AreaChanged += _viewPort_AreaChanged;
            _drawWatch = new Stopwatch();
            _zooWatch = new Stopwatch();
            _timer = new Timer();
            _timer.Tick += OnTimedEvent;
            _timer.Interval = 1000;
            _timer.Start();
            Cursor = _handCursor;
        }

        public event EventHandler<string> AreaChanged;
        public event EventHandler<int> ViewPortHeightChanged;
        public event EventHandler<int> MapWidthChanged;
        public event EventHandler<string> WatchsUpdates;
        public event EventHandler<string> EngineInformationsChanged;


        void _viewPort_AreaChanged( object sender, EventArgs e )
        {
            DisplayInfo();
            Invalidate();
        }

        public int BoxCount
        {
            get { return _boxCount; }
            set
            {
                if( value < 1 || value > 10 ) throw new ArgumentException( "BoxCount must be between 1 and 10." );
                if( _boxCount != value )
                {
                    _boxCount = value;
                    if( _zoo != null )
                    {
                        InitializeMap();
                        ViewPortHeightChanged?.Invoke( this, _viewPort.Area.Height );
                    }
                }
            }
        }

        public void SetZoo( ZooAdapter zoo )
        {
            if( _zoo == zoo ) return;
            if( zoo != null )
            {
                if( _zooWatch.IsRunning ) _zooWatch.Reset();
                if( _drawWatch.IsRunning ) _drawWatch.Reset();
                _zooWatch.Start();
                _drawWatch.Reset();
                _zoo = zoo;
                InitializeMap();
            }
            else
            {
                _viewPort.AreaChanged -= _viewPort_AreaChanged;
                _viewPort = null;
                _map = null;
                _zoo = null;
                Invalidate();
            }
        }

        void InitializeMap()
        {
            var previousViewPort = _viewPort;
            if( previousViewPort != null ) previousViewPort.AreaChanged -= _viewPort_AreaChanged;
            _map = new Map( 10, _boxCount );
            _viewPort = new ViewPort( _map, 5 );
            _viewPort.ShowGridLines = previousViewPort?.ShowGridLines ?? false;
            _viewPort.SetClientSize( ClientSize );
            _viewPort.AreaChanged += _viewPort_AreaChanged;
            _viewPort.SetDriver( _zoo );
            DisplayInfo();
            MapWidthChanged?.Invoke( this, _viewPort.Map.MapWidth );
            Invalidate();
        }

        protected override void OnResize( EventArgs e )
        {
            _viewPort.SetClientSize( ClientSize );
            base.OnResize( e );
        }

        public bool ShowGridLines
        {
            get { return _viewPort.ShowGridLines; }
            set
            {
                if( _viewPort.ShowGridLines != value )
                {
                    _viewPort.ShowGridLines = value;
                    Invalidate();
                }
            }
        }

        bool IsGrabbing => Cursor == _grabCursor;

        protected override void OnMouseWheel( MouseEventArgs e )
        {
            if( !IsGrabbing )
            {
                _viewPort.UserZoomFactor += e.Delta * _mouseWheelFactor;
            }
            base.OnMouseWheel( e );
        }

        protected override void OnMouseDown( MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Left && !IsGrabbing )
            {
                Cursor = _grabCursor;
                Capture = true;
                _grabMouseOrigin = e.Location;
                _grabViewPortOrigin = _viewPort.Area.Location;
            }
            base.OnMouseDown( e );
        }

        protected override void OnMouseUp( MouseEventArgs e )
        {
            if( IsGrabbing )
            {
                Cursor = _handCursor;
                Capture = false;
            }
            base.OnMouseUp( e );
        }

        protected override void OnMouseMove( MouseEventArgs e )
        {
            if( IsGrabbing )
            {
                float deltaX = (_grabMouseOrigin.X - e.Location.X) / _viewPort.ClientScaleFactor;
                float deltaY = (_grabMouseOrigin.Y - e.Location.Y) / _viewPort.ClientScaleFactor;
                _viewPort.MoveTo( _grabViewPortOrigin.X + (int)Math.Round( deltaX ), _grabViewPortOrigin.Y + (int)Math.Round( deltaY ) );
            }
            base.OnMouseMove( e );
        }

        public void TimerTick( List<AnimalAdapter> animals )
        {
            _viewPort.DriversAssignment( _zoo, animals, AnimalsShapes );
            Invalidate();
            DisplayInfo();
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            if( _viewPort == null || _zoo == null || this.IsInDesignMode() )
            {
                e.Graphics.FillRectangle( Brushes.Gray, e.ClipRectangle );
            }
            else
            {
                _drawWatch.Start();
                _viewPort.Draw( e.Graphics );
                _drawWatch.Stop();
            }
            base.OnPaint( e );
        }

        public AnimalsRedering AnimalsShapes { get; set; }

        void DisplayInfo()
        {
            if( Enabled == true )
            {
                StringBuilder b = new StringBuilder();
                b.Append( "Zoom: " ).AppendLine();
                b.Append( _viewPort.UserZoomFactor * 100 + "%" ).AppendLine();
                string informations = b.ToString();
                AreaChanged?.Invoke( this, informations );
                StringBuilder b2 = new StringBuilder();
                b2.Append( "ViewPort: " ).Append( _viewPort.Area ).AppendLine();
                b2.Append( "ClientScaleFactor: " ).Append( _viewPort.ClientScaleFactor ).AppendLine();
                b2.Append( "Client size : " ).Append( this.ClientSize );
                string engineinfos = b2.ToString();
                EngineInformationsChanged?.Invoke( this, engineinfos );
                ViewPortHeightChanged?.Invoke( this, _viewPort.Area.Height );
            }
        }

        protected override void OnEnabledChanged( EventArgs e )
        {
            DisplayInfo();
            base.OnEnabledChanged( e );
        }

        void OnTimedEvent( object sender, EventArgs e )
        {
            if( Enabled )
            {
                StringBuilder b = new StringBuilder();
                b.Append( "Zoo runtime :" ).AppendLine();
                b.Append( TimeFormat( _zooWatch ) ).AppendLine();
                b.Append( "Draw runtime :" ).AppendLine();
                b.Append( TimeFormat( _drawWatch ) ).AppendLine();
                string watchs = b.ToString();
                WatchsUpdates?.Invoke( this, watchs );
            }
        }

        private string TimeFormat( Stopwatch watch )
        {
            TimeSpan ts = watch.Elapsed;

            string elapsedTime = String.Format( "{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10 );

            return elapsedTime;
        }

        public void BackgroundSaved( string path )
        {
            _viewPort.CreateAndSaveBackgroundImage( path );
        }

    }
}
