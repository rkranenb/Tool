
namespace Tool.Data {

    public interface IParameterizedCommand<TArg> {

        void Execute(TArg arg);
    }
}
