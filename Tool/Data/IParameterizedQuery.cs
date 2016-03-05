
namespace Tool.Data {

    public interface IParameterizedQuery<TResult, TArgs> {

        TResult Execute(TArgs args);

    }
}
