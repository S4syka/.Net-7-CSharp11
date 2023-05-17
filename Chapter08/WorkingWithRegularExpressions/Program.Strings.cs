using System.Diagnostics.CodeAnalysis; // [StringSyntax]

partial class Program
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    const string digitsOnlyText = @"^\d+$";

    [StringSyntax(StringSyntaxAttribute.Regex)]
    const string commaSeparatorText = "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)";

    [StringSyntax(StringSyntaxAttribute.DateTimeFormat)]
    const string fullDateTime = "yyyyy";
}