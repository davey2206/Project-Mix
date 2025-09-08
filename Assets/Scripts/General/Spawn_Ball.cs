using System.Collections;
using UnityEngine;

public class Spawn_Ball : MonoBehaviour
{
    [SerializeField] Spawner_Order Order;
    [SerializeField] float SpawnDelay;
    [SerializeField] Transform BallPool;
    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject Resize;
    [SerializeField] GameObject Gold;

    bool canSpawn = true;

    private void OnEnable()
    {
        canSpawn = true;
        Order.ResetToCurrent();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn && !Order.GetBomb() && !Order.GetResize() && !Order.GetGold())
        {
            Rigidbody2D ball = Instantiate(Order.CurrentBall.gameObject, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity, BallPool).GetComponent<Rigidbody2D>();
            float direction = Random.Range(-0.1f, 0.11f);

            ball.linearVelocity = new Vector2(direction, ball.linearVelocity.y);

            canSpawn = false;
            Order.RollNextBall();
            StartCoroutine(Cooldown());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canSpawn && Order.GetBomb() && !Order.GetResize() && !Order.GetGold())
        {
            Rigidbody2D ball = Instantiate(Bomb, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity, BallPool).GetComponent<Rigidbody2D>();
            float direction = Random.Range(-0.1f, 0.11f);

            ball.linearVelocity = new Vector2(direction, ball.linearVelocity.y);

            canSpawn = false;
            Order.ResetToCurrent();
            StartCoroutine(Cooldown());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canSpawn && !Order.GetBomb() && Order.GetResize() && !Order.GetGold())
        {
            Rigidbody2D ball = Instantiate(Resize, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity, BallPool).GetComponent<Rigidbody2D>();
            float direction = Random.Range(-0.1f, 0.11f);

            ball.linearVelocity = new Vector2(direction, ball.linearVelocity.y);

            canSpawn = false;
            Order.ResetToCurrent();
            StartCoroutine(Cooldown());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canSpawn && !Order.GetBomb() && !Order.GetResize() && Order.GetGold())
        {
            Rigidbody2D ball = Instantiate(Gold, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity, BallPool).GetComponent<Rigidbody2D>();
            float direction = Random.Range(-0.1f, 0.11f);

            ball.linearVelocity = new Vector2(direction, ball.linearVelocity.y);

            canSpawn = false;
            Order.ResetToCurrent();
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(SpawnDelay);
        canSpawn = true;
    }
}
