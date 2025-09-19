using UnityEngine;
using System.Collections.Generic;

public class Bomb : MonoBehaviour
{
    [SerializeField] Score_Object Score;
    [SerializeField] GameObject Effect;
    [SerializeField] bool DestroyBlock = true;
    public List<Ball> Balls = new List<Ball>();
    public List<GameObject> Blocks = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Balls.Add(collision.gameObject.GetComponent<Ball>());
        }
        if (collision.CompareTag("Block") && DestroyBlock)
        {
            Blocks.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Balls.Remove(collision.gameObject.GetComponent<Ball>());
        }
        if (collision.CompareTag("Block") && DestroyBlock)
        {
            Blocks.Remove(collision.gameObject);
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

        for (int i = 0; i < Blocks.Count; i++)
        {
            Destroy(Blocks[i]);
        }

        Destroy(gameObject);
    }
}
