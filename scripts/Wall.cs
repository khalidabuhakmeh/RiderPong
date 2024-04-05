using Godot;
using System;

public partial class Wall : Area2D
{
	[Export]
	public Vector2 BallResetDirection = Vector2.Left;
	
	[Export]
	public Node2D Scorer { get; set; }
	
	private AudioStreamPlayer scoreSound;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		scoreSound = GetNode<AudioStreamPlayer>("ScoreSound");
	}

	public void OnAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			ball.Reset(BallResetDirection);
			if (Scorer is IHasScore scoring)
			{
				GD.Print($"{Scorer.Name} scored!");
				scoring.IncrementScore();
				scoreSound.Play();
			}
		}
	}
}
