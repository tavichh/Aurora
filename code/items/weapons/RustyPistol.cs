using System;
using Sandbox;
namespace aurora.items.weapons
{
	[ Library ( "weapon_rust_pistol" , Title = "Rusty Pistol" , Spawnable = true ) ]
	public partial class RustyPistol : Weapon
	{
		public override float DamageBase { get; set; } = 20.000f;
		public override float DamageOffset { get; set; } = 12.500f;
		public override string ViewModelPath => "weapons/rust_pistol/v_rust_pistol.vmdl";
		public override float PrimaryRate => 15.0f;
		public override float SecondaryRate => 1.0f;
		public override int ClipSize { get; set; } = 13;
		public override int RoundsLeft { get; set; } = 13;
		private TimeSince TimeSinceDischarge { get; set; }
		public override void Spawn ( )
		{
			base.Spawn ();
			SetModel ( "weapons/rust_pistol/rust_pistol.vmdl" );

		}
		public override bool CanPrimaryAttack ( ) => base.CanPrimaryAttack () && Input.Pressed ( InputButton.Attack1 );
		public override void AttackPrimary ( )
		{
			if ( RoundsLeft is not 0 )
			{
				TimeSincePrimaryAttack = 0;
				TimeSinceSecondaryAttack = 0;
				( Owner as AnimEntity )?.SetAnimBool ( "b_attack" , true );
				ShootEffects ();
				PlaySound ( "rust_pistol.shoot" );
				ShootBullet ( 0.05f , 1.5f , CalculateDamage () , 3.0f );
				RoundsLeft -= 1;
			}
		
		}
		private void Discharge ( )
		{
			if ( TimeSinceDischarge < 0.5f )
				return;
			TimeSinceDischarge = 0;
			var muzzle = GetAttachment ( "muzzle" ) ?? default;
			var pos = muzzle.Position;
			var rot = muzzle.Rotation;
			ShootEffects ();
			PlaySound ( "rust_pistol.shoot" );
			ShootBullet ( pos , rot.Forward , 0.05f , 1.5f , CalculateDamage () , 3.0f );
			ApplyAbsoluteImpulse ( rot.Backward * 500.0f );
		}
		protected override void OnPhysicsCollision ( CollisionEventData eventData )
		{
			if ( eventData.Speed > 500.0f ) Discharge ();
		}
	}
}
