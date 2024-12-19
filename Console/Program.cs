using RoomDescriptor.Library;
using RoomDescriptor.Library.Scanners;
using RoomDescriptor.Library.Tokens;

string input = string.Join(" ", args);

Lexer lexer = new(
	new BoundaryScanner(),
	new SkipScanner(),
	new DeskScanner()
);

List<IToken> tokens = lexer.Tokenize(input);

string output = string.Join(Environment.NewLine, tokens.Select((x) => x.ToString()));

Console.WriteLine(output);
Console.WriteLine(lexer.LastTokenizationDuration());