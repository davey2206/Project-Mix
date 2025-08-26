using TMPro;
using UnityEngine;

public class Game_Over_Score : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Score_Object Score;

    private void OnEnable()
    {
        ScoreText.text = Score.GetTotalScore().ToString("F0");
    }
}
