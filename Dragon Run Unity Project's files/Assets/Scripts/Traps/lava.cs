
using UnityEngine;

public class Lava : MonoBehaviour
{


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(10);
        }

    }
}
