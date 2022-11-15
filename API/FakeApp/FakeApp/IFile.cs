namespace FakeApp;

public interface IFile
{
    string SaveFileContents(string filePath);
    string CreateFile(string filePath);
    string UpsertFileContents(string filePath);
}