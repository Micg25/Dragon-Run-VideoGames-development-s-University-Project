using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    [SerializeField] private AudioClip checkpointSound;
    [SerializeField] private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();  
        uiManager = FindObjectOfType<UIManager>();
    }
    private void Update()
    {
   
            if (playerHealth.currentHealth <= 0)
            {
            Physics2D.IgnoreLayerCollision(10, 12, false);
            Physics2D.IgnoreLayerCollision(10, 13, false);
            Physics2D.IgnoreLayerCollision(10, 14, false);
            CheckRespawn();
            }
      
    }
    public void CheckRespawn()
    {
        //check checkpoint availability
        
        if (currentCheckpoint == null) {
            //gameover  screen
            uiManager.GameOver();
            return;
        }
        playerHealth.Respawn();
        transform.position = currentCheckpoint.position;   
        Camera.main.GetComponent<CameraController>().MoveToCheckpoint(currentCheckpoint);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
            Physics2D.IgnoreLayerCollision(10, 12, false);
            Physics2D.IgnoreLayerCollision(10, 13, false);
            Physics2D.IgnoreLayerCollision(10, 14, false);
        }
    }
}
