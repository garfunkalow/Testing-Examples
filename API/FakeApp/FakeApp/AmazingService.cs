﻿namespace FakeApp 
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

        public string DoAllTheThings(int valueOne, int valueTwo)
        {
            // valueOne *= valueTwo;
            
            var resultAdd = _math.Add(valueOne, valueTwo);
            string filePath = resultAdd.ToString();
            
            // filePath = "Definitely Should Not Pass";
            
            var fileCreated = _file.CreateFile(filePath);
            return fileCreated;
        }

      
    }
}