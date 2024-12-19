using System.Text.RegularExpressions;
using RoomDescriptor.Library.Tokens;

namespace RoomDescriptor.Library.Scanners;

public partial class BoundaryScanner : ParentScanner, ITokenScanner<BoundaryToken>
{
	private const string Pattern = @"^b(?<wid>\d+)(?:\/(?<hei>\d+))?$";

	private const string BindErrorMessage = "Failed to bind boundary token.";

	[GeneratedRegex(Pattern)]
	private static partial Regex BoundaryRegex();

	public BoundaryToken Scan(string input)
	{
		MatchCollection matches = BoundaryRegex().Matches(input);
		if (matches.Count == 0) throw new Exception($"{BindErrorMessage} No matches found.");

		string wid = GetGroup(matches, "wid")!.Value;
		string? hei = GetGroup(matches, "hei")?.Value;

		if (string.IsNullOrEmpty(hei)) hei = wid;
		
		int width = int.Parse(wid);
		int height = int.Parse(hei);

        return new(width, height);
	}
}
