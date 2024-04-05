using System;
using Godot;

public partial class Player : Area2D, IHasScore
{
	[Export]
	private int moveSpeed = 200;

	[Export] private Label PlayerScoreDisplay;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Move up and down based on input.
		var input = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		var position = Position; // Required so that we can modify position.y.
		position += new Vector2(0, (float)(input * moveSpeed * delta));
		position.Y = Mathf.Clamp(position.Y, 16, GetViewportRect().Size.Y - 16);
		Position = position;
	}

	private void OnAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			var direction = new Vector2(Vector2.Right.X, (float)Random.Shared.NextDouble() * 2 - 1).Normalized();
			ball.Bounce(direction);
		}
	}

	public int Score { get; set; }
	[Export]
	public Label ScoreDisplay { get; set; }
}
