using System.Collections.Generic;
using Sandbox;
namespace aurora.groups.laws
{
	public interface IRestriction
	{
		public string Title { get; set; }
		public List < Role > PertainingTo { get; set; }
		public List < Violations > Penalties { get; set; }

		void OnRestrictionEnabled ( );
		void OnRestrictionDisabled ( );
	}
}
