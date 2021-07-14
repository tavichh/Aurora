using System.Collections.Generic;
using System.Linq;
using aurora.core;
using aurora.groups.laws;
using Sandbox;
namespace aurora.groups
{
	/// <summary>
	/// Groups allow players to collectivize and promote their own interests within the server. Interests that may or may not be within their job's reach.
	/// </summary>
	public class Group : NetworkComponent
	{
		private Management GroupManager { get; set; } = new Management ();

		public Group ( )
		{
			/*
			 * This is all placeholder data but nonetheless needs to be initialized.
			 * This is the name and ticker of the group.
			 */
			GroupManager.GroupName = "Stadek";
			GroupManager.GroupTicker = "STDK".ToUpper ();
			/*
			 * The idea for such a high tax is that players will act fast to level up their group by generating a income stream for their group.
			 * As the group levels up, it may (or may not) make more sense for the leader(s) to lower the tax rate in order to provide for their members.
			 */
			GroupManager.Taxes.Add ( Tax.RoundBegins , 95 );
			GroupManager.Taxes.Add ( Tax.UserBecomesIdle , 100 );
			GroupManager.Taxes.Add ( Tax.DepositMoney , 50 );
			GroupManager.Taxes.Add ( Tax.UserSellsToGroup , 15 );
			GroupManager.Taxes.Add ( Tax.UserBuysFromGroup , 5 );
			GroupManager.Taxes.Add ( Tax.UserBuys , 50 );
			GroupManager.Taxes.Add ( Tax.UserSells , 50 );
			GroupManager.Taxes.Add ( Tax.UserBuysProperty , 60 );
			GroupManager.Taxes.Add ( Tax.UserSellsProperty , 90 );
			GroupManager.Taxes.Add ( Tax.WithdrawMoney , 10 );
			/*
			 * This sets the group level to 1 / 5. Every group level unlocks more features for the group since having all of the features unlocked at
			 * the first level would make the player lose out on failed attempts and the "journey" of leveling up.
			 * Things that are unlocked are more "catered" succession types aswell as better restrictions and laws to impose on members.
			 */
			GroupManager.SetGroupLevel ( 1 );
			/*
			 * This controls what specifically happens when the player dies. In the event of their death, a new leader (or group of leaders) has to be chosen
			 * and this determines specifically how that is done.
			 */
			GroupManager.SetSuccession ( GroupSystem.SuccessionTypes.First ( x => x.Name == "hereditary" ) ); // will replace linq query with proper method
			GroupManager.Restrictions.Add ( new WeaponLegality ( true ) );
		}
	}
}
