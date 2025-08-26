using UnityEngine;
using TMPro;

public class Goal_Display : MonoBehaviour
{
    [SerializeField] Level_Manager goal;
    [SerializeField] TextMeshProUGUI Text;

    void Update()
    {
        Text.text = goal.GetGoal().ToString();
    }
}
