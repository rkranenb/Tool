using StructureMap;
using StructureMap.Graph;
using Tool.Commands.Source;
using Tool.Data;
using Tool.Data.Online;

namespace Tool {

    internal static class IoC {

        public static IContainer Initialize() {
            return new Container(registry => {
                registry.Scan(scan => {
                    scan.WithDefaultConventions();
                    scan.TheCallingAssembly();
                    scan.AddAllTypesOf<ICommand>();
                    scan.AddAllTypesOf<ISourceCommandAction>();
                });
<<<<<<< HEAD
                registry.For<IRegistrationsQuery>().Use<FileRegistrationsQuery>();
                registry.For<ISaveRegistrationCommand>().Use<OutputRegistrationCommand>();
=======
                registry.For<IRegistrationsQuery>().Use<NullRegistrationsQuery>();
>>>>>>> master
            });
        }

    }
}
