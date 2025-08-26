using UnityEngine;
using System.Collections;
using TMPro;

public class Goal_Manager : MonoBehaviour
{
    [SerializeField] Coin_Object Coins;
    [SerializeField] Level_Manager level_Manager;
    [SerializeField] TextMeshProUGUI CountDownText;
    [SerializeField] GameObject Countdown;
    [SerializeField] GameObject Win;
    public bool LevelDone;

    void Update()
    {
        if (level_Manager.CheckIfGoalHit() && !LevelDone)
        {
            LevelDone = true;
            StartCoroutine(CountDown());
        }
    }

    public void ResetLevelDone()
    {
        LevelDone = false;
    }

    IEnumerator CountDown()
    {
        int count = 3;
        Countdown.SetActive(true);

        for (int i = 0; i < 4; i++)
        {
            CountDownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            if (!level_Manager.CheckIfGoalHit())
            {
                Countdown.SetActive(false);
                LevelDone = false;
                break;
            }
            count--;
        }

        if (!level_Manager.CheckIfGoalHit())
        {
            Countdown.SetActive(false);
            LevelDone = false;
        }
        else
        {
            Win.SetActive(true);
            Countdown.SetActive(false);
            Coins.AddCoin(level_Manager.GetLevel().Coins);
        }
    }
}
