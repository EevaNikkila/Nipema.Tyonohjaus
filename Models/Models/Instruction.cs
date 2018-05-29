using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nipema.Tyonohjaus.Models
{
    public class Instruction
    {
        public enum InstructionType
        {
            Loading = 1,
            Paint,
            Unloading
        }

        public InstructionType Type { get; set; }
        public string Text { get; set; }
    }
}
