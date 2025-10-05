using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "ScriptableObjects/Upgrade_Object", order = 1)]
public class Upgrade_Object : ScriptableObject
{
    [Header("Upgrade amount")]
    public int NumberOfUpgrades = 0;

    [Header("General Upgrades")]
    [Range(1, 20)]
    public int UpgradeCap = 5;
    public int UpgradeCapChange = 5;
    public int UpgradeCapGoldChange = 0;
    [Range(1,4)]
    public int BowlSize = 1;
    public int BowlSizeChange = 1;
    public int BowlGoldChange = 0;
    [Range(0.5f, 2)]
    public float BallSize = 1;
    public float BallSizeChange = 1;

    [Header("Spacial balls")]
    [Range(0, 20)]
    public int ResizeBall = 0;
    [Range(0, 20)]
    public int DeleteBall = 0;
    [Range(0,20)]
    public int GoldBall = 0;

    [Header("Upgrades")]
    public bool TinyBallMulti;
    public bool SmallBallMulti;
    public bool MediumBallMulti;
    public bool LargeBallMulti;
    public bool HugeBallMulti;
    public bool MegaBallMulti;
    public bool GoldBallMulti;
    public bool ResizeBallMulti;
    public bool BasicMulti1;
    public bool BasicMulti2;
    public bool BasicMulti3;
    public bool RandomMulti;
    public bool TinyBallScore;
    public bool SmallBallScore;
    public bool MediumBallScore;
    public bool LargeBallScore;
    public bool HugeBallScore;
    public bool MegaBallScore;
    public bool GoldBallScore;
    public bool ResizeBallScore;
    public bool BasicScore1;
    public bool BasicScore2;
    public bool BasicScore3;
    public bool MediumIsPremium;
    public bool MultiScore1;
    public bool MultiScore2;
    public bool MultiScore3;
    public bool BowlSizeBasic;
    public bool BowlSizeForBallSize;
    public bool BowlSizeForEachMega;
    public bool BowlExtraSlot;
    public bool BallSizeBasic;
    public bool BallSizeForBowlSize;
    public bool BallSizeForEachMega;
    public bool BackToStart;
    public bool SmallMergeSpawnTiny;
    public bool BigMergeSpawnTiny;
    public bool SmallMergeSpawnGold;
    public bool BigMergeSpawnGold;
    public bool ExtraSlot;
    public bool DevilScore;
    public bool DevilMulti;
    public bool DevilSize;
    public bool GoldenBonus;
    public bool GildedMerge;
    public bool GoldenPath;
    public bool GoldenMulti;
    public bool GoldenEcho;
    public bool GoldenResizer;
    public bool GoldenBowl;
    public bool LuckyFusion;
    public bool IncreaseMergeSpawns;
    public bool ExplosiveBalls;
    public bool FinalSpark;
    public bool TinyMechine;
    public bool GoldenSlot;


    public bool CheckUpgrade(Upgrades upgrade)
    {
        string fieldName = upgrade.ToString();
        FieldInfo field = this.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);

        if (field != null && field.FieldType == typeof(bool))
        {
            return (bool)field.GetValue(this);
        }

        return false;
    }

    public void ResetUpgrades()
    {
        FieldInfo[] fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(bool))
            {
                field.SetValue(this, false);
            }
        }

        BallSize = 1;
        BowlSize = 1;
        ResizeBall = 0;
        DeleteBall = 0;
        GoldBall = 0;
        NumberOfUpgrades = 0;
        UpgradeCap = 5;
        BallSizeChange = 1;
        BowlSizeChange = 1;
        UpgradeCapChange = 5;
        UpgradeCapGoldChange = 0;
        BowlGoldChange = 0;
    }

    public void ChangeBowlSize(int amount)
    {
        BowlSizeChange += amount;
        if (BowlSizeChange < 0)
        {
            BowlSize = 1;
        }
        else if(BowlSizeChange > 4)
        {
            BowlSize = 4;
        }
        else
        {
            BowlSize = BowlSizeChange;
        }
    }

    public void ChangeBallSize(float amount)
    {
        BallSizeChange += amount;
        if (BallSizeChange < 0.5f)
        {
            BallSize = 0.5f;
        }
        else if(BallSizeChange > 2)
        {
            BallSize = 2;
        }
        else
        {
            BallSize = BallSizeChange;
        }
    }

    public void ChangeSlots(int amount)
    {
        UpgradeCapChange += amount;
        if (BowlSizeChange < 0)
        {
            UpgradeCap = 1;
        }
        else if (BowlSizeChange > 20)
        {
            UpgradeCap = 20;
        }
        else
        {
            UpgradeCap = UpgradeCapChange;
        }
    }
}

public enum Upgrades
{
    TinyBallMulti,
    SmallBallMulti,
    MediumBallMulti,
    LargeBallMulti,
    HugeBallMulti,
    MegaBallMulti,
    GoldBallMulti,
    ResizeBallMulti,
    TinyBallScore,
    SmallBallScore,
    MediumBallScore,
    LargeBallScore,
    HugeBallScore,
    MegaBallScore,
    GoldBallScore,
    ResizeBallScore,
    BowlSizeBasic,
    BowlSizeForBallSize,
    BowlSizeForEachMega,
    BallSizeBasic,
    BallSizeForBowlSize,
    BallSizeForEachMega,
    MediumIsPremium,
    BasicMulti1,
    BasicMulti2,
    BasicMulti3,
    BasicScore1,
    BasicScore2,
    BasicScore3,
    BackToStart,
    SmallMergeSpawnTiny,
    BigMergeSpawnTiny,
    ExtraSlot,
    DevilScore,
    DevilMulti,
    DevilSize,
    SmallMergeSpawnGold,
    BigMergeSpawnGold,
    BowlExtraSlot,
    MultiScore1,
    MultiScore2,
    MultiScore3,
    GoldenBonus,
    GildedMerge,
    GoldenSlot,
    GoldenPath,
    LuckyFusion,
    GoldenMulti,
    RandomMulti,
    GoldenEcho,
    IncreaseMergeSpawns,
    GoldenResizer,
    ExplosiveBalls,
    FinalSpark,
    GoldenBowl,
    TinyMechine,
}
