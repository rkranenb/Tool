using System.Linq;

namespace Tool.Commands.Source {

    public class SourceCommand : ICommand {

        private readonly ISourceCommandAction[] actions;

        public SourceCommand(ISourceCommandAction[] actions) {
            this.actions = actions;
        }

        public bool MustExecute(string arg) {
            return arg.Equals("source");
        }

        public int Execute(System.Collections.Generic.IEnumerable<string> args) {
            return actions.Single(x => x.MustExecute(args.First()))
                .Execute(args.Skip(1));
        }
    }
}
