using System.Collections.Generic;

namespace Tool.Data {

    public interface ISaveRegistrationsCommand : IParameterizedCommand<IEnumerable<Registration>> { }

    public class SaveRegistrationsCommand : ISaveRegistrationsCommand {

        private readonly ISaveRegistrationCommand saveRegistrationCommand;

        public SaveRegistrationsCommand(ISaveRegistrationCommand saveRegistrationCommand) {
            this.saveRegistrationCommand = saveRegistrationCommand;
        }

        public void Execute(IEnumerable<Registration> registrations) {
            registrations.Each(x => saveRegistrationCommand.Execute(x));
        }
    }
}
