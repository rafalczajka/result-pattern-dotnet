using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PxBunny.Result;

internal static class Extensions
{
    public static string GetName(this ClassDeclarationSyntax node)
    {
        return node.Identifier.Text;
    }

    public static string GetFullName(this ClassDeclarationSyntax node, SemanticModel model)
    {
        var symbol = model.GetDeclaredSymbol(node);

        return symbol is null
            ? node.GetName()
            : symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
    }
}
