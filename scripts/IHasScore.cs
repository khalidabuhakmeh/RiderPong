using Godot;

public interface IHasScore
{
    StringName Name { get; }
    int Score { get; set; }
    Label ScoreDisplay { get; set; }
    void IncrementScore()
    {
        Score++;
        if (ScoreDisplay is not null) {
            ScoreDisplay.Text = $"{Score}";
        }
    }
}