using System;
using System.Configuration;

namespace Tool.Data {

    public interface IConnectionStringProvider {
        string Get(string name);
    }

    public class ConnectionStringProvider : IConnectionStringProvider {

        private readonly IConfigurationManagerWrapper config;

        public ConnectionStringProvider(IConfigurationManagerWrapper config) {
            this.config = config;
        }

        public string Get(string name) {
            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentException("Not a valid name for a connection string.");
            }
            var connectionString = config.ConnectionStrings[name];
            if (connectionString == null) {
                throw new ArgumentException(string.Format("Connectionstring '{0}' was not found.", name));
            }
            return connectionString.ConnectionString;
        }

    }
}
