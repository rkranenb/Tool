using System;

namespace Tool {

    class Program {

        static void Main(string[] args) {

            try {

                IoC.Initialize()
                    .GetInstance<IExecutor>()
                    .Execute(args);

            } catch (Exception e) {

                Console.WriteLine(e.Message);

            }
        }

    }
}
