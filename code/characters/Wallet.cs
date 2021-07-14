using Sandbox;
namespace aurora.characters
{
	public class Wallet : NetworkComponent
	{
		private float _money = 0;
		public float Money
		{
			get
			{
				if ( _money < 0 )
					Log.Warning ( $"A players wallet has fallen less than $0. This shouldn't happen. {_money:c}" );
				return _money;
			}
			set
			{
				if ( value < 0 )
					Log.Warning ( $"You are trying to set a player's wallet to something below zero! This will break something {value:c}" );
				_money = value;
			}
		}
	}
}
