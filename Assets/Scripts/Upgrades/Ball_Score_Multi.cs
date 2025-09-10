using UnityEngine;

public class Ball_Score_Multi : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Score_Object Score;

    [Header("Stats")]
    [SerializeField] float MediumIsPremiumScore = 10;
    [SerializeField] float MediumIsPremiumMulti = 0.1f;
    [SerializeField] float BackToStartScore = 5;
    [SerializeField] float BackToStartMulti = 0.1f;

    public void Enter(Ball ball)
    {
        Handle(ball.GetSize());
    }

    private void Handle(BallSize size)
    {
        if (size == BallSize.Medium && Upgrades.MediumIsPremium)
        {
            Score.AddScore(MediumIsPremiumScore);
            Score.AddMulti(MediumIsPremiumMulti);
        }
        if (size == BallSize.tiny && Upgrades.BackToStart)
        {
            Score.AddScore(BackToStartScore);
            Score.AddMulti(BackToStartMulti);
        }
    }
}
