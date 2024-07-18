using UnityEditor;
using UnityEngine;

public class EnemyProjectile : EnemyDamage //ereditarietà 
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private Animator anim;
    private float lifetime;
    private bool hit;
    private BoxCollider2D coll;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll= GetComponent<BoxCollider2D>();
    }
    public void ActivateProjectile()
        {

        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
        }

    private void Update()
    {

        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        coll.enabled = true;
        if (collision.gameObject.CompareTag("Player")) { 

        collision.GetComponent<Health>().TakeDamage(PlayerPrefs.GetFloat("enemyDamage", 1));
            if (anim != null)
                anim.SetTrigger("explode");
                
            else
                gameObject.SetActive(false);
        
        }
        else if (anim!= null)
        {
            anim.SetTrigger("explode");
        }
        else if (anim==null)
            gameObject.SetActive(false);


    }

    private void Deactivate()
    {
        gameObject.SetActive(false);

    }
}
