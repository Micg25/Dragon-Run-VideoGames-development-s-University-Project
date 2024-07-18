using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Spikehead : EnemyDamage 
{
    /*
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private float checkDelay;
    private float checkTimer;
    
    */
    [SerializeField] private float speed;
    [SerializeField] private float retSpeed;
    private Vector3 idlePosition;
    private Vector3 destination;
    [SerializeField]  bool att = false;
    [SerializeField]  bool ret = false;
    [SerializeField]  bool iswaiting = false;
    [SerializeField] private AudioClip impactSound;
    [SerializeField] private Sprite attackSprite;
    [SerializeField] private Sprite idleSprite;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
         spriteRenderer=GetComponent<SpriteRenderer>();  
         idlePosition =new Vector3 (transform.position.x,transform.position.y,transform.position.z);
    }
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPos=player.transform.position;
        if (Mathf.Abs(playerPos.x - transform.position.x) < 2 && !iswaiting)
            att = true;
        if (att && !ret)
        {
            Attack();
            iswaiting = true; 
        }
            
        if (ret)
            ReturnIdle();
        if (transform.position == idlePosition && iswaiting && ret)
        {   
            ret = false;
            StartCoroutine(WaitBeforeNextAttack()); 
        }


    }
    private void Attack()
    {
        spriteRenderer.sprite = attackSprite;
        transform.Translate(0, -speed * Time.deltaTime, 0);
        

    }
    private void ReturnIdle()
    {
        spriteRenderer.sprite = idleSprite;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, idlePosition.y, transform.position.z),retSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        base.OnTriggerEnter2D(collision);
        
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            SoundManager.instance.PlaySound(impactSound);
            att = false;
            ret = true;
        }
            

    }

    private IEnumerator WaitBeforeNextAttack()
    {
        iswaiting = true;
        yield return new WaitForSeconds(2);
        iswaiting = false;
    }

}
