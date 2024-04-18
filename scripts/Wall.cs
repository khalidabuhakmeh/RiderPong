using Godot;
using System;

public partial class Wall : Area2D
{
	[Export]
	public Vector2 BallResetDirection = Vector2.Left;
	
	[Export]
	public Node2D Scorer { get; set; }

	public void OnAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			ball.Reset(BallResetDirection);
			if (Scorer is IHasScore scoring)
			{
				
				scoring.IncrementScore();
			}
		}
	}
}
