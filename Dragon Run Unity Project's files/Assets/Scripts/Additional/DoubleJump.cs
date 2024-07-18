using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMovement playerMovement;
    [SerializeField] private bool canDoubleJump = false;
    private SpriteRenderer spriteRend;
    [SerializeField] private bool hasJumped=false;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag == "Player" && !hasJumped)
        {
            canDoubleJump = true;
            hasJumped = false;
            spriteRend.color = Color.green;
        
        }


    }

    private void Update()
    {
        if (canDoubleJump && Input.GetKeyDown(KeyCode.Space) && !playerMovement.isGrounded() && !hasJumped)
        {
            playerMovement.doubleJ();
            spriteRend.color = Color.red; // Cambia il colore per indicare che il doppio salto non è più possibile
            hasJumped = true;
        }

        if (playerMovement.isGrounded())
        {
            canDoubleJump = false; // Resetta la possibilità di fare il doppio salto quando il giocatore tocca terra
            hasJumped = false;
            spriteRend.color = Color.white; // Resetta il colore quando il giocatore tocca terra
        }
    }
}
