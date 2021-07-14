using System.Collections.Generic;
namespace aurora.groups.successions
{
	public interface ISuccessionType
	{
		/// <summary>
		/// The name of the succession type should it appear in game.
		/// </summary>
		string Name { get; set; }
		/// <summary>
		/// A brief description on how the succession type chooses the next ruler.
		/// </summary>
		string Description { get; set; }
		/// <summary>
		/// Which succession type will actually be called in-game.
		/// </summary>
		SuccessionTypes Succession { get; set; }
		/// <summary>
		/// The minimum level required for the group to be able to choose this type of succession.
		/// </summary>
		int UnlockAtLevel { get; set; }
		/// <summary>
		/// Those with direct power in the group.
		/// </summary>
		List < ulong > Rulers { get; set; }
	}
}
