
using System.Collections.Generic;
namespace Tool {

    public interface ICommand {

        bool MustExecute(string arg);
        int Execute(IEnumerable<string> args);

    }
}
