using aurora.equipment;
using aurora.items.weapons;
using Sandbox;
namespace aurora.characters
{
	partial class Character : Player
	{
		DamageInfo LastDamage;
		static EntityLimit RagdollLimit = new EntityLimit { MaxTotal = 20 };
		public readonly Wallet Wallet = new Wallet ();
		public Character ( ) => Inventory = new Equipment ( this );
		public override void Respawn ( )
		{
			Log.Info ( "Checking if you are whitelisted to play..." );
			if ( Local.SteamId is not (76561198014753825 or 76561198121756693) )
				return; // a simple whitelist to prevent people from joining and asking what aurora is.
			SetModel ( "models/citizen/citizen.vmdl" );
			Controller = new WalkController ();
			Animator = new StandardPlayerAnimator ();
			Camera = new FirstPersonCamera ();
			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
			base.Respawn ();
		}

		public override void Simulate ( Client cl )
		{
			base.Simulate ( cl );
			SimulateActiveChild ( cl , ActiveChild );
		}
		public override void OnKilled ( )
		{
			base.OnKilled ();
			Inventory.DropActive ();
			Inventory.DeleteContents ();
			BecomeRagdollOnClient ( LastDamage.Force , GetHitboxBone ( LastDamage.HitboxIndex ) );
			Controller = null;
			Camera = new SpectateRagdollCamera ();
			EnableAllCollisions = false;
			EnableDrawing = false;
		}
		[ ClientRpc ]
		void BecomeRagdollOnClient ( Vector3 force , int forceBone )
		{
			var ent = new ModelEntity ();
			ent.Position = Position;
			ent.Rotation = Rotation;
			ent.MoveType = MoveType.Physics;
			ent.UsePhysicsCollision = true;
			ent.SetInteractsAs ( CollisionLayer.Debris );
			ent.SetInteractsWith ( CollisionLayer.WORLD_GEOMETRY );
			ent.SetInteractsExclude ( CollisionLayer.Player | CollisionLayer.Debris );
			ent.SetModel ( GetModelName () );
			ent.CopyBonesFrom ( this );
			ent.TakeDecalsFrom ( this );
			ent.SetRagdollVelocityFrom ( this );
			ent.DeleteAsync ( 120.0f );
			ent.PhysicsGroup.AddVelocity ( force );
			if ( forceBone >= 0 )
			{
				var body = ent.GetBonePhysicsBody ( forceBone );
				if ( body != null )
					body.ApplyForce ( force * 1000 );
				else
					ent.PhysicsGroup.AddVelocity ( force );
			}
			Corpse = ent;
			RagdollLimit.Watch ( ent );
		}
		
	}
}
