using RoomDescriptor.Library.Scanners;
using RoomDescriptor.Library.Tokens;

namespace RoomDescriptor.Tests;

[TestFixture]
public class BoundaryScannerTests
{
    private BoundaryScanner? _boundaryScanner;

    [SetUp]
    public void Setup()
    {
        _boundaryScanner = new();
    }

    [Test]
    public void CanParseShortTokensSingleDigit()
    {
        string input = "b2";
        BoundaryToken expected = new(2, 2);

        BoundaryToken actual = _boundaryScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CanParseShortTokensDoubleDigit()
    {
        string input = "b20";
        BoundaryToken expected = new(20, 20);

        BoundaryToken actual = _boundaryScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CanParseLongTokensSingleSingleDigit()
    {
        string input = "b1/2";
        BoundaryToken expected = new(1, 2);

        BoundaryToken actual = _boundaryScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CanParseLongTokensSingleDoubleDigit()
    {
        string input = "b1/20";
        BoundaryToken expected = new(1, 20);

        BoundaryToken actual = _boundaryScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CanParseLongTokensDoubleSingleDigit()
    {
        string input = "b10/2";
        BoundaryToken expected = new(10, 2);

        BoundaryToken actual = _boundaryScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CanParseLongTokensDoubleDoubleDigit()
    {
        string input = "b10/20";
        BoundaryToken expected = new(10, 20);

        BoundaryToken actual = _boundaryScanner!.Scan(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
