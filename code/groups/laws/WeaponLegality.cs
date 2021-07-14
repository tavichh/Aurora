using System.Collections.Generic;
namespace aurora.groups.laws
{
	public class WeaponLegality:IRestriction
	{
		public string Title { get; set; }
		public List < Role > PertainingTo { get; set; }
		public List < Violations > Penalties { get; set; }
		public void OnRestrictionEnabled ( ) { throw new System.NotImplementedException (); }
		public void OnRestrictionDisabled ( ) { throw new System.NotImplementedException (); }

		public WeaponLegality ( bool active)
		{
			Title = "Civil Weapon Possession";
			Penalties.Add ( Violations.Fine );
		}
	}
}
