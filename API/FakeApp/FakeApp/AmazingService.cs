using System;
using System.Runtime.InteropServices.ComTypes;

namespace FakeApp 
{
    public class AmazingService
    {
        private readonly IFile _file;
        private readonly IMath _math;

        public AmazingService(IFile file, IMath math)
        {
            _file = file;
            _math = math;
        }

        internal void DoAllTheThings(int valueOne, int valueTwo)
        {
            var resultAdd = _math.Add(valueOne, valueTwo);
            var fileCreated = _file.CreateFile((resultAdd * resultAdd).ToString());

            var resultSubtract = _math.Subtract((uint)valueOne, (uint)valueTwo);
            var fileUpsert = _file.UpsertFileContents(resultSubtract.ToString());

        }
    }
}