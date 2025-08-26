using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_Select : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] Level_Manager Manager;

    [Header("Ref")]
    [SerializeField] TextMeshProUGUI TextButton1;
    [SerializeField] TextMeshProUGUI TextButton2;
    [SerializeField] TextMeshProUGUI TextButton3;
    [SerializeField] GameObject LevelSelect;
    [SerializeField] GameObject Game;
    [SerializeField] GameObject Coin;
    [SerializeField] Transform Coins1;
    [SerializeField] Transform Coins2;
    [SerializeField] Transform Coins3;

    Level_Object level1;
    Level_Object level2;
    Level_Object level3;

    private void OnEnable()
    {
        ClearCoins();

        List<Level_Object> Levels = Manager.GetLevels(Difficulty.Easy);

        level1 = Levels[Random.Range(0, Levels.Count)];
        TextButton1.text = level1.Goal.ToString();
        for (int i = 0; i < level1.Coins; i++)
        {
            Instantiate(Coin, Coins1);
        }

        Levels.Clear();
        Levels = Manager.GetLevels(Difficulty.Normal);

        level2 = Levels[Random.Range(0, Levels.Count)];
        TextButton2.text = level2.Goal.ToString();
        for (int i = 0; i < level2.Coins; i++)
        {
            Instantiate(Coin, Coins2);
        }

        Levels.Clear();
        Levels = Manager.GetLevels(Difficulty.Hard);

        level3 = Levels[Random.Range(0, Levels.Count)];
        TextButton3.text = level3.Goal.ToString();
        for (int i = 0; i < level3.Coins; i++)
        {
            Instantiate(Coin, Coins3);
        }
    }

    public void ClearCoins()
    {
        foreach (Transform child in Coins1.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in Coins2.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in Coins3.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ClickButton1()
    {
        StartCoroutine(SoundDelay(level1));
    }

    public void ClickButton2()
    {
        StartCoroutine(SoundDelay(level2));
    }

    public void ClickButton3()
    {
        StartCoroutine(SoundDelay(level3));
    }

    IEnumerator SoundDelay(Level_Object lvl)
    {
        Manager.IncreaseLevel();
        yield return new WaitForSeconds(0.4f);

        Manager.SetCurrentLevel(lvl);
        Game.SetActive(true);
        LevelSelect.SetActive(false);
    }
}
