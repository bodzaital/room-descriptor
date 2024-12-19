using RoomDescriptor.Library.Scanners;
using RoomDescriptor.Library.Tokens;

namespace RoomDescriptor.Tests;

[TestFixture]
public class DeskScannerTests
{
    private DeskScanner? _deskScanner;

    [SetUp]
    public void Setup()
    {
        _deskScanner = new();
    }

	[Test]
	public void CanParseShortTokenSingleDigit()
	{
		string input = "d1";
		DeskToken expected = new(1, 1, 0);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenDoubleDigit()
	{
		string input = "d10";
		DeskToken expected = new(10, 10, 0);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenSingleSingleDigit()
	{
		string input = "d1..2";
		DeskToken expected = new(1, 2, 0);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenSingleDoubleDigit()
	{
		string input = "d1..20";
		DeskToken expected = new(1, 20, 0);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenDoubleSingleDigit()
	{
		string input = "d10..2";
		DeskToken expected = new(10, 2, 0);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenDoubleDoubleDigit()
	{
		string input = "d10..20";
		DeskToken expected = new(10, 20, 0);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenSingleDigitWithShift()
	{
		string input = "d1s1";
		DeskToken expected = new(1, 1, 1);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenDoubleDigitWithShift()
	{
		string input = "d10s1";
		DeskToken expected = new(10, 10, 1);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenSingleSingleDigitWithShift()
	{
		string input = "d1..2s1";
		DeskToken expected = new(1, 2, 1);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenSingleDoubleDigitWithShift()
	{
		string input = "d1..20s1";
		DeskToken expected = new(1, 20, 1);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenDoubleSingleDigitWithShift()
	{
		string input = "d10..2s1";
		DeskToken expected = new(10, 2, 1);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}

	[Test]
	public void CanParseShortTokenDoubleDoubleDigitWithShift()
	{
		string input = "d10..20s1";
		DeskToken expected = new(10, 20, 1);

        DeskToken actual = _deskScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
	}
}