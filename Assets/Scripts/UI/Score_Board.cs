using UnityEngine;
using TMPro;
using System.Collections;

public class Score_Board : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Score_Object Score;
    [Header("Animation")]
    [SerializeField] private float scalePerPoint = 0.05f;   // Scale increase per score unit
    [SerializeField] private float maxScaleMultiplier = 2f; // Max scale cap
    [SerializeField] private float animationDuration = 0.2f;
    [Header("display")]
    [SerializeField] bool IsTotalScore = true;
    [SerializeField] bool IsScore = false;
    [SerializeField] bool IsMulti = false;


    private double previousScore;
    private Vector3 originalScale;
    private Coroutine scaleCoroutine;

    private void OnEnable()
    {
        Score.ResetScore();
        originalScale = ScoreText.rectTransform.localScale;
        if (IsTotalScore)
        {
            previousScore = Score.GetTotalScore();
        }
        else if (IsScore)
        {
            previousScore = Score.GetScore();
        }
        else if (IsMulti)
        {
            previousScore = Score.GetMulti();
        }

        ScoreText.text = previousScore.ToString("F0");
    }

    private void Update()
    {
        double currentScore = 0;

        if (IsTotalScore)
        {
            currentScore = Score.GetTotalScore();
        }
        else if (IsScore)
        {
            currentScore = Score.GetScore();
        }
        else if (IsMulti)
        {
            currentScore = Score.GetMulti();
        }

        if (currentScore > previousScore)
        {
            double delta = currentScore - previousScore;

            float scaleMultiplier = 1f + (float)(delta * scalePerPoint);
            scaleMultiplier = Mathf.Min(scaleMultiplier, maxScaleMultiplier);
            Vector3 targetScale = originalScale * scaleMultiplier;

            if (scaleCoroutine != null) StopCoroutine(scaleCoroutine);
            scaleCoroutine = StartCoroutine(AnimateScoreText(targetScale));
        }

        previousScore = currentScore;

        if (IsMulti)
        {
            ScoreText.text = currentScore.ToString("F2");
        }
        else
        {
            ScoreText.text = currentScore.ToString("F0");
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
