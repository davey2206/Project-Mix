using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Perk_Button : MonoBehaviour
{
    [SerializeField] List<Perk_Object> PerkList;
    [SerializeField] TextMeshProUGUI Title;
    [SerializeField] TextMeshProUGUI Description;
    [Header("Events")]
    [SerializeField] UnityEvent ClickEvent;

    public Perk_Object Perk;

    private void OnEnable()
    {
        Perk = PerkList[Random.Range(0, PerkList.Count)];

        Title.text = Perk.GetTitle();
        Description.text = Perk.GetDescription();
    }

    public void Click()
    {
        Perk.ActivatePerk();
        ClickEvent?.Invoke();
    }
}
