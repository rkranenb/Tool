
namespace Tool.Data {

    public interface ISourceQuery : IParameterizedQuery<Source, string> { }

    public class SourceQuery : ISourceQuery {

        public Source Execute(string args) {
            throw new System.NotImplementedException();
        }

    }
}
