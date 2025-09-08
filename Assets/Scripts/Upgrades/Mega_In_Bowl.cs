using UnityEngine;

public class Mega_In_Bowl : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Balls_In_Bowl_Object BallsInBowl;
    [SerializeField] float BallSizeAmount = -0.05f;

    public void MageEnterBowl(Ball ball)
    {
        if (ball.GetSize() == BallSize.Mega)
        {
            if (Upgrades.BowlSizeForEachMega == true)
            {
                Upgrades.ChangeBowlSize(1);
            }
            if (Upgrades.BallSizeForEachMega == true)
            {
                Upgrades.ChangeBallSize(BallSizeAmount);
            }
        }
    }

    public void MageExitBowl(Ball ball)
    {
        if (ball.GetSize() == BallSize.Mega)
        {
            if (Upgrades.BowlSizeForEachMega == true)
            {
                Upgrades.ChangeBowlSize(-1);
            }
            if (Upgrades.BallSizeForEachMega == true)
            {
                Upgrades.ChangeBallSize(Mathf.Abs(BallSizeAmount));
            }
        }
    }

    private void OnDisable()
    {
        if (Upgrades.BowlSizeForEachMega == true)
        {
            Upgrades.ChangeBowlSize(-BallsInBowl.Mega);
        }
        if (Upgrades.BallSizeForEachMega == true)
        {
            Upgrades.ChangeBallSize(BallsInBowl.Mega * Mathf.Abs(BallSizeAmount));
        }
    }
}
