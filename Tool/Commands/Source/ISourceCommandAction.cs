using System.Collections.Generic;

namespace Tool.Commands.Source {

    public interface ISourceCommandAction {

        bool MustExecute(string arg);
        int Execute(IEnumerable<string> args);

    }
}
