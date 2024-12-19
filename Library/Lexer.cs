using System.Diagnostics;
using RoomDescriptor.Library.Scanners;
using RoomDescriptor.Library.Tokens;

namespace RoomDescriptor.Library;

public class Lexer(ITokenScanner<BoundaryToken> boundaryTokenScanner, ITokenScanner<SkipToken> skipTokenScanner, ITokenScanner<DeskToken> deskTokenScanner)
{
	private const string BindErrorMessage = "Failed to bind token.";

	private readonly Stopwatch _stopwatch = new();

	public List<IToken> Tokenize(string input)
	{
		_stopwatch.Restart();

		input = SanitizeInput(input);
		input = CollapseLinesBreaks(input);

		List<string> tokens = SplitInputAsTokens(input);
		List<IToken> boundTokens = ScanTokens(tokens);

		_stopwatch.Stop();

		return boundTokens;
	}

	public string CollapseLinesBreaks(string input) => input
		.Replace("\r", " ")
		.Replace("\n", " ");

	public string SanitizeInput(string input) => input.Trim();

	public List<string> SplitInputAsTokens(string input) => [.. input
		.Split(" ", StringSplitOptions.RemoveEmptyEntries)
		.Select((x) => x.Trim())
	];

	public IToken ScanToken(string input) => input[0] switch
	{
		BoundaryToken.Identifier => boundaryTokenScanner.Scan(input),
		SkipToken.Identifier => skipTokenScanner.Scan(input),
		DeskToken.Identifier => deskTokenScanner.Scan(input),
		_ => throw new Exception($"{BindErrorMessage} Unknown token."),
	};

	public List<IToken> ScanTokens(List<string> tokens) => [.. tokens
		.Select(ScanToken)
	];

	public TimeSpan LastTokenizationDuration() => _stopwatch.Elapsed;
}