
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(PlayerPrefs.GetFloat("enemyDamage", 1));
        }

    }
}
