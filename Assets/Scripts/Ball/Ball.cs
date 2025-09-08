using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [Header("Ball")]
    [SerializeField] BallSize Size;
    [SerializeField] GameObject NextBall;
    [SerializeField] Rigidbody2D RigidbodyBall;
    [Header("Score")]
    [SerializeField] double Score;
    [SerializeField] Score_Object Score_Counter;
    [Header("Events")]
    [SerializeField] UnityEvent GameOverEvents;
    [SerializeField] UnityEvent <Ball> MergeEvent;
    [Header("Effects")]
    [SerializeField] AudioSource PopAudio;
    [SerializeField] GameObject PopEffect;

    bool isDisabled = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            Ball otherBall = collision.gameObject.GetComponent<Ball>();

            if (otherBall != null && otherBall.GetSize() == Size && Size != BallSize.Mega && Size != BallSize.Gold && Size != BallSize.Resize && Size != BallSize.Multi)
            {
                if (!isDisabled && GetInstanceID() < otherBall.GetInstanceID())
                {
                    MergeEvent?.Invoke(this);

                    DisableSelf();
                    otherBall.DisableSelf();

                    Destroy(otherBall.gameObject);

                    Ball ball = Instantiate(NextBall, transform.position, Quaternion.identity, transform.parent).GetComponent<Ball>();
                    ball.GetRegidBody().angularVelocity = RigidbodyBall.angularVelocity;
                    ball.PlayPopSound();
                    ball.PlayEffect();

                    Destroy(gameObject);
                }
            }
        }
        catch (System.Exception)
        {

        }
    }

    public void PlayEffect()
    {
        Instantiate(PopEffect, new Vector3(transform.position.x, transform.position.y, -0.1f), Quaternion.identity);
    }

    public Rigidbody2D GetRegidBody()
    {
        return RigidbodyBall;
    }

    public void PlayPopSound()
    {
        PopAudio.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boll"))
        {
            Score_Counter.AddScore(Score);
        }

        if (other.CompareTag("Outside"))
        {
            GameOverEvents?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boll"))
        {
            Score_Counter.RemoveScore(Score);
        }
    }

    public void DisableSelf()
    {
        isDisabled = true;
    }

    public BallSize GetSize()
    {
        return Size;
    }

    public double GetScore()
    {
        return Score;
    }
}

public enum BallSize
{
    tiny,
    Small,
    Medium,
    Large,
    Huge,
    Mega,
    Gold,
    Resize,
    Multi
}
