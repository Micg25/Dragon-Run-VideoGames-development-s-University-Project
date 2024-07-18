using UnityEngine;

public class Arrowtraptest : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private AudioClip arrowSound;
    private float cooldownTimer;
    private void Attack()
    {

        cooldownTimer = 0;
        SoundManager.instance.PlaySound(arrowSound);
        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();

    }
    private int FindArrow()
    {

        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;

        }
        return 0;

    }

    private void Update()
    {   
        
        cooldownTimer += Time.deltaTime;
        Renderer trapRend = GetComponent<Renderer>();
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if(player.position.y >= firePoint.position.y && cooldownTimer >= attackCooldown && trapRend.isVisible)
            Attack();
           
    }
}
