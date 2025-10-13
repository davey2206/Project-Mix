using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "Perks", menuName = "ScriptableObjects/Perks/Perks_Object", order = 1)]
public class Perks_Object : ScriptableObject
{
    [Header("Upgrades")]
    public bool Multi1;
    public bool Multi2;
    public bool Multi3;
    public bool Score1;
    public bool Score2;
    public bool Score3;
    public bool SmallMulti;
    public bool SmallScore;
    public bool MediumMulti;
    public bool MediumScore;
    public bool GoldMulti;
    public bool GoldScore;
    public bool BiggerBowl;
    public bool SmallerBalls;
    public bool TinyMulti;
    public bool TinyScore;

    public bool CheckPerks(Perks perk)
    {
        string fieldName = perk.ToString();
        FieldInfo field = this.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);

        if (field != null && field.FieldType == typeof(bool))
        {
            return (bool)field.GetValue(this);
        }

        return false;
    }

    public void ResetPerks()
    {
        FieldInfo[] fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(bool))
            {
                field.SetValue(this, false);
            }
        }
    }
}

public enum Perks
{
    Multi1,
    Multi2,
    Multi3,
    Score1,
    Score2,
    Score3,
    SmallMulti,
    SmallScore,
    MediumMulti,
    MediumScore,
    GoldMulti,
    GoldScore,
    BiggerBowl,
    SmallerBalls,
    TinyMulti,
    TinyScore,
}

