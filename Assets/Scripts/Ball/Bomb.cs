using UnityEngine;
using System.Collections.Generic;

public class Bomb : MonoBehaviour
{
    [SerializeField] Score_Object Score;
    [SerializeField] GameObject Effect;
    public List<Ball> Balls = new List<Ball>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Balls.Add(collision.gameObject.GetComponent<Ball>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Balls.Remove(collision.gameObject.GetComponent<Ball>());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Effect, transform.position, Quaternion.identity);

        for (int i = Balls.Count - 1; i >= 0; i--)
        {
            var ball = Balls[i];
            Score.AddScore(ball.GetScore());
            Destroy(ball.gameObject);
        }

        Destroy(gameObject);
    }
}
