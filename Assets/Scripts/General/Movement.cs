using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float Speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < 2.8)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -2.8)
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
    }
}
