using Godot;
using System;

public partial class Slime : CharacterBody2D
{
	public const float Speed = 30.0f;
	private Vector2 direction;
	private RayCast2D rayCastLeft;
	private RayCast2D rayCastRight;
	private AnimatedSprite2D sprite;
	
	public override void _Ready() {
		direction = new Vector2(1, 0);
		rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		rayCastRight = GetNode<RayCast2D>("RayCastRight");
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (rayCastRight.IsColliding() || rayCastLeft.IsColliding()) {
			direction.X *= -1;
		}
		
		sprite.FlipH = (direction.X < 0);
		velocity.X = direction.X * Speed;

		Velocity = velocity;
		MoveAndSlide();
	}
}
