using System;
using Godot;

public partial class Enemy : Area2D, IHasScore
{
	[Export]
	private Area2D follow;
	
	[Export]
	private float difficulty = 0.3f;
	
	public int Score { get; set; } = 0;
	
	[Export]
	public Label ScoreDisplay { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        // position.y = position.lerp(_ball.position, (MOVE_SPEED / 10) * delta).y
        // complicated AI
        Position = Position with
        {
	        Y = Position.Lerp(follow.Position, difficulty / 10).Y
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