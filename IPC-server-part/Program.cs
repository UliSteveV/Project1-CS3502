using System;
using System.Formats.Asn1;
using System.IO;
using System.IO.Pipes;

class Program{
    static void Main(){
        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.Out)){
            Console.WriteLine("Waiting for connection...");
            pipeServer.WaitForConnection();

            using (StreamWriter w = new StreamWriter(pipeServer)){
                w.AutoFlush = true;
                w.WriteLine("50");
                Console.WriteLine("Sent: 50");
                
                Console.WriteLine("Press Enter to disconnect");
                Console.ReadLine();
                

            }
        }
        Console.WriteLine("Server disconnected");
    }
}
