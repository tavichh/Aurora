using System.Collections.Generic;
using aurora.core;
namespace aurora.groups
{
	public class Commands
	{
		public List < Command > Library = new List < Command > ()
		{
			#region Creation/Disbanding
			new Command ()
			{
				Name = "Create Group" ,
				Description = "Allows the player to manage a collection of other players anyway they seem fit." ,
				Keys = new [ ]
				{
					"group create" ,
					"g c" ,
					"group c" ,
				} ,
				Prefix = Configuration.PlayerCommand.Prefix ,
				Parameters = new Dictionary < string , int > ()
				{
					{ "group_name" , 3 } ,
					{ "group_ticker" , 4 } ,
				}
			} ,
			new Command ()
			{
				Name = "Disband Group" ,
				Description
					= "Begins the process of disbanding the group if ownership does not reside directly with the player, otherwise disbands the group." ,
				Keys = new [ ]
				{
					"group disband" ,
					"g d" ,
					"group d" ,
				} ,
				Prefix = Configuration.PlayerCommand.Prefix ,
			} ,
			#endregion
			#region Management
			new Command ()
			{
				Name = "Succession Type" ,
				Description = "Allows the group owner to change how the group's successor is chosen." ,
				Keys = new [ ]
				{
					"group succession" ,
					"group s" ,
					"g s" ,
				}
			}
			#endregion
		};
	}
}
