using System.ComponentModel;

namespace PxBunny.Result;

[EditorBrowsable(EditorBrowsableState.Never)]
public abstract class ResultBase<TData>
{
    protected ResultBase(TData data)
    {
        Data = data;
        Error = null;
    }

    protected ResultBase(ErrorBase error)
    {
        Data = default;
        Error = error;
    }

    public bool IsSuccess => Error is null;

    public bool IsFailure => !IsSuccess;

    public ErrorBase? Error { get; }

    protected TData? Data { get; }

    public bool TryGet(out TData data)
    {
        data = Data!;
        return IsSuccess;
    }

    public void Deconstruct(out bool isSuccess, out TData? data, out ErrorBase? error)
    {
        isSuccess = IsSuccess;
        data = Data;
        error = Error;
    }
}
