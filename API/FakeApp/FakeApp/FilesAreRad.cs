using ChanceNET;

namespace FakeApp
{
    public class FilesAreRad : IFile
    {
        readonly Chance _chance = new Chance();
        public string SaveFileContents(string filePath)
        {
            return $"{filePath}{_chance.FileExtension()}";
        }

        public string CreateFile(string filePath)
        {
            return $"{filePath}{_chance.FileExtension()}";
        }

        public string UpsertFileContents(string filePath)
        {
            return $"{filePath}{_chance.FileExtension()}";
        }

        public int GetFileLength(string fileName)
        {
            FunFile file = null;
            if (string.IsNullOrEmpty(fileName) == false)
            {
                file = new FunFile { FileName = fileName };
            }
            return file.FileName.Length;
        }

    }
}