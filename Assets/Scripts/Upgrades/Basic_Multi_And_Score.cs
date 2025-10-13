using System.Collections;
using UnityEngine;

public class Basic_Multi_And_Score : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Perks_Object Perks;
    [SerializeField] Score_Object Score;
    [SerializeField] Level_Manager Level;
    [SerializeField] Coin_Object Coins;

    [Header("Stats Multi")]
    [SerializeField] float Multi1 = 5;
    [SerializeField] float Multi2 = 10;
    [SerializeField] float Multi3 = 20;
    [SerializeField] float ScoreMulti1 = 1;
    [SerializeField] float ScoreMulti2 = 1.5f;
    [SerializeField] float ScoreMulti3 = 2;
    [Header("Stats Score")]
    [SerializeField] float Score1 = 50;
    [SerializeField] float Score2 = 100;
    [SerializeField] float Score3 = 150;
    [SerializeField] float MultiScore1 = 25;
    [SerializeField] float MultiScore2 = 50;
    [SerializeField] float MultiScore3 = 100;

    [Header("Perks")]
    [SerializeField] float PerkScore1 = 100;
    [SerializeField] float PerkScore2 = 200;
    [SerializeField] float PerkScore3 = 300;
    [SerializeField] float PerkMulti1 = 1;
    [SerializeField] float PerkMulti2 = 3;
    [SerializeField] float PerkMulti3 = 5;

    private void OnEnable()
    {
        StartCoroutine(SetStats());
    }

    public void PerkEffects()
    {
        if (Perks.Multi1)
        {
            Score.AddMulti(PerkMulti1);
        }
        if (Perks.Multi2)
        {
            Score.AddMulti(PerkMulti2);
        }
        if (Perks.Multi3)
        {
            Score.AddMulti(PerkMulti3);
        }
        if (Perks.Score1)
        {
            Score.AddMulti(PerkScore1);
        }
        if (Perks.Score2)
        {
            Score.AddMulti(PerkScore2);
        }
        if (Perks.Score3)
        {
            Score.AddMulti(PerkScore3);
        }
    }

    private void UpgradeEffects()
    {
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
        if (Upgrades.MultiScore1 == true)
        {
            Score.AddScore(MultiScore1);
            Score.AddMulti(ScoreMulti1);
        }
        if (Upgrades.MultiScore2 == true)
        {
            Score.AddScore(MultiScore2);
            Score.AddMulti(ScoreMulti2);
        }
        if (Upgrades.MultiScore3 == true)
        {
            Score.AddScore(MultiScore3);
            Score.AddMulti(ScoreMulti3);
        }
        if (Upgrades.RandomMulti)
        {
            int rng = Random.Range(0, 10);
            float multi = 0;
            switch (rng)
            {
                case 0:
                    multi = -0.75f;
                    break;
                case 1:
                    multi = -0.50f;
                    break;
                case 2:
                    multi = -0.25f;
                    break;
                case 3:
                    multi = 0.5f;
                    break;
                case 4:
                    multi = 1f;
                    break;
                case 5:
                    multi = 2.5f;
                    break;
                case 6:
                    multi = 5f;
                    break;
                case 7:
                    multi = 10f;
                    break;
                case 8:
                    multi = 15f;
                    break;
                case 9:
                    multi = 20f;
                    break;
            }

            Score.AddMulti(multi);
        }
        if (Upgrades.GoldenMulti)
        {
            float multi = Coins.GetCoin() * 0.50f;
            Score.AddMulti(multi);
        }
    }

    IEnumerator SetStats()
    {
        yield return new WaitForEndOfFrame();
        PerkEffects();
        UpgradeEffects();
    }
}
