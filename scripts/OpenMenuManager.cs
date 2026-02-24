using Godot;
using System;

public partial class OpenMenuManager : MarginContainer
{
	private Control menuScreen;
	private Control openMenu;
	private Control helpMenu;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		menuScreen = GetNode<Control>("baseMenuScreenContainer");
		openMenu = GetNode<Control>("openMenuScreenContainer");
		helpMenu = GetNode<Control>("helpMenuContainer");
	}
	
	public void ToggleVisibility(Control container) {
		container.Visible = !container.Visible;
	}
	
	public void OnMenuButtonPressed() {
		ToggleVisibility(menuScreen);
		ToggleVisibility(openMenu);
	}
	
	public void OnToggleHelpMenuButtonPressed() {
		ToggleVisibility(helpMenu);
		ToggleVisibility(menuScreen);
	}
}
