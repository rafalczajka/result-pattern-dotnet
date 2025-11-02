using System;
using PxBunny.Result.Internal;

namespace PxBunny.Result;

public sealed class Result<TData> : ResultBase<TData>
{
    private Result(TData data) : base(data) { }

    private Result(ErrorBase error) : base(error) { }

    public void Switch(Action<TData> onSuccess, Action<ErrorBase> onFailure)
    {
        if (IsSuccess)
        {
            onSuccess(Data!);
            return;
        }

        onFailure(Error!);
    }

    public TResult Match<TResult>(Func<TData, TResult> onSuccess, Func<ErrorBase, TResult> onFailure) =>
        IsSuccess ? onSuccess(Data!) : onFailure(Error!);

    public static implicit operator Result<TData>(TData data) => new(data);

    public static implicit operator Result<TData>(ErrorBase error) => new(error);
}

public sealed class Result : ResultBase<Unit>
{
    private Result(Unit value) : base(value) { }

    private Result(ErrorBase error) : base(error) { }

    public static Result Success() => new(Unit.Value);

    public void Switch(Action onSuccess, Action<ErrorBase> onFailure)
    {
        if (IsSuccess)
        {
            onSuccess();
            return;
        }

        onFailure(Error!);
    }

    public TResult Match<TResult>(Func<TResult> onSuccess, Func<ErrorBase, TResult> onFailure) =>
        IsSuccess ? onSuccess() : onFailure(Error!);

    public static implicit operator Result(Unit value) => new(value);

    public static implicit operator Result(ErrorBase error) => new(error);
}
