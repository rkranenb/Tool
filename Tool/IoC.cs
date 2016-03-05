using StructureMap;
using StructureMap.Graph;

namespace Tool {

    internal static class IoC {

        public static IContainer Initialize() {
            return new Container(registry => {
                registry.Scan(scan => {
                    scan.WithDefaultConventions();
                    scan.TheCallingAssembly();
                    scan.AddAllTypesOf<ICommand>();
                });
            });
        }

    }
}
