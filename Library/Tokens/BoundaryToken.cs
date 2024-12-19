namespace RoomDescriptor.Library.Tokens;

public class BoundaryToken(int width, int height) : IToken
{
	public const char Identifier = 'b';

	public int Width { get; set; } = width;

	public int Height { get; set; } = height;

    public override string ToString() => $"BoundaryToken {{{nameof(Width)}: {Width}, {nameof(Height)}: {Height}}}";

    public override bool Equals(object? obj) => obj is BoundaryToken other &&
		other.GetHashCode() == GetHashCode();

    public override int GetHashCode() => HashCode.Combine(
		Width.GetHashCode(),
		Height.GetHashCode()
	);
}