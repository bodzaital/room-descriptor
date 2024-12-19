using RoomDescriptor.Library.Scanners;
using RoomDescriptor.Library.Tokens;

namespace RoomDescriptor.Tests;

[TestFixture]
public class SkipScannerTests
{
	private SkipScanner? _skipScanner;

	[SetUp]
	public void Setup()
	{
		_skipScanner = new();
	}

	[Test]
	public void CanParseDefiniteLengthSingleDigit()
	{
		string input = "s1";
		SkipToken expected = new(1);

		SkipToken actual = _skipScanner!.Scan(input);
		Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseDefiniteLengthDoubleDigit()
	{
		string input = "s10";
		SkipToken expected = new(10);

		SkipToken actual = _skipScanner!.Scan(input);
		Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseIndefiniteLength()
	{
		string input = "sX";
		SkipToken expected = new(0);

		SkipToken actual = _skipScanner!.Scan(input);
		Assert.That(actual, Is.EqualTo(expected));
	}
}