using Sandbox;
using Sandbox.UI;
namespace aurora.ui
{

	public partial class AuroraHud : HudEntity < RootPanel >
	{
		public AuroraHud ( )
		{
			if ( ! IsClient ) return;
			RootPanel.SetTemplate ( "ui/hud.scss" );
			RootPanel.AddChild < NameTags > ();
			RootPanel.AddChild < CrosshairCanvas > ();
			RootPanel.AddChild < ChatBox > ();
			RootPanel.AddChild < VoiceList > ();
			RootPanel.AddChild < KillFeed > ();
			RootPanel.AddChild < Scoreboard < ScoreboardEntry > > ();
			RootPanel.AddChild <Inventory>();
		}
	}
}
