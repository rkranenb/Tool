using System;
using System.Linq;

namespace Tool {

    public interface IExecutor {
        int Execute(string[] args);
    }

    public class Executor : IExecutor {

        private readonly ICommand[] commands;

        public Executor(ICommand[] commands) {
            this.commands = commands;
        }

        public int Execute(string[] args) {
            var arg = GetCommandArg(args);
            var command = GetCommand(arg);
            return command.Execute(args.Skip(1));
        }

        private ICommand GetCommand(string arg) {
            var command = commands.SingleOrDefault(x => x.MustExecute(arg));
            if (command == null) {
                throw new ArgumentException(string.Format("Not a valid command: {0}", arg));
            }
            return command;
        }

        private string GetCommandArg(string[] args) {
            if (args == null || args.Length == 0) {
                throw new ArgumentException("No command was specified.");
            }
            return args[0];
        }

    }
}
