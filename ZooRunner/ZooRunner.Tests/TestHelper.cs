using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner.Tests
{
    public static class TestHelper
    {
        static string _binPath;
        static string _testAppPath;
        static string _solutionPath;

        static public string BinPath
        {
            get
            {
                if (_binPath == null) ComputePaths();
                return _binPath;
            }
        }

        static public string TestAppPath
        {
            get
            {
                if (_testAppPath == null) ComputePaths();
                return _testAppPath;
            }
        }

        static public string SolutionPath
        {
            get
            {
                if (_solutionPath == null) ComputePaths();
                return _solutionPath;
            }
        }

        private static void ComputePaths()
        {
            string path = new Uri(typeof(TestHelper).Assembly.CodeBase).LocalPath;
            _binPath = Path.GetDirectoryName(path);
            _testAppPath = Path.GetDirectoryName(Path.GetDirectoryName(_binPath));
            _solutionPath = Path.GetDirectoryName(_testAppPath);
        }
    }
}
