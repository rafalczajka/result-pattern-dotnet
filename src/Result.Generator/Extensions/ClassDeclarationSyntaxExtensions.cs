using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PxBunny.Result.Generator.Extensions;

internal static class ClassDeclarationSyntaxExtensions
{
    public static string GetFullName(this ClassDeclarationSyntax node, SemanticModel model)
    {
        var symbol = model.GetDeclaredSymbol(node);
        return symbol is null ? node.Identifier.Text : symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
    }

    public static IEnumerable<SeparatedSyntaxList<ParameterSyntax>> GetConstructorParameters(
        this ClassDeclarationSyntax node)
    {
        var primaryConstructorParameters = node.ParameterList?.Parameters;

        var constructorParameters = node.DescendantNodes()
            .OfType<ConstructorDeclarationSyntax>()
            .Select(constructor => constructor.ParameterList.Parameters);

        return primaryConstructorParameters is null
            ? constructorParameters
            : constructorParameters.Concat([(SeparatedSyntaxList<ParameterSyntax>)primaryConstructorParameters]);
    }

    public static bool IsErrorType(this ClassDeclarationSyntax node)
    {
        return node.BaseList?.Types.Any(baseType => baseType.Type.ToString() == "ErrorBase") == true;
    }
}
