using System.Collections.Generic;
namespace aurora.groups.successions
{
	public class Hereditary : ISuccessionType
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public SuccessionTypes Succession { get; set; }
		public int UnlockAtLevel { get; set; }
		public List < ulong > Rulers { get; set; }
		public Hereditary ( )
		{
			Name = "Hereditary";
			Description = "A system where the player's next of kin is the leader of the faction.";
			Succession = SuccessionTypes.SamePlayer;
			UnlockAtLevel = 1;
		}
	}
}
