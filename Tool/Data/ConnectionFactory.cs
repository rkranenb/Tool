using System.Data;
using System.Data.SqlClient;

namespace Tool.Data {

    public interface IConnectionFactory {
        IDbConnection Create(string name = null);
    }

    public class ConnectionFactory : IConnectionFactory {

        const string DEFAULT_NAME = "default";

        private readonly IConnectionStringProvider connectionStringProvider;

        public ConnectionFactory(IConnectionStringProvider connectionStringProvider) {
            this.connectionStringProvider = connectionStringProvider;
        }

        public IDbConnection Create(string name = null) {
            return new SqlConnection(connectionStringProvider.Get(name ?? DEFAULT_NAME));
        }

    }
}
