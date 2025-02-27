using System;
using System.IO;
using System.IO.Pipes;


/// <summary>
/// Client program that connects to the server and sends and receives messages.
/// The client can send messages to the server and receive messages from the server.
/// The client can also disconnect from the server by sending the message "exit".
/// The client will also disconnect if the server sends the message "exit".
/// </summary>
class Program{
    static void Main(){
        using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut)){
            Console.WriteLine("Attempting to connect to pipe...");
            pipeClient.Connect();
            Console.WriteLine("Connected to pipe.");

            using (StreamWriter w = new StreamWriter(pipeClient))
            using (StreamReader r = new StreamReader(pipeClient)){
                w.AutoFlush = true;

                
                Thread readThread = new Thread(() => {
                    while(true){
                        string? serverMessage = r.ReadLine();
                        if(serverMessage != null){
                            Console.WriteLine("Received: " + serverMessage);
                        }
                        else if(serverMessage == null || serverMessage?.ToLower() == "exit"){
                            Console.WriteLine("Server disconnected");
                            break;
                        }
                    }
                });
                readThread.Start();

                while(true){
                    Console.WriteLine("Enter message to send to server: ");
                    string? clientMessage = Console.ReadLine();
                    if(clientMessage?.ToLower() == "exit" || clientMessage == null){
                        w.WriteLine("exit");
                        break;
                    }
                    w.WriteLine(clientMessage);
                    Console.WriteLine("Sent: " + clientMessage);
                }
                readThread.Join();
            }
        }
        Console.WriteLine("Client disconnected");
    }
}
