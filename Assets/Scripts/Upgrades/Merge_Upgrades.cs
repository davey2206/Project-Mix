using UnityEngine;

public class Merge_Upgrades : MonoBehaviour
{
    [Header("ref")]
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Score_Object Score;
    [SerializeField] Transform BallPool;
    [Header("Merge Count")]
    [SerializeField] int GildedMergeAmount = 10;
    [SerializeField] int TinyMachineAmount = 5;
    [SerializeField] int LuckyFusionAmount = 7;
    [SerializeField] int MediumMergeAmount = 2;
    [Header("Balls")]
    [SerializeField] GameObject TinyBall;
    [SerializeField] GameObject SmallGoldBall;
    [SerializeField] GameObject SmallBomb;
    [SerializeField] GameObject Block;
    [SerializeField] GameObject SmallResize;

    int MergeCount = 0;
    int MediumMergeCount = 0;

    private void OnEnable()
    {
        MergeCount = 0;
        MediumMergeCount = 0;
    }

    public void MergeEvent(Ball ball)
    {
        MergeCount++;
        if (ball.GetSize() == BallSize.Medium)
        {
            MediumMergeCount++;
        }
        TinySpawn(ball);
        SmallGoldSpawn(ball);
        ExplosiveBalls(ball);
        GildedMerge(ball);
        TinyMachine(ball);
        LuckyFusion(ball);
        MediumMerge();
    }

    private void TinySpawn(Ball ball)
    {
        int rngMax = 101;

        int RNG = Random.Range(0, rngMax);

        if (Upgrades.SmallMergeSpawnTiny && RNG <= 50 && ball.GetSize() == BallSize.Small || Upgrades.SmallMergeSpawnTiny && RNG <= 50 && ball.GetSize() == BallSize.Medium || Upgrades.SmallMergeSpawnTiny && RNG <= 50 && ball.GetSize() == BallSize.tiny)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.BigMergeSpawnTiny && RNG <= 50 && ball.GetSize() == BallSize.Large || Upgrades.BigMergeSpawnTiny && RNG <= 50 && ball.GetSize() == BallSize.Huge)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
    }

    private void SmallGoldSpawn(Ball ball)
    {
        int rngMax = 101;

        int RNG = Random.Range(0, rngMax);
        if (Upgrades.SmallMergeSpawnGold && RNG <= 50 && ball.GetSize() == BallSize.Small || Upgrades.SmallMergeSpawnGold && RNG <= 50 && ball.GetSize() == BallSize.tiny || Upgrades.SmallMergeSpawnGold && RNG <= 50 && ball.GetSize() == BallSize.Medium)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
        if (Upgrades.BigMergeSpawnGold && RNG <= 50 && ball.GetSize() == BallSize.Huge || Upgrades.BigMergeSpawnGold && RNG <= 50 && ball.GetSize() == BallSize.Large)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
    }

    private void ExplosiveBalls(Ball ball)
    {
        bool spawnedBomb = false;
        int rngMax = 101;
        if (Upgrades.IncreaseMergeSpawns)
        {
            rngMax = rngMax - 25;
        }

        int RNG = Random.Range(0, rngMax);
        int RNGblock = Random.Range(0, rngMax);

        if (Upgrades.ExplosiveBalls && RNG <= 10)
        {
            Instantiate(SmallBomb, ball.transform.position, Quaternion.identity, BallPool);
            spawnedBomb = true;
        }
        if (Upgrades.ExplosiveBalls && RNGblock <= 10 && !spawnedBomb)
        {
            Instantiate(Block, ball.transform.position, Quaternion.identity, BallPool);
        }
    }

    private void GildedMerge(Ball ball)
    {
        if (Upgrades.GildedMerge && MergeCount % GildedMergeAmount == 0)
        {
            Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
        }
    }

    private void TinyMachine(Ball ball)
    {
        if (Upgrades.TinyMechine && MergeCount % TinyMachineAmount == 0)
        {
            Instantiate(TinyBall, ball.transform.position, Quaternion.identity, BallPool);
        }
    }

    private void LuckyFusion(Ball ball)
    {
        if (Upgrades.LuckyFusion && MergeCount % LuckyFusionAmount == 0)
        {
            int RNG = Random.Range(0, 3);
            if (RNG == 0)
            {
                Instantiate(SmallBomb, ball.transform.position, Quaternion.identity, BallPool);
            }
            if (RNG == 1)
            {
                Instantiate(SmallResize, ball.transform.position, Quaternion.identity, BallPool);
            }
            if (RNG == 2)
            {
                Instantiate(SmallGoldBall, ball.transform.position, Quaternion.identity, BallPool);
            }
        }
    }

    private void MediumMerge()
    {
        if (Upgrades.MediumMerge && MediumMergeCount % MediumMergeAmount == 0)
        {
            Score.AddScore(100);
        }
    }
}
