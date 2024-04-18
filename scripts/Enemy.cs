using System;
using Godot;

public partial class Enemy : Area2D, IHasScore
{
	[Export]
	private Area2D follow;
	
	[Export]
	private float difficulty = 0.3f;
	
	public int Score { get; set; }
	
	[Export]
	public Label ScoreDisplay { get; set; }
	
	public AudioStreamPlayer ScoreSound { get; set; }

	public override void _Ready()
	{
		ScoreSound = GetNode<AudioStreamPlayer>("ScoreSound");
	}

	public override void _PhysicsProcess(double delta)
	{
		Position = Position with
		{
			// don't leave the play field
			Y = Math.Clamp(Position.Lerp(follow.Position, difficulty / 10).Y, 16, GetViewportRect().Size.Y - 16) 
		};
	}

	private void OnAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			var direction = new Vector2(Vector2.Left.X, (float)Random.Shared.NextDouble() * 2 - 1).Normalized();
			ball.Bounce(direction);
		}
	}
}
