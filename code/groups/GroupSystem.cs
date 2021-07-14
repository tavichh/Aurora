using System.Collections.Generic;
using aurora.groups.successions;
namespace aurora.groups
{
	public static class GroupSystem
	{
		public static readonly List < ISuccessionType > SuccessionTypes = new List < ISuccessionType > ()
		{
			new Hereditary () ,
		};
	}
}
