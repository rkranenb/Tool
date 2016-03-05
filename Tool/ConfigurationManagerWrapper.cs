using System.Configuration;

namespace Tool {

    public interface IConfigurationManagerWrapper {
        ConnectionStringSettingsCollection ConnectionStrings { get; }
    }

    public class ConfigurationManagerWrapper : IConfigurationManagerWrapper {

        public ConnectionStringSettingsCollection ConnectionStrings {
            get { return ConfigurationManager.ConnectionStrings; }
        }

    }
}
