using UnityEngine;

public class Balls_In_Bowl_Manager : MonoBehaviour
{
    [SerializeField] Balls_In_Bowl_Object BallsInBowl;

    private void OnEnable()
    {
        BallsInBowl.ResetCount();
    }
}
