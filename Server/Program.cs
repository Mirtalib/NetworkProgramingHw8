using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using Server.Models;

var ip = IPAddress.Parse("127.0.0.1");

var port = 2702;

var listener = new TcpListener(ip, port);

listener.Start();
List<int> RoomName= new List<int>();

while (true)
{
    Console.WriteLine("Start listinig");
    var client = listener.AcceptTcpClient();


    new Task(() =>
    {
        var clientStream = client.GetStream();
        var binaryWrite = new BinaryWriter(clientStream);
        var binaryRead = new BinaryReader(clientStream);

        while (true)
        {
            var jsonStr = binaryRead.ReadString();

            XOGameMenecer? gameMenecer = JsonSerializer.Deserialize<XOGameMenecer>(jsonStr);

            if (gameMenecer is null)
            {
                break;
            }

            byte i = 0;
            foreach (var item in RoomName)
            {
                if (gameMenecer.roomPassword == item)
                {
                    i++;
                    binaryWrite.Write("Yes");
                }
            }
            if (i == 0 )
            {
                RoomName.Add(gameMenecer.roomPassword);
            }
        }
    }).Start();

}