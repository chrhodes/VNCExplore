//using System;
//using System.IO;
//using System.IO.Pipes;
//using System.Text;
//using System.Threading.Tasks;

//public class PipeServer
//{
//    public static async Task Main()
//    {
//        // Create a named pipe server stream with the name "testpipe"
//        using var pipeServer = new NamedPipeServerStream(
//            "testpipe",
//            PipeDirection.InOut,
//            1,
//            PipeTransmissionMode.Byte,
//            PipeOptions.Asynchronous);

//        Console.WriteLine("Waiting for client connection...");
//        await pipeServer.WaitForConnectionAsync(); // Asynchronously wait for a client to connect
//        Console.WriteLine("Client connected.");

//        // Use StreamReader and StreamWriter for easier text-based communication
//        using var reader = new StreamReader(pipeServer, Encoding.UTF8, leaveOpen: true);
//        using var writer = new StreamWriter(pipeServer, Encoding.UTF8, leaveOpen: true) { AutoFlush = true };

//        // Read a message from the client
//        string message = await reader.ReadLineAsync();
//        Console.WriteLine($"Received from client: {message}");

//        // Send a response to the client
//        await writer.WriteLineAsync("Hello from server!");
//        Console.WriteLine("Sent response to client.");
//    }
//}

using System;
using System.IO;
using System.IO.Pipes;

class PipeServer
{
    static void Main()
    {
        using (NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("testpipe", PipeDirection.Out))
        {
            Console.WriteLine("NamedPipeServerStream object created.");

            // Wait for a client to connect
            Console.Write("Waiting for client connection...");
            pipeServer.WaitForConnection();

            Console.WriteLine("Client connected.");
            try
            {
                // Read user input and send that to the client process.
                using (StreamWriter sw = new StreamWriter(pipeServer))
                {
                    sw.AutoFlush = true;
                    string message = "";
                    do
                    {
                        Console.Write("Enter text: ");
                        message = Console.ReadLine();
                        sw.WriteLine(message);
                    } while (string.Compare(message, "stop") != 0);
                }
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
    }
}

