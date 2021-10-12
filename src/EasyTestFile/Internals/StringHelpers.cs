namespace EasyTestFile.Internals;

using System;
using System.Text.RegularExpressions;

internal static class StringHelpers
{
    public static string StringReplaceIgnoreCase(in string input, in string search, in string replace)
    {
#if NETSTANDARD2_0

        const string REP = "THISisAstupidReplacementAndAStupidWorkaround";
        var inputSanitized = input.Replace("\\", REP);
        var searchSanitized = search.Replace("\\", REP);
        var result =  System.Text.RegularExpressions.Regex.Replace(inputSanitized, searchSanitized, replace, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        return result.Replace(REP, "\\");
#else
      return input.Replace(search, replace, StringComparison.InvariantCultureIgnoreCase);
#endif
    }
}