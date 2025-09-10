using UnityEngine;

public class Merge_Upgrades : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Transform BallPool;
    [SerializeField] GameObject TinyBall;
    [SerializeField] GameObject SmallGoldBall;


    public void TinySpawn(Ball ball)
    {
        int RNG = Random.Range(0,2);
        if (Upgrades.TinyMergeSpawnTiny && ball.GetSize() == BallSize.tiny && RNG == 0)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.SmallMergeSpawnTiny && ball.GetSize() == BallSize.Small && RNG == 0)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.MediumMergeSpawnTiny && ball.GetSize() == BallSize.Medium && RNG == 0)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.LargeMergeSpawnTiny && ball.GetSize() == BallSize.Large && RNG == 0)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.HugeMergeSpawnTiny && ball.GetSize() == BallSize.Huge && RNG == 0)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
    }

    public void SmallGoldSpawn(Ball ball)
    {
        int RNG = Random.Range(0, 4);
        if (Upgrades.TinyMergeSpawnGold && ball.GetSize() == BallSize.tiny && RNG == 0)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.SmallMergeSpawnGold && ball.GetSize() == BallSize.Small && RNG == 0)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.MediumMergeSpawnGold && ball.GetSize() == BallSize.Medium && RNG == 0)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.LargeMergeSpawnGold && ball.GetSize() == BallSize.Large && RNG == 0)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.HugeMergeSpawnGold && ball.GetSize() == BallSize.Huge && RNG == 0)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
    }
}
