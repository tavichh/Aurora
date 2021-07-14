using aurora.characters;
using aurora.ui;
using Sandbox;
namespace aurora.core
{
	/// <summary>
	/// The base gamemode (Aurora)
	/// </summary>
	[ Library ( "aurora" ,
		Title = "The Aurora Framework" ,
		Description = "The Aurora Framework is open-source building block for the creation of gamemodes within S&Box and is under development by stadek." ) ]
	public partial class Aurora : Game
	{
		public Aurora ( )
		{
			if ( IsServer ) new AuroraHud ();
		}
		public override void ClientJoined ( Client client )
		{
			base.ClientJoined ( client );
			var player = new Character ();
			client.Pawn = player;
			player.Respawn ();
		}
		[ ServerCmd ( "spawn_entity" ) ]
		public static void SpawnEntity ( string entName )
		{
			var owner = ConsoleSystem.Caller.Pawn;
			if ( owner == null )
				return;
			var attribute = Library.GetAttribute ( entName );
			if ( attribute == null || ! attribute.Spawnable )
				return;
			var tr = Trace.Ray ( owner.EyePos , owner.EyePos + owner.EyeRot.Forward * 200 )
				.UseHitboxes ()
				.Ignore ( owner )
				.Size ( 2 )
				.Run ();
			var ent = Library.Create < Entity > ( entName );
			if ( ent is BaseCarriable && owner.Inventory != null )
			{
				if ( owner.Inventory.Add ( ent , true ) )
					return;
			}
			ent.Position = tr.EndPos;
			ent.Rotation = Rotation.From ( new Angles ( 0 , owner.EyeRot.Angles ().yaw , 0 ) );
		}
	}
}
