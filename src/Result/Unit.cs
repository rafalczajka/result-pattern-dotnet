using System.Diagnostics;

namespace PxBunny.Result;

[DebuggerDisplay("()")]
public readonly struct Unit
{
    public static readonly Unit Value = new();

    public override string ToString() => "()";
}
