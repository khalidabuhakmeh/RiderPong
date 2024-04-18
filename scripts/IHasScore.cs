using Godot;

/// <summary>
/// The Airspeed velocity of an unladen swallow
/// is 20.1 mph (32.4 kph) 🐦‍⬛
/// </summary>
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