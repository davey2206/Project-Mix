using UnityEngine;

public class Ball_Size : MonoBehaviour
{
    [SerializeField] Transform Ball;
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float resizeCooldown = 0.1f;

    Vector3 startingSize;
    float lastBallSize;
    bool TouchingResizeBall = false;
    float nextResizeTime = 0f;
    int resizeTriggerCount = 0;

    private void Start()
    {
        startingSize = Ball.localScale;
        lastBallSize = RoundToTwoDecimals(Upgrades.BallSize);
        Ball.localScale = startingSize * lastBallSize;
    }

    private void FixedUpdate()
    {
        Resize();
    }

    private void Resize()
    {
        if (Time.time < nextResizeTime)
            return;

        float currentBallSize = RoundToTwoDecimals(Upgrades.BallSize);

        if (TouchingResizeBall)
        {
            currentBallSize *= 0.75f;
        }

        if (Mathf.Approximately(currentBallSize, lastBallSize))
            return;

        lastBallSize = currentBallSize;
        Ball.localScale = startingSize * currentBallSize;

        nextResizeTime = Time.time + resizeCooldown;
    }

    private float RoundToTwoDecimals(float value)
    {
        return Mathf.Round(value * 100f) / 100f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Resize"))
        {
            resizeTriggerCount++;
            TouchingResizeBall = true;

            if (rb != null)
            {
                Vector2 direction = (collision.transform.position - Ball.position).normalized;
                float pushStrength = 1f;
                rb.AddForce(direction * pushStrength, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Resize"))
        {
            resizeTriggerCount--;

            if (resizeTriggerCount <= 0)
            {
                resizeTriggerCount = 0;
                TouchingResizeBall = false;
            }
        }
    }
}
