
namespace Tool.Data {

    public interface IQuery<TResult> {

        TResult Execute();

    }
}
