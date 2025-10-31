using System;

namespace PxBunny.Result;

public class Result<TData>
{
    private readonly TData? _data;
    private readonly ErrorBase? _error;

    private Result(TData data)
    {
        _data = data;
        _error = null;
    }

    private Result(ErrorBase error)
    {
        _data = default;
        _error = error;
    }

    private bool IsSuccess => _error is null;

    public static implicit operator Result<TData>(TData data) => new(data);

    public static implicit operator Result<TData>(ErrorBase error) => new(error);

    public TResult Match<TResult>(
        Func<TData, TResult> onSuccess,
        Func<ErrorBase, TResult> onFailure)
        => IsSuccess ? onSuccess(_data!) : onFailure(_error!);
}

public class Result
{
    private readonly ErrorBase? _error;

    private Result(ErrorBase? error)
    {
        _error = error;
    }

    private bool IsSuccess => _error is null;

    public static implicit operator Result(ErrorBase error) => new(error);

    public static Result Success() => new(null);

    public TResult Match<TResult>(
        Func<TResult> onSuccess,
        Func<ErrorBase, TResult> onFailure)
        => IsSuccess ? onSuccess() : onFailure(_error!);
}
