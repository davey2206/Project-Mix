using System.Collections;
using UnityEngine;

public class Destroy_When_Done : MonoBehaviour
{
    [SerializeField] float Delay;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(Delay);
        Destroy(gameObject);
    }
}
