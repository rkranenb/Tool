
namespace Tool.Commands.Source {

    public class SourceCommand : ICommand {

        public bool MustExecute(string arg) {
            return arg.Equals("source");
        }

        public int Execute(System.Collections.Generic.IEnumerable<string> args) {
            throw new System.NotImplementedException();
        }
    }
}
