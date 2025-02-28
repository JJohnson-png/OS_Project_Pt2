//NAME: JONATHAN JOHNSON
//CLASS: OPERATING SYSTEMS
//SECTION: 01
//DATE: 2/28/2025

using System;
using System.IO;
using System.IO.Pipes;

class ChildProcess
{
    static void Main()
    {
        Console.WriteLine("Child process started!");

        string pipeHandle = Environment.GetEnvironmentVariable("PIPE_HANDLE");      // GET PIPE HANDLE
        if (pipeHandle == null)
        {
            Console.WriteLine("No PIPE_HANDLE found!");
            return;
        }

        using (AnonymousPipeClientStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, pipeHandle))              // CONNECT TO THE PIPE SERVER

        using (StreamReader reader = new StreamReader(pipeClient))      // CREATE READER TO READ FROM PIPE
        {
            string message = reader.ReadLine();
            Console.WriteLine("Child received: " + message);        //PRINT MESSAGE RECIEVED FROM PARENT
        }
    }
}

