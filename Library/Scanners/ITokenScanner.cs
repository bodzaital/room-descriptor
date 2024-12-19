namespace RoomDescriptor.Library.Scanners;

public interface ITokenScanner<T>
{
	T Scan(string input);
}