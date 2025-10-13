using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "Perk", menuName = "ScriptableObjects/Perks/Perk_Object", order = 1)]
public class Perk_Object : ScriptableObject
{
    [SerializeField] Perks_Object Perks;
    [SerializeField] Perks Perk;
    [SerializeField] string Title;
    [SerializeField] string Description;

    public void ActivatePerk()
    {
        string fieldName = Perk.ToString();
        FieldInfo field = Perks.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);

        if (field != null && field.FieldType == typeof(bool))
        {
            field.SetValue(Perks, true);
        }
    }

    public bool CheckPerk()
    {
        return Perks.CheckPerks(Perk);
    }

    public string GetTitle()
    {
        return Title;
    }

    public string GetDescription()
    {
        return Description;
    }
}
