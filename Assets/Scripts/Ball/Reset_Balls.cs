using UnityEngine;

public class Reset_Balls : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
