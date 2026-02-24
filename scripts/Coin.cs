using Godot;
using System;

public partial class Coin : Area2D
{
	private void OnCoinBodyEntered(Node2D body)
	{
		GD.Print("+1 coin");
		QueueFree();
	}
}
