using Godot;

public partial class Rail : Area2D
{
	[Export]
	private int bounceDirection = 1;

	public void OnAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			var direction = (ball.Direction + new Vector2(0, bounceDirection)).Normalized();
			ball.Bounce(direction);
		}
	}
}
