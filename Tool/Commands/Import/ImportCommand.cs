using System;
using System.Collections.Generic;
using System.Linq;
using Tool.Data;
using Tool.Data.Online;

namespace Tool.Commands.Import {

    public class ImportCommand : ICommand {

        private readonly ISourcesQuery sourcesQuery;
        private readonly IRegistrationsQuery registrationsQuery;
        private readonly ISaveRegistrationsCommand saveRegistrationsCommand;

        public ImportCommand(ISourcesQuery sourcesQuery,
            IRegistrationsQuery registrationsQuery,
            ISaveRegistrationsCommand saveRegistrationsCommand) {

            this.sourcesQuery = sourcesQuery;
            this.registrationsQuery = registrationsQuery;
            this.saveRegistrationsCommand = saveRegistrationsCommand;
        }

        public bool MustExecute(string arg) {
            return arg.Equals("import");
        }

        public int Execute(IEnumerable<string> args) {

            sourcesQuery.Execute()
                .Where(x => x.Enabled)
                .Each(source => Execute(source));

            return 0;
        }

        private void Execute(Tool.Source source) {
            var registrations = registrationsQuery.Execute(source);
            saveRegistrationsCommand.Execute(registrations);
        }
    }
}
