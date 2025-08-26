using UnityEngine;

public class Ball_Animation : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator Ani;
    [Header("Stats")]
    [SerializeField] float StillVelocityThreshold = 0.1f;
    [SerializeField] float AngryVelocityThreshold = 0.5f;
    [SerializeField] float ScaredVelocityThreshold = 1f;
    [SerializeField] float SadDurationThreshold = 5f;
    [Header("Emotion Timing")]
    [SerializeField] float EmotionChangeCooldown = 0.5f;

    private float SadTime = 0f;
    private string currentEmotion = "";
    private float emotionCooldownTimer = 0f;

    private void Start()
    {
        emotionCooldownTimer = 0;
    }

    private void FixedUpdate()
    {
        emotionCooldownTimer -= Time.fixedDeltaTime;

        float linearVel = rb.linearVelocity.magnitude;

        if (linearVel < StillVelocityThreshold)
        {
            SadTime += Time.fixedDeltaTime;
            if (SadTime >= SadDurationThreshold)
            {
                TrySetEmotion("Sad");
            }
            else
            {
                TrySetEmotion("Happy");
            }
        }
        else
        {
            SadTime = 0f;

            if (linearVel > AngryVelocityThreshold && linearVel < ScaredVelocityThreshold)
            {
                TrySetEmotion("Angry");
            }
            else if (linearVel > ScaredVelocityThreshold)
            {
                TrySetEmotion("Scared");
            }
            else
            {
                TrySetEmotion("Happy");
            }
        }
    }

    private void TrySetEmotion(string emotion)
    {
        if (emotion == currentEmotion) return;
        if (emotionCooldownTimer > 0f) return;

        if (!string.IsNullOrEmpty(emotion))
        {
            Ani.SetTrigger(emotion);
        }

        currentEmotion = emotion;
        emotionCooldownTimer = EmotionChangeCooldown;
    }
}
