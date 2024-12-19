using System.Text.RegularExpressions;
using RoomDescriptor.Library.Tokens;

namespace RoomDescriptor.Library.Scanners;

public partial class SkipScanner : ParentScanner, ITokenScanner<SkipToken>
{
	private const string Pattern = @"^s(?:(?<len>\d+)|(?<all>X))$";

	private const string BindErrorMessage = "Failed to bind skip token.";

	[GeneratedRegex(Pattern)]
	private static partial Regex SkipRegex();

    public SkipToken Scan(string input)
    {
		MatchCollection matches = SkipRegex().Matches(input);
		if (matches.Count == 0) throw new Exception($"{BindErrorMessage} No matches found.");

		string? len = GetGroup(matches, "len")?.Value;
		string? all = GetGroup(matches, "all")?.Value;

		if (!string.IsNullOrEmpty(all)) len = "0";

		int length = int.Parse(len!);

		return new(length);
    }
}