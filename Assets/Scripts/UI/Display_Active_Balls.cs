using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Display_Active_Balls : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Button Button;
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] bool IsBomb = false;
    [SerializeField] bool IsResize = false;
    [SerializeField] bool IsGold = false;

    private void Update()
    {
        if (IsBomb)
        {
            Text.text = Upgrades.DeleteBall.ToString();
            if (Upgrades.DeleteBall <= 0)
            {
                Button.enabled = false;
            }
            else
            {
                Button.enabled = true;
            }
        }

        if (IsResize)
        {
            Text.text = Upgrades.ResizeBall.ToString();
            if (Upgrades.ResizeBall <= 0)
            {
                Button.enabled = false;
            }
            else
            {
                Button.enabled = true;
            }
        }

        if (IsGold)
        {
            Text.text = Upgrades.GoldBall.ToString();
            if (Upgrades.GoldBall <= 0)
            {
                Button.enabled = false;
            }
            else
            {
                Button.enabled = true;
            }
        }
    }
}
