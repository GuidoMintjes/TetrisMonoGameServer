using System;
using System.Net.Sockets;
using System.Text;

namespace TetrisMonoGameServer {
    class DataStream {

        // The raw byte data stream and the string that the stream gets parsed into
        public static byte[] dataStream;
        public static string dataInStream;

        public static int writePointer;
        public static int readPointer;


        // This is the 'actual' data stream
        public static NetworkStream networkStream;


        /// <summary>
        /// This method will write a string to the byte array data stream
        /// </summary>
        public static string ReadString(bool moveReadPointer) {

            string message = Encoding.ASCII.GetString(dataStream);  // Convert the message string to bytes

            if(moveReadPointer)
                readPointer += message.Length;

            return message;
        }
    }
}