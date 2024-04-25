using Godot;

public interface IHasScore
{
    StringName Name { get; }
    int Score { get; set; }
    Label ScoreDisplay { get; set; }
    AudioStreamPlayer ScoreSound { get; }
    void IncrementScore()
    {
        Score++;
        if (ScoreDisplay is not null)
        {
            ScoreDisplay.Text = $"{Score}";
            GD.Print($"{Name} scored. Currently at {Score}.");
        }

        ScoreSound?.Play();
    }
}