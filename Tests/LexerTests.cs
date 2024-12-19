using NSubstitute;
using RoomDescriptor.Library;
using RoomDescriptor.Library.Scanners;
using RoomDescriptor.Library.Tokens;

namespace RoomDescriptor.Tests;

[TestFixture]
public class LexerTests
{
	private ITokenScanner<BoundaryToken>? _boundaryTokenMock;
	
	private ITokenScanner<SkipToken>? _skipTokenMock;
	
	private ITokenScanner<DeskToken>? _deskTokenMock;

	private Lexer? _lexer;

	[SetUp]
	public void SetUp() 
	{
		_boundaryTokenMock = Substitute.For<ITokenScanner<BoundaryToken>>();
		_skipTokenMock = Substitute.For<ITokenScanner<SkipToken>>();
		_deskTokenMock = Substitute.For<ITokenScanner<DeskToken>>();

		_lexer = new(_boundaryTokenMock, _skipTokenMock, _deskTokenMock);
	}

	[Test]
	public void CanCollapseLinesBreaks()
	{
		string inputWithBreaks = "one\ntwo\rthree\r\nfour five";
		
		string expected = "one two three  four five";
		string actual = _lexer!.CollapseLinesBreaks(inputWithBreaks);

		Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanSanitizeInput()
	{
		string input = "  one two      ";
		string expected = "one two";

		string actual = _lexer!.SanitizeInput(input);

		Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanSplitInput()
	{
		string input = "one two three  four";
		List<string> expected = ["one", "two", "three", "four"];

		List<string> actual = _lexer!.SplitInputAsTokens(input);

		Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanChooseBoundaryScanner()
	{
		string input = "b10";
		
		_lexer!.ScanToken(input);

		_boundaryTokenMock.Received()!.Scan(input);
		_skipTokenMock.DidNotReceive()!.Scan(input);
		_deskTokenMock.DidNotReceive()!.Scan(input);
	}

	[Test]
	public void CanChooseSkipScanner()
	{
		string input = "s10";
		
		_lexer!.ScanToken(input);

		_boundaryTokenMock.DidNotReceive()!.Scan(input);
		_skipTokenMock.Received()!.Scan(input);
		_deskTokenMock.DidNotReceive()!.Scan(input);
	}

	[Test]
	public void CanChooseDeskScanner()
	{
		string input = "d10";
		
		_lexer!.ScanToken(input);

		_boundaryTokenMock.DidNotReceive()!.Scan(input);
		_skipTokenMock.DidNotReceive()!.Scan(input);
		_deskTokenMock.Received()!.Scan(input);
	}

	[Test]
	public void UnknownTokenThrowsWhenScanning()
	{
		string input = "w10";

		Assert.Throws<Exception>(() => _lexer!.ScanToken(input));

		_boundaryTokenMock.DidNotReceive()!.Scan(input);
		_skipTokenMock.DidNotReceive()!.Scan(input);
		_deskTokenMock.DidNotReceive()!.Scan(input);
	}

	[Test]
	public void CanScanTokenList()
	{
		List<string> tokens = ["d1", "s1", "b1"];

		List<IToken> actual = _lexer!.ScanTokens(tokens);
		
		_deskTokenMock.Received()!.Scan(tokens[0]);
		_skipTokenMock.Received()!.Scan(tokens[1]);
		_boundaryTokenMock.Received()!.Scan(tokens[2]);
	}
}