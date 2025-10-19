using UnityEngine;
using TMPro;
using System.Collections;

public class Score_Board : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI CountdownText; // 👈 Countdown display
    [SerializeField] private Score_Object Score;
    [SerializeField] private TextMeshProUGUI FloatingText;
    [SerializeField] private Transform FloatingTextPerent;

    [Header("Animation")]
    [SerializeField] private float scalePerPoint = 0.05f;   // Scale increase per score unit
    [SerializeField] private float maxScaleMultiplier = 2f; // Max scale cap
    [SerializeField] private float animationDuration = 0.2f;

    [Header("Display")]
    [SerializeField] private bool IsTotalScore = true;
    [SerializeField] private bool IsScore = false;
    [SerializeField] private bool IsMulti = false;

    [Header("Refresh")]
    [SerializeField] private float refreshInterval = 3f; // 👈 How often to update

    private double previousScore;
    private Vector3 originalScale;
    private Coroutine scaleCoroutine;
    private Coroutine updateCoroutine;

    private void OnEnable()
    {
        Score.ResetScore();
        originalScale = ScoreText.rectTransform.localScale;

        if (IsTotalScore)
            previousScore = Score.GetTotalScore();
        else if (IsScore)
            previousScore = Score.GetScore();
        else if (IsMulti)
            previousScore = Score.GetMulti();

        ScoreText.text = previousScore.ToString(IsMulti ? "F2" : "F0");

        if (updateCoroutine != null)
            StopCoroutine(updateCoroutine);

        updateCoroutine = StartCoroutine(UpdateScoreLoop());
    }

    private void OnDisable()
    {
        if (updateCoroutine != null)
            StopCoroutine(updateCoroutine);
    }

    private IEnumerator UpdateScoreLoop()
    {
        while (true)
        {
            // Countdown before refresh
            float timer = refreshInterval;
            while (timer > 0f)
            {
                if (CountdownText != null)
                    CountdownText.text = $"{Mathf.CeilToInt(timer)}";

                timer -= Time.deltaTime;
                yield return null;
            }

            // Perform refresh
            double currentScore = 0;
            if (IsTotalScore)
                currentScore = Score.GetTotalScore();
            else if (IsScore)
                currentScore = Score.GetScore();
            else if (IsMulti)
                currentScore = Score.GetMulti();

            if (currentScore > previousScore)
            {
                double delta = currentScore - previousScore;
                if(IsTotalScore)
                {
                    TextMeshProUGUI text = Instantiate(FloatingText, FloatingTextPerent);
                    text.text = "+ " + delta.ToString();
                }

                float scaleMultiplier = 1f + (float)(delta * scalePerPoint);
                scaleMultiplier = Mathf.Min(scaleMultiplier, maxScaleMultiplier);
                Vector3 targetScale = originalScale * scaleMultiplier;

                if (scaleCoroutine != null)
                    StopCoroutine(scaleCoroutine);

                scaleCoroutine = StartCoroutine(AnimateScoreText(targetScale));
            }

            previousScore = currentScore;
            ScoreText.text = currentScore.ToString(IsMulti ? "F2" : "F0");

            // Reset countdown display
            if (CountdownText != null)
                CountdownText.text = $"Refreshing...";
        }
    }

    private IEnumerator AnimateScoreText(Vector3 targetScale)
    {
        float t = 0f;

        // Enlarge
        while (t < animationDuration)
        {
            t += Time.deltaTime;
            ScoreText.rectTransform.localScale = Vector3.Lerp(originalScale, targetScale, t / animationDuration);
            yield return null;
        }

        // Shrink back
        t = 0f;
        while (t < animationDuration)
        {
            t += Time.deltaTime;
            ScoreText.rectTransform.localScale = Vector3.Lerp(targetScale, originalScale, t / animationDuration);
            yield return null;
        }

        ScoreText.rectTransform.localScale = originalScale;
    }
}
