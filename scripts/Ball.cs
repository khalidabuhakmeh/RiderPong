using Godot;
using System;

public partial class Ball : Area2D
{
	[Export]
	public double MoveSpeed = 10_000;
	[Export]
	public Vector2 Direction = Vector2.Left;

	private AudioStreamPlayer BounceSound;
	
	private double CurrentSpeed;
	
	private static readonly Vector2 StartingPoint = new() { X = 642, Y = 360 };
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CurrentSpeed = MoveSpeed;
		BounceSound = GetNode<AudioStreamPlayer>("Bounce");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CurrentSpeed += delta * 2;		
		Position = Position with
		{
			X = (float)(Position.X + MoveSpeed * delta * Direction.X),
			Y = (float)(Position.Y + MoveSpeed * delta * Direction.Y)
		};
	}

	public void Reset(Vector2 direction)
	{
		Direction = direction;
		Position = StartingPoint;
		CurrentSpeed = MoveSpeed;
	}

	public void Bounce(Vector2 direction)
	{
		Direction = direction;
		BounceSound.Play();
	}
}
