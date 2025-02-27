using System;
using System.Formats.Asn1;
using System.IO;
using System.IO.Pipes;

/// <summary>
/// Server program that listens for a client to connect and sends and receives messages.
/// The server can send messages to the client and receive messages from the client.
/// The server can disconnect from the client by sending the message "exit".
/// The server will also disconnect if the client sends the message "exit".
/// </summary>
class Program{
    static void Main(){
        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut)){
            Console.WriteLine("Waiting for connection...");
            pipeServer.WaitForConnection();
            

            using (StreamReader r = new StreamReader(pipeServer))
            using (StreamWriter w = new StreamWriter(pipeServer)){
                w.AutoFlush = true;
                Console.WriteLine("Connected.");
                string? serverMessage = "Hello from server!";
                w.WriteLine(serverMessage);
                Console.WriteLine("Sent: " + serverMessage);

                Thread readThread = new Thread(() => {
                    while(true){
                        string? clientMessage = r.ReadLine();
                        if(clientMessage != null){
                            Console.WriteLine("Received: " + clientMessage);
                        }
                        else if(clientMessage == null || clientMessage?.ToLower() == "exit"){
                            Console.WriteLine("Client disconnected");
                            break;
                        }
                    }
                });
                readThread.Start();
                
                while(true){
                    Console.WriteLine("Enter message to send to client: ");
                    serverMessage = Console.ReadLine();
                    if(serverMessage?.ToLower() == "exit" || serverMessage == null){
                        w.WriteLine("exit");
                        break;

                    }
                    w.WriteLine(serverMessage);
                    Console.WriteLine("Sent: " + serverMessage);
                    

                }
                readThread.Join();
            }
            Console.WriteLine("Server disconnected");
        }
    }
}
