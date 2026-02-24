using Godot;
using System;

public partial class StatsMenuManager : VBoxContainer
{
	private Label coinsLabel;
	private Label deadLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		coinsLabel = GetNode<Label>("coinsLabel");
		deadLabel = GetNode<Label>("deadLabel");
	}
	
	public void UpdateCoinsLabel(int nbCoins) {
		coinsLabel.Text = "Coins: " + nbCoins.ToString();
	}
	
	public void UpdateDeadLabel(int nbDeaths) {
		deadLabel.Text = "Deaths: " + nbDeaths.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
