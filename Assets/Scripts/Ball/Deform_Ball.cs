using UnityEngine;
using System.Collections;

public class Deform_Ball : MonoBehaviour
{
    [Header("Deformation Settings")]
    [SerializeField] float deformationThreshold = 5f;
    [SerializeField] float deformationAmount = 0.3f; // How much to deform based on impact
    [SerializeField] float returnSpeed = 5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Upgrade_Object Upgrades;

    Vector3 startingSize;
    private Vector3 originalScale;
    float lastBallSize;
    bool TouchingResizeBall = false;
    int resizeTriggerCount = 0;

    private void Awake()
    {
        startingSize = transform.localScale;
        lastBallSize = RoundToTwoDecimals(Upgrades.BallSize);
        originalScale = startingSize * lastBallSize;
    }

    private void Update()
    {
        Resize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 impactVelocity = rb.linearVelocity;

        if (impactVelocity.magnitude >= deformationThreshold)
        {
            // Determine collision direction
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal.normalized;

            // Calculate deformation scale
            Vector3 deformation = Vector3.one;

            if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
            {
                // Side impact
                float squashX = 1f - deformationAmount;
                float stretchY = 1f + deformationAmount;
                deformation = new Vector3(squashX, stretchY, 1f);
            }
            else
            {
                // Top or bottom impact
                float squashY = 1f - deformationAmount;
                float stretchX = 1f + deformationAmount;
                deformation = new Vector3(stretchX, squashY, 1f);
            }

            StopAllCoroutines();
            StartCoroutine(DeformAndRecover(deformation));
        }
    }

    private void Resize()
    {
        float currentBallSize = RoundToTwoDecimals(Upgrades.BallSize);

        if (TouchingResizeBall)
        {
            currentBallSize = currentBallSize * 0.75f;
        }

        if (Mathf.Approximately(currentBallSize, lastBallSize)) return;

        lastBallSize = currentBallSize;

        originalScale = startingSize * currentBallSize;
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

    private IEnumerator DeformAndRecover(Vector3 targetScale)
    {
        // Apply deformation
        transform.localScale = new Vector3(
            originalScale.x * targetScale.x,
            originalScale.y * targetScale.y,
            originalScale.z
        );

        // Smoothly return to original scale
        while (Vector3.Distance(transform.localScale, originalScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, returnSpeed * Time.deltaTime);
            yield return null;
        }

        transform.localScale = originalScale;
    }
}
