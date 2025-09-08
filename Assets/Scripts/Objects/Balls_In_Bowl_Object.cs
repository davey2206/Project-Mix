using UnityEngine;

[CreateAssetMenu(fileName = "Balls In Bowl", menuName = "ScriptableObjects/Balls_In_Bowl", order = 1)]
public class Balls_In_Bowl_Object : ScriptableObject
{
    public int Tiny = 0;
    public int Small = 0;
    public int Medium = 0;
    public int large = 0;
    public int Huge = 0;
    public int Mega = 0;
    public int Resize = 0;
    public int Gold = 0;
    public int Multi = 0;

    public void ResetCount()
    {
        Tiny = 0;
        Small = 0;
        Medium = 0;
        large = 0;
        Huge = 0;
        Mega = 0;
        Resize = 0;
        Gold = 0;
        Multi = 0;
    }
}
