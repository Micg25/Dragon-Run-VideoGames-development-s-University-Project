using UnityEngine;

public class HeartCollectable : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            if (collision.GetComponent<Health>().TakeHealth())
            {   
                SoundManager.instance.PlaySound(collectSound);
                //GetComponent<SpriteRenderer>().enabled = false;
                //GetComponent<BoxCollider2D>().enabled = false;
                gameObject.SetActive(false);
            }
            else return;
        }


    }

}
