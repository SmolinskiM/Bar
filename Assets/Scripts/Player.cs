public class Player : SingletoneMonobehaviour<Player>
{
    private Cup cup;

    private int score;

    public int Score { get { return score; } set { score = value; } }
    public Cup Cup { get { return cup; } set { cup = value; } }
}
