using PxBunny.Result;

namespace SimpleApp;

public static class SimpleService
{
    public static Result<decimal> Divide(decimal a, decimal b)
    {
        return b == 0 ? Errors.Simple("Divide by zero error") : a / b;
    }
}
