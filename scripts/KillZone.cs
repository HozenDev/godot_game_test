using Godot;
using System;

public partial class KillZone : Area2D
{ 
	Timer timer = null;
	
	public override void _Ready() {
		timer = GetNode<Timer>("Timer");
	}
	
  	private void OnKillZoneBodyEntered(Node2D body) {
		GD.Print("You died!");
		Engine.TimeScale = 0.5;
		body.GetNode("CollisionShape2D").QueueFree();
		timer.Start();
	}
	
	private void OnTimerTimeout() {
		Engine.TimeScale = 1.0;
		GetTree().ReloadCurrentScene();
	}
}
