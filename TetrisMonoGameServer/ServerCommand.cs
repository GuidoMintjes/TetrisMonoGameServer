﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TCPChatServer {
    public static class ServerCommand {

        public static bool reading = false;

        public static void CommandLoop() {

            string commandRaw;

            while (true) {
                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key) {
                        case ConsoleKey.Enter:
                            Console.WriteLine();
                            Funcs.printMessage(3, "Input command:", false);
                            commandRaw = Console.ReadLine();
                            Console.WriteLine();

                            SendCommand(commandRaw);
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        private static void SendCommand(string commandRaw) {

            string command = "", argument = "";

            if (!String.IsNullOrEmpty(commandRaw)) {

                    string[] commandsRaw = commandRaw.Split(" ", 2);

                try {
                    command = commandsRaw[0];
                    argument = commandsRaw[1];
                } catch {
                    Funcs.printMessage(1, "Command not formatted right!", false);
                }

                    switch (command) {

                        case "say":

                            TCPServerSend.TCPSendPacketToAll(CreateMessagePacket(argument));
                            break;


                        default:

                            CommandLoop();
                            break;
                    }

                    reading = false;

                    CommandLoop();
            }
        }




        private static Packet CreateMessagePacket(string message) {

            Packet packet = new Packet((int)ServerPackets.message);

            packet.PacketWrite(message);

            return packet;
        }
    }
}