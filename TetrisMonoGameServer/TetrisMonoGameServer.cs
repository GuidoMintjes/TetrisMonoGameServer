using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TetrisMonoGameServer {
    class TetrisMonoGameServer {


        // Create the class that listens for all incoming connections
        static TcpListener server;


        // Related to connecting
        static IPAddress localIP = IPAddress.Parse("127.0.0.1");
        static int port;


        static bool listening = true;


        // Initialize server
        public static void Main(string[] args) {

            // Loads server settings from a text file so settings can be changed without
            // building every time
            string readServerSettings = File.ReadAllText("SERVER_SETTINGS.txt");
            string[] serverSettings = readServerSettings.Split(";");


            // Loads the settings from the stringarray, indices explained in SETTINGS_EXPLAINED.txt
            port = int.Parse(serverSettings[0]);    


            // Create the TcpListener with the correct IP address and port and 
            //  start listening for incoming connections (aka start the server)
            server = new TcpListener(localIP, port);
            server.Start();


            // Create the datastream variable in the DataStream class
            DataStream.dataStream = new byte[256];  // This will be the length of the datastream


            // Enter the loop that will listen for incoming connections
            ListenLoop();

            Console.ReadLine();
        }


        static void ListenLoop() {

            // This method will make sure incoming connections are accepted and the connection is stored
            //  to an instance of the TcpClient class
            TcpClient client = server.AcceptTcpClient();

            Funcs.printMessage(3, "Incoming connection!");

            DataStream.networkStream = client.GetStream();

            DataStream.networkStream.Read(DataStream.dataStream, 0, DataStream.dataStream.Length);

            Console.WriteLine(DataStream.ReadString(false));

            if(listening)
                ListenLoop();
        }
    }
}
