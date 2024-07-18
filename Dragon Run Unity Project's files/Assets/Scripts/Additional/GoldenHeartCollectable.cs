using UnityEngine;

public class GoldenHeartCollectable : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if((PlayerPrefs.GetFloat("startingHealth", 3) < 10))
            {
            Health playerHealth = collision.GetComponent<Health>();
            
            PlayerPrefs.SetFloat("startingHealth", PlayerPrefs.GetFloat("startingHealth", 3) + 1);
            playerHealth.currentHealth = PlayerPrefs.GetFloat("startingHealth",3);

            SoundManager.instance.PlaySound(collectSound);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            }
        }


    }

}
