using System;
using System.IO;

class MyResourcefulClass : IDisposable
{
    private FileStream fileStream;
    public MyResourcefulClass(string filePath)
    {
        fileStream = File.Open(filePath, FileMode.OpenOrCreate);
        Console.WriteLine("File opened: " + filePath);
    }
    public void PerformOperation()
    {
        Console.WriteLine("Performing operation with the file");
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (fileStream != null)
            {
                fileStream.Close();
                Console.WriteLine("File closed");
            }
        }
    }

    ~MyResourcefulClass()
    {
        Dispose(false);
    }
}

class Program
{
    static void Main()
    {
        string filePath = "example.txt";

        using (MyResourcefulClass myResourcefulObject = new MyResourcefulClass(filePath))
        {
            myResourcefulObject.PerformOperation();
        } 
        Console.WriteLine("Object out of scope");
    }
}