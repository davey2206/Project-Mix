using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level_Object", order = 1)]
public class Level_Object : ScriptableObject
{
    [SerializeField] public double Goal;
    [SerializeField] public int Level;
    [SerializeField] public Difficulty Difficulty;
    [SerializeField] public int Coins;
}

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}
