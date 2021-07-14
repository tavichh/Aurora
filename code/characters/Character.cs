using aurora.inventory;
using aurora.items.weapons;
using Sandbox;
namespace aurora.characters
{
	partial class Character : Player
	{
		public readonly Wallet Wallet = new Wallet ();
		public Character ( )
		{
			Inventory = new Inventory ( this );
		}
		public override void Respawn ( )
		{
			SetModel ( "models/citizen/citizen.vmdl" );
			Controller = new WalkController ();
			Animator = new StandardPlayerAnimator ();
			Camera = new FirstPersonCamera ();
			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
			Initialize ();
			base.Respawn ();
		}
		private void Initialize ( )
		{
			Inventory.Add ( new RustyPistol () );
		}
		public override void Simulate ( Client cl )
		{
			base.Simulate ( cl );
			SimulateActiveChild ( cl , ActiveChild );
		}
		public override void OnKilled ( )
		{
			base.OnKilled ();
			EnableDrawing = false;
		}
	}
}
