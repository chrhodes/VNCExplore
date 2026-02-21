//using System;
//using System.IO;
//using System.IO.Pipes;
//using System.Text;
//using System.Threading.Tasks;

//public class PipeClient
//{
//    public static async Task Main()
//    {
//        // Connect to the named pipe "testpipe" on the local machine (".").
//        using var pipeClient = new NamedPipeClientStream(
//            ".",
//            "testpipe",
//            PipeDirection.InOut,
//            PipeOptions.Asynchronous);

//        Console.WriteLine("Connecting to server...");
//        await pipeClient.ConnectAsync(); // Asynchronously connect to the server
//        Console.WriteLine("Connected to server.");

//        // Use StreamReader and StreamWriter for easier text-based communication
//        using var reader = new StreamReader(pipeClient, Encoding.UTF8, leaveOpen: true);
//        using var writer = new StreamWriter(pipeClient, Encoding.UTF8, leaveOpen: true) { AutoFlush = true };

//        // Send a message to the server
//        await writer.WriteLineAsync("Hello from client!");
//        Console.WriteLine("Sent message to server.");

//        // Read the response from the server
//        string response = await reader.ReadLineAsync();
//        Console.WriteLine($"Received from server: {response}");
//    }
//}

using System;
using System.IO;
using System.IO.Pipes;

class PipeClient
{
    static void Main(string[] args)
    {
        using (NamedPipeClientStream pipeClient =
            new NamedPipeClientStream(".", "testpipe", PipeDirection.In))
        {

            // Connect to the pipe or wait until the pipe is available.
            Console.Write("Attempting to connect to pipe...");
            pipeClient.Connect();

            Console.WriteLine("Connected to pipe.");
            Console.WriteLine("There are currently {0} pipe server instances open.",
               pipeClient.NumberOfServerInstances);

            using (StreamReader sr = new StreamReader(pipeClient))
            {
                // Display the read text to the console
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Received from server: {0}", temp);
                }
            }
        }
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }
}