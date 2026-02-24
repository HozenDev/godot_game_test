using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 170.0f;
	public const float JumpVelocity = -300.0f;
	private AnimatedSprite2D sprite;
	private Vector2 direction;
	
	public override void _Ready()
	{
		direction = new Vector2(0, 0);
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

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		direction.X = Input.GetAxis("move_left", "move_right");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			sprite.FlipH = (direction.X < 0);
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		
		// animation 
		if (IsOnFloor()) {
			if (direction != Vector2.Zero)
			{
				sprite.Play("run");
			}
			else {
				sprite.Play("idle");
			}
		}
		else {
			sprite.Play("jump");
		}
		
		

		Velocity = velocity;
		MoveAndSlide();
	}
}
