using System;
using System.IO;
using System.IO.Pipes;

class Program{
    static void Main(){
        using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "testpipe", PipeDirection.In)){
            Console.WriteLine("Attempting to connect to pipe...");
            pipeClient.Connect();
            Console.WriteLine("Connected to pipe.");
            using (StreamReader r = new StreamReader(pipeClient)){
                Console.WriteLine("Received:" + r.ReadLine());
            }
        }
    }
}
