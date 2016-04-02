using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Speech
{
    public class Speech : ISpeech
    {
        public string ReportDanger()
        {
            return "I cannot accept the command as I'm at the edge!";
        }
        
        public string ReportPosition(int x, int y, string facing)
        {
            return string.Format("Currently in {0},{1}. Facing {2}", x, y, facing);
        }

        public string ReportError()
        {
            return string.Format("Unable to comply to instruction");
        }
    }
}
