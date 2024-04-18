using Godot;
using System;

public partial class PauseScreen : RichTextLabel
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			GD.Print("Pausing Game");
		
			if (Visible)
			{
				Hide();
				GetTree().Paused = false;
			}
			else
			{
				Show();
				GetTree().Paused = true;
			}
		}
	}
}
