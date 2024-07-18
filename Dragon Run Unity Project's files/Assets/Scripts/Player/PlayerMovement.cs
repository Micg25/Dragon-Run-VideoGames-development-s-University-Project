using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    public bool doubleJump = false;

    [SerializeField] private AudioClip jumpSound;


    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime;
    private float coyoteCounter;
    private void Awake()
    {
        //prende le reference
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (body != null)
        {
            // rotazione personaggio
            if (horizontalInput > 0.01f)
            {
                transform.localScale = Vector3.one;
            }
            if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            anim.SetBool("run", horizontalInput != 0);
            anim.SetBool("grounded", isGrounded());

            if (Input.GetKeyDown(KeyCode.Space))
                Jump();

            if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
                body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

           
            if (onWall() && !isGrounded())
            {
                body.velocity = new Vector2(0, body.velocity.y); 
            }
            else
            {
                body.gravityScale = 7;
                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

                if (isGrounded())
                {
                    coyoteCounter = coyoteTime;
                }
                else
                    coyoteCounter -= Time.deltaTime;
            }
        }



    }
    private void Jump()
    {

        if (coyoteCounter <= 0 && !onWall()) return;
        SoundManager.instance.PlaySound(jumpSound);
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);

        }
        else if (coyoteCounter > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);

            coyoteCounter = 0;
        }
        doubleJump = false;
    }
    public void doubleJ()
    {

        body.velocity = new Vector2(body.velocity.x, jumpPower);

        anim.SetTrigger("jump");

    }
    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;

    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);

        return raycastHit.collider != null;

    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();

    }
}