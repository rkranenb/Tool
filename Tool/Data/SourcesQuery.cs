using Dapper;
using System.Collections.Generic;

namespace Tool.Data {

    public interface ISourcesQuery : IQuery<IEnumerable<Source>> { }

    public class SourcesQuery : ISourcesQuery {

        private IConnectionFactory connectionFactory;

        public SourcesQuery(IConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }

        public IEnumerable<Source> Execute() {

            const string SQL = "SELECT * FROM Source";

            using (var connection = connectionFactory.Create()) {
                return connection.Query<Source>(SQL);
            }
        }

    }
}
