using System;
using System.Collections.Generic;

namespace Tool.Commands.Source {

    public class AddSourceCommandAction : ISourceCommandAction {

        public bool MustExecute(string arg) {
            return arg.Equals("add");
        }

        public int Execute(IEnumerable<string> args) {
            throw new NotImplementedException();
        }
    }
}
