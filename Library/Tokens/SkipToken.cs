namespace RoomDescriptor.Library.Tokens;

public class SkipToken(int length) : IToken
{
	public const char Identifier = 's';

	public int Length { get; set; } = length;

    public override string ToString() => $"SkipToken {{{nameof(Length)}: {Length}}}";

    public override bool Equals(object? obj) => obj is SkipToken other &&
		other.GetHashCode() == GetHashCode();

    public override int GetHashCode() => HashCode.Combine(
		Length.GetHashCode()
	);
}