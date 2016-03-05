
using System.Collections.Generic;
namespace Tool.Data {

    public interface ISourcesQuery : IQuery<IEnumerable<Source>> { }

    public class SourcesQuery : ISourcesQuery {

        public IEnumerable<Source> Execute() {
            throw new System.NotImplementedException();
        }

    }
}
