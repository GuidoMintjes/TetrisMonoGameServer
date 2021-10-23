using System;

namespace TetrisMonoGameServer {

    public static class Funcs {

        private static string errorAlert = "[ERROR] ";
        private static string warningAlert = "[WARNING] ";
        private static string messageAlert = "[MSG] ";
        private static string serverAlert = "[SERVER] ";


        public static void printMessage(int alertLevel, string message) {

            switch (alertLevel) {
                case 0:

                    string msgErr = errorAlert + "{" + DateTime.Now.ToString("HH:mm:ss") + "} " + message;

                    Console.WriteLine(msgErr);

                    break;

                case 1:
                    string msgWarn = warningAlert + "{" + DateTime.Now.ToString("HH:mm:ss") + "} " + message;

                    Console.WriteLine(msgWarn);

                    break;

                case 2:
                    string msgMsg = messageAlert + "{" + DateTime.Now.ToString("HH:mm:ss") + "} " + message;

                    Console.WriteLine(msgMsg);

                    break;

                case 3:
                    string msgServer = serverAlert + "{" + DateTime.Now.ToString("HH:mm:ss") + "} " + message;

                    Console.WriteLine(msgServer);

                    break;

                default:
                    break;
            }
        }
    }
}