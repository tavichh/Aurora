using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;


	public class Inventory : Panel
	{
		public Panel Container;
		public Panel SidePanel;
		public Panel CharPanel;
		public Label ItemName;
		public Button SideButton;

	


		public Inventory()
		{
			StyleSheet.Load( "/ui/Inventory.scss" );
			
			Container = Add.Panel( "menu_panel" );
			
			
			SidePanel = Container.Add.Panel( "menu_sidebar" );
			SideButton = SidePanel.Add.Button("Character", "menu_sidebar_element",() => Log.Info("Hello"));
			ItemName = SidePanel.Add.Label("Inventory", "menu_sidebar_element");
			ItemName = SidePanel.Add.Label("Attributes", "menu_sidebar_element");
			ItemName = SidePanel.Add.Label("Quests", "menu_sidebar_element");
			ItemName = SidePanel.Add.Label("Help", "menu_sidebar_element");
			
			
			CharPanel = Container.Add.Panel("character");
			ItemName = CharPanel.Add.Label("how_do_i_center", "character_info");




		}



	public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;




			base.Tick();
		}
	}

