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
    public int BollSize = 1;
    [Range(0.5f, 2)]
    public float BallSize = 1;

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

    [Header("Score Upgrades")]
    public bool TinyBallScore;
    public bool SmallBallScore;
    public bool MediumBallScore;
    public bool LargeBallScore;
    public bool HugeBallScore;
    public bool MegaBallScore;
    public bool GoldBallScore;
    public bool ResizeBallScore;

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
        BollSize = 1;
        ResizeBall = 0;
        DeleteBall = 0;
        GoldBall = 0;
        NumberOfUpgrades = 0;
        UpgradeCap = 5;
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
}
