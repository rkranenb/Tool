using System;
using System.Collections.Generic;

namespace Tool.Commands {

    public class HelpCommand : ICommand {

        public bool MustExecute(string arg) {
            return arg.Equals("help");
        }

        public int Execute(IEnumerable<string> args) {
            Console.WriteLine("Don't expect help from me.");
            return 0;
        }

    }
}
