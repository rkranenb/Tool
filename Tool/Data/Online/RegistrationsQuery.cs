using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace Tool.Data.Online {

    public interface IRegistrationsQuery : IParameterizedQuery<IEnumerable<Registration>, Source> { }

    public class RegistrationsQuery : IRegistrationsQuery {

        public IEnumerable<Registration> Execute(Source args) {

            using (var client = new WebClient()) {
                var s = client.DownloadString(args.Address);
                return JsonConvert.DeserializeObject<RegistrationsContainer>(s).Registrations;
            }

        }
    }

    public class RegistrationsContainer {
        [JsonProperty("value")]
        public Registration[] Registrations { get; set; }
    }

    public class FileRegistrationsQuery : IRegistrationsQuery {

        public IEnumerable<Registration> Execute(Source args) {

            using (var sr = new System.IO.StreamReader(@"c:\temp\registrations.json")) {
                var s = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<RegistrationsContainer>(s).Registrations;
            }


        }
    }

    public class NullRegistrationsQuery : IRegistrationsQuery {

        public IEnumerable<Registration> Execute(Source args) {
            return null;
        }
    }
}
