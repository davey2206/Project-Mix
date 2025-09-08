using System.Collections;
using UnityEngine;

public class Basic_Multi_And_Score : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Score_Object Score;
    [SerializeField] Level_Manager Level;

    [Header("Stats Multi")]
    [SerializeField] float Multi1 = 5;
    [SerializeField] float Multi2 = 10;
    [SerializeField] float Multi3 = 20;
    [Header("Stats Score")]
    [SerializeField] float Score1 = 50;
    [SerializeField] float Score2 = 100;
    [SerializeField] float Score3 = 150;

    private void OnEnable()
    {
        StartCoroutine(SetStats());
    }

    IEnumerator SetStats()
    {
        yield return new WaitForEndOfFrame();

        if (Upgrades.BasicMulti1 == true)
        {
            Score.AddMulti(Multi1);
        }
        if (Upgrades.BasicMulti2 == true)
        {
            Score.AddMulti(Multi2);
        }
        if (Upgrades.BasicMulti3 == true)
        {
            Score.AddMulti(Multi3);
        }
        if (Upgrades.BasicScore1 == true)
        {
            Score.AddScore(Score1);
        }
        if (Upgrades.BasicScore2 == true)
        {
            Score.AddScore(Score2);
        }
        if (Upgrades.BasicScore3 == true)
        {
            Score.AddScore(Score3);
        }
    }
}
