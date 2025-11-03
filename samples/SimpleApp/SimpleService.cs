using PxBunny.Result;
using PxBunny.Result.Generator;

namespace SimpleApp;

public static class SimpleService
{
    public static Result<decimal> Divide(decimal a, decimal b)
    {
        return b == 0 ? Errors.SimpleError("Divide by zero error") : a / b;
    }
}
