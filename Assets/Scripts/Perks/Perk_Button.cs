using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.GPUSort;

public class Perk_Button : MonoBehaviour
{
    [SerializeField] List<Perk_Object> PerkList;
    [SerializeField] TextMeshProUGUI Title;
    [SerializeField] TextMeshProUGUI Description;
    [Header("Events")]
    [SerializeField] UnityEvent ClickEvent;

    Perk_Object Perk;

    private void OnEnable()
    {
        List<Perk_Object> perkList = new List<Perk_Object>();
        foreach (var perk in PerkList)
        {
            if (!perk.CheckPerk())
            {
                perkList.Add(perk);
            }
        }

        Perk = perkList[Random.Range(0, perkList.Count)];

        Title.text = Perk.GetTitle();
        Description.text = Perk.GetDescription();
    }

    public void Click()
    {
        Perk.ActivatePerk();
        ClickEvent?.Invoke();
    }
}
