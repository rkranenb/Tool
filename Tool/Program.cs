using System;

namespace Tool {

    class Program {

        static int Main(string[] args) {

            try {

                return IoC.Initialize()
                    .GetInstance<IExecutor>()
                    .Execute(args);

            } catch (Exception e) {

                Console.WriteLine(e.Message);
                return 1;

            }
        }

    }
}
