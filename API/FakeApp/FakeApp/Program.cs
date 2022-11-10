using System;
using System.Runtime.InteropServices.ComTypes;

namespace FakeApp 
{
    public class Program
    {
        public void Main(string[] args)
        {
            IMath math = new MathIsGreat();
            IFile file = new FilesAreRad();
            DoAllTheThings(file, math);
        }

        private void DoAllTheThings(IFile file, IMath math)
        {
            
        }
    }

    public class MathIsGreat : IMath
    {

    }

    public interface IMath
    {
    }

    public class FilesAreRad : IFile
    {

    }
    public interface IFile
    {
    }
}