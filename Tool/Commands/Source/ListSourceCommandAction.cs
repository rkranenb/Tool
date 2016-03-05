using System;
using System.Collections.Generic;
using Tool.Data;

namespace Tool.Commands.Source {
    public class ListSourceCommandAction : ISourceCommandAction {

        private readonly ISourcesQuery sourcesQuery;

        public ListSourceCommandAction(ISourcesQuery sourcesQuery) {
            this.sourcesQuery = sourcesQuery;
        }

        public bool MustExecute(string arg) {
            return arg.Equals("list");
        }

        public int Execute(IEnumerable<string> args) {
            var format = "{0}: {1}\nAddress: {2}";
            sourcesQuery.Execute()
                .Each(x => Console.WriteLine(format, x.Name, x.Description, x.Address));
            return 0;
        }
    }
}
