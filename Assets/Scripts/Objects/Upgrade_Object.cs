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
    [Range(1,4)]
    public int BowlSize = 1;
    int BowlSizeChange = 1;
    [Range(0.5f, 2)]
    public float BallSize = 1;
    float BallSizeChange = 1;

    [Header("Spacial balls")]
    [Range(0, 20)]
    public int ResizeBall = 0;
    [Range(0, 20)]
    public int DeleteBall = 0;
    [Range(0,20)]
    public int GoldBall = 0;

    [Header("Multi Upgrades")]
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

    [Header("Score Upgrades")]
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

    [Header("Score And Multi Upgrades")]
    public bool MediumIsPremium;

    [Header("Boll Upgrades")]
    public bool BowlSizeBasic;
    public bool BowlSizeForBallSize;
    public bool BowlSizeForEachMega;
    public bool BowlExtraSlot;

    [Header("Ball Size Upgrades")]
    public bool BallSizeBasic;
    public bool BallSizeForBowlSize;
    public bool BallSizeForEachMega;

    [Header("Merge Upgrades")]
    public bool BackToStart;
    public bool TinyMergeSpawnTiny;
    public bool SmallMergeSpawnTiny;
    public bool MediumMergeSpawnTiny;
    public bool LargeMergeSpawnTiny;
    public bool HugeMergeSpawnTiny;
    public bool TinyMergeSpawnGold;
    public bool SmallMergeSpawnGold;
    public bool MediumMergeSpawnGold;
    public bool LargeMergeSpawnGold;
    public bool HugeMergeSpawnGold;

    [Header("Card Slot Upgrades")]
    public bool ExtraSlot;

    [Header("Devil Upgrades")]
    public bool DevilScore;
    public bool DevilMulti;
    public bool DevilSize;


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
    }

    public void ChangeBowlSize(int amount)
    {
        BowlSizeChange += amount;
        if (BowlSizeChange > 0 && BowlSizeChange <= 4)
        {
            BowlSize = BowlSizeChange;
        }
        else
        {
            if (BowlSizeChange < 0)
            {
                BowlSize = 1;
            }

            if (BowlSizeChange > 4)
            {
                BowlSize = 4;
            }
        }
    }

    public void ChangeBallSize(float amount)
    {
        BallSizeChange += amount;
        if (BallSizeChange > 0.5f && BallSizeChange <= 2)
        {
            BallSize = BallSizeChange;
        }
        else
        {
            if (BallSizeChange < 0.5f)
            {
                BallSize = 0.5f;
            }

            if (BallSizeChange > 2)
            {
                BallSize = 2;
            }
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
    TinyMergeSpawnTiny,
    SmallMergeSpawnTiny,
    MediumMergeSpawnTiny,
    LargeMergeSpawnTiny,
    HugeMergeSpawnTiny,
    ExtraSlot,
    DevilScore,
    DevilMulti,
    DevilSize,
    TinyMergeSpawnGold,
    SmallMergeSpawnGold,
    MediumMergeSpawnGold,
    LargeMergeSpawnGold,
    HugeMergeSpawnGold,
    BowlExtraSlot,
}
