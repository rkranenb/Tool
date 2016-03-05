using System;
using Dapper;

namespace Tool.Data {

    public interface ISaveRegistrationCommand : IParameterizedCommand<Registration> { }

    public class SaveRegistrationCommand : ISaveRegistrationCommand {

        private readonly IConnectionFactory connectionFactory;

        public SaveRegistrationCommand(IConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }


        public void Execute(Registration registration) {

            const string SQL = "INSERT INTO [Registration] ( [Email], [Name] ) VALUES ( @email, @name )";

            var args = new {
                email = registration.Email,
                name = registration.Name
            };

            using (var connection = connectionFactory.Create()) {
                connection.Execute(SQL, args);
            }
        }

    }

    public class OutputRegistrationCommand : ISaveRegistrationCommand
    {
        public void Execute(Registration arg) {
            Console.WriteLine("{0}, {1}", arg.Name, arg.Email);
        }
    }

}
