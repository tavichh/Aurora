using System.Collections.Generic;
using aurora.groups.laws;
using aurora.groups.successions;
using Sandbox;
namespace aurora.groups
{
	public class Management:NetworkComponent
	{
		public List < Role > Roles { get; set; }
		public List < IRestriction > Restrictions { get; set; }
		public string GroupName { get; set; }
		public string GroupTicker { get; set; }

		public Dictionary < Tax , float > Taxes { get; set; }
		public ISuccessionType Succession { get; set; }

		public void SetSuccession ( ISuccessionType type )
		{
		}
		public void SetGroupLevel ( int level )
		{
		}
	}
}
