using UnityEngine;

public class Merge_Upgrades : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Transform BallPool;
    [Header("Balls")]
    [SerializeField] GameObject TinyBall;
    [SerializeField] GameObject SmallGoldBall;


    public void TinySpawn(Ball ball)
    {
        int RNG = Random.Range(0,101);
        if (Upgrades.TinyMergeSpawnTiny && ball.GetSize() == BallSize.tiny && RNG >= 25)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.SmallMergeSpawnTiny && ball.GetSize() == BallSize.Small && RNG >= 25)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.MediumMergeSpawnTiny && ball.GetSize() == BallSize.Medium && RNG >= 25)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.LargeMergeSpawnTiny && ball.GetSize() == BallSize.Large && RNG >= 25)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.HugeMergeSpawnTiny && ball.GetSize() == BallSize.Huge && RNG >= 25)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
    }

    public void SmallGoldSpawn(Ball ball)
    {
        int RNG = Random.Range(0, 100);
        if (Upgrades.TinyMergeSpawnGold && ball.GetSize() == BallSize.tiny && RNG >= 50)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.SmallMergeSpawnGold && ball.GetSize() == BallSize.Small && RNG >= 50)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.MediumMergeSpawnGold && ball.GetSize() == BallSize.Medium && RNG >= 50)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.LargeMergeSpawnGold && ball.GetSize() == BallSize.Large && RNG >= 50)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.HugeMergeSpawnGold && ball.GetSize() == BallSize.Huge && RNG >= 50)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
    }
}
