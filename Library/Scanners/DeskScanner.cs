using System.Text.RegularExpressions;
using RoomDescriptor.Library.Tokens;

namespace RoomDescriptor.Library.Scanners;

public partial class DeskScanner : ParentScanner, ITokenScanner<DeskToken>
{
	private const string Pattern = @"^d(?<beg>\d+)(?:(?:\.\.)(?<end>\d+))?(?:s(?<shf>\d))?$";

	private const string BindErrorMessage = "Failed to bind boundary token.";

	[GeneratedRegex(Pattern)]
	private static partial Regex BoundaryRegex();
	
    public DeskToken Scan(string input)
    {
		MatchCollection matches = BoundaryRegex().Matches(input);
		if (matches.Count == 0) throw new Exception($"{BindErrorMessage} No matches found.");

		string beg = GetGroup(matches, "beg")!.Value;
		string? end = GetGroup(matches, "end")?.Value;
		string? shf = GetGroup(matches, "shf")?.Value;

		if (string.IsNullOrEmpty(end)) end = beg;
		if (string.IsNullOrEmpty(shf)) shf = "0";

		int startIndex = int.Parse(beg);
		int endIndex = int.Parse(end);
		int shiftIndex = int.Parse(shf);

		return new(startIndex, endIndex, shiftIndex);
    }
}