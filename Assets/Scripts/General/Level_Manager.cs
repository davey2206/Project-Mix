using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] List<Level_Object> Levels;
    [SerializeField] Level_Object CurrentLevel;
    [SerializeField] int lvl = 0;
    [SerializeField] Score_Object Score;
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Coin_Object CoinObject;

    private void Awake()
    {
        Upgrades.ResetUpgrades();
        CoinObject.ResetCoins();
        ResetLevel();
    }

    public List<Level_Object> GetLevels(Difficulty difficulty)
    {
        List<Level_Object> level_Objects = new List<Level_Object>();
        foreach (var Level in Levels)
        {
            if (Level.Level == lvl && Level.Difficulty == difficulty)
            {
                level_Objects.Add(Level);
            }
        }

        return level_Objects;
    }

    public void SetCurrentLevel(Level_Object lvl)
    {
        CurrentLevel = lvl;
    }

    public void IncreaseLevel()
    {
        lvl++;
        if (lvl > 10)
        {
            lvl = 10;
        }
    }

    public bool CheckIfGoalHit()
    {
        if (Score.GetTotalScore() >= CurrentLevel.Goal)
        {
            return true;
        }

        return false;
    }

    public double GetGoal()
    {
        return CurrentLevel.Goal;
    }

    public void ResetLevel()
    {
        CurrentLevel = null;
        lvl = 0;
    }

    public Level_Object GetLevel()
    {
        return CurrentLevel;
    }
}
