using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace MarkdownPad2Cracker
{
    public class helper
    {
        public void Crack(string fileName)
        {
            ModuleDefinition module = ModuleDefinition.ReadModule(fileName);

        }
    }
}
