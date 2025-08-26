using TMPro;
using UnityEngine;

public class Cap_Text : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] TextMeshProUGUI Text;

    private void Update()
    {
        Text.text = Upgrades.NumberOfUpgrades.ToString() + " / " + Upgrades.UpgradeCap.ToString();
    }
}
