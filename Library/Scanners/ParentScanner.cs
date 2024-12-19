using System.Text.RegularExpressions;

namespace RoomDescriptor.Library.Scanners;

public abstract class ParentScanner
{
	protected Group? GetGroup(MatchCollection matches, string groupName) =>
		matches.First().Groups.Values.FirstOrDefault((x) => x.Name == groupName);
}