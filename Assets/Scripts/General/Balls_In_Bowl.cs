using UnityEngine;

public class Balls_In_Bowl : MonoBehaviour
{
    [SerializeField] Balls_In_Bowl_Object BallsInBowl;

    public void BallEnterBowl(Ball ball)
    {
        switch (ball.GetSize())
        {
            case BallSize.tiny:
                BallsInBowl.Tiny++;
                break;
            case BallSize.Small:
                BallsInBowl.Small++;
                break;
            case BallSize.Medium:
                BallsInBowl.Medium++;
                break;
            case BallSize.Large:
                BallsInBowl.large++;
                break;
            case BallSize.Huge:
                BallsInBowl.Huge++;
                break;
            case BallSize.Mega:
                BallsInBowl.Mega++;
                break;
            case BallSize.Gold:
                BallsInBowl.Gold++;
                break;
            case BallSize.Resize:
                BallsInBowl.Resize++;
                break;
            case BallSize.Multi:
                BallsInBowl.Multi++;
                break;
        }
    }

    public void BallExitBowl(Ball ball)
    {
        switch (ball.GetSize())
        {
            case BallSize.tiny:
                BallsInBowl.Tiny--;
                break;
            case BallSize.Small:
                BallsInBowl.Small--;
                break;
            case BallSize.Medium:
                BallsInBowl.Medium--;
                break;
            case BallSize.Large:
                BallsInBowl.large--;
                break;
            case BallSize.Huge:
                BallsInBowl.Huge--;
                break;
            case BallSize.Mega:
                BallsInBowl.Mega--;
                break;
            case BallSize.Gold:
                BallsInBowl.Gold--;
                break;
            case BallSize.Resize:
                BallsInBowl.Resize--;
                break;
            case BallSize.Multi:
                BallsInBowl.Multi--;
                break;
        }
    }
}
