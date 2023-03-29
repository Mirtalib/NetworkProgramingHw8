using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class XOGameMenecer
    {
        public string[][][]? XO { get; set; }
        public int roomPassword { get; set; } = default(int);

        public XOGameMenecer()
        {
            XO = new string[3][][];

            XO[0][0] = new string[1] { "" };
            XO[0][1] = new string[1] { "" };
            XO[0][2] = new string[1] { "" };
            XO[1][0] = new string[1] { "" };
            XO[1][1] = new string[1] { "" };
            XO[1][2] = new string[1] { "" };
            XO[2][0] = new string[1] { "" };
            XO[2][1] = new string[1] { "" };
            XO[2][2] = new string[1] { "" };
        }
    }
}
