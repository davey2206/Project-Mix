using UnityEngine;
using UnityEngine.Events;

public class Bowl_Upgrades : MonoBehaviour
{
    [SerializeField] UnityEvent<Ball>  BallEnterBowl;
    [SerializeField] UnityEvent<Ball> BallExitBowl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && collision.TryGetComponent<Ball>(out Ball ball))
        {
            BallEnterBowl?.Invoke(ball);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && collision.TryGetComponent<Ball>(out Ball ball))
        {
            BallExitBowl?.Invoke(ball);
        }
    }
}
