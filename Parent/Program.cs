//NAME: JONATHAN JOHNSON
//CLASS: OPERATING SYSTEMS
//SECTION: 01
//DATE: 2/28/2025

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;

class ParentProcess
{
    static void Main()
    {
        using (AnonymousPipeServerStream pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))       // CREATE PIPE SERVER
        {
            Console.WriteLine("Attempting to start child...");

            Process child = new Process();      // CREATE CHILD PROCESS
            child.StartInfo.FileName = "dotnet";

            child.StartInfo.Arguments = "/home/Jonathan/Desktop/Operating_Systems_Pt2/Child/bin/Debug/net9.0/Child.dll"; // SPECIFY ARGUMENTS TO RUN CHILD DLL
            child.StartInfo.UseShellExecute = false;
            child.StartInfo.RedirectStandardInput = false;
            child.StartInfo.RedirectStandardOutput = false;
            child.StartInfo.Environment["PIPE_HANDLE"] = pipeServer.GetClientHandleAsString(); // PASS PIPE HANDLE TO CHILD PROCESS
            child.Start();

            pipeServer.DisposeLocalCopyOfClientHandle();

            using (StreamWriter writer = new StreamWriter(pipeServer))      // WRITE MESSAGE TO CHILD THROUGH PIPE
            {
                writer.AutoFlush = true; // FLUSH AFTER EACH WRITE
                writer.WriteLine("Test messeage from parent to child"); // SEND MESSAGE
            }
            child.WaitForExit();        // WAIT FOR CHILD TO FINISH
        }
    }
}
