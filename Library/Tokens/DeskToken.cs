namespace RoomDescriptor.Library.Tokens;

public class DeskToken(int startIndex, int endIndex, int shiftIndex) : IToken
{
	public const char Identifier = 'd';

	public int StartIndex { get; set; } = startIndex;

	public int EndIndex { get; set; } = endIndex;

	public int ShiftIndex { get; set; } = shiftIndex;

    public override string ToString() => $"DeskToken {{{nameof(StartIndex)}: {StartIndex}, {nameof(EndIndex)}: {EndIndex}, {nameof(ShiftIndex)}: {ShiftIndex}}}";

    public override bool Equals(object? obj) => obj is DeskToken other &&
		other.GetHashCode() == GetHashCode();

    public override int GetHashCode() => HashCode.Combine(
		StartIndex.GetHashCode(),
		EndIndex.GetHashCode(),
		ShiftIndex.GetHashCode()
	);
}