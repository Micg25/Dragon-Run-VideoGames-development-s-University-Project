
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
   [Header ("Health")]
   [SerializeField] public float startingHealth; 
    public float currentHealth;
    private Animator anim;
    private bool dead=false;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;


    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Sounds")]
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip hurtSound;

    private void Awake()
    {
        currentHealth = PlayerPrefs.GetFloat("startingHealth", 3); 
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, PlayerPrefs.GetFloat("startingHealth", 3));
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(hurtSound);
            //iframes
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                dead = true;
                anim.SetTrigger("die");
                SoundManager.instance.PlaySound(dieSound);

                if (this.CompareTag ("Enemy"))
                {
                   
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 50);
                    PlayerPrefs.SetInt("levelScore", PlayerPrefs.GetInt("levelScore", 0) + 50);
                    Physics2D.IgnoreLayerCollision(10, 12, false);
                    Physics2D.IgnoreLayerCollision(10, 13, false);
                    Physics2D.IgnoreLayerCollision(10, 14, false);
                }

                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

            }

        }

    }
    public bool TakeHealth()
    {
        if (currentHealth < PlayerPrefs.GetFloat("startingHealth", 3))
        {
            currentHealth = Mathf.Clamp(currentHealth + 1, 0, PlayerPrefs.GetFloat("startingHealth", 3));
            return true;
        }
        else
            return false; 
    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 12, true);
        Physics2D.IgnoreLayerCollision(10, 13, true);
        Physics2D.IgnoreLayerCollision(10, 14, true);

        //invlunerability duration
        for (int i = 0; i < numberOfFlashes; i++) {

            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));


        }

        Physics2D.IgnoreLayerCollision(10, 12, false);
        Physics2D.IgnoreLayerCollision(10, 13, false);
        Physics2D.IgnoreLayerCollision(10, 14, false);

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);

    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, PlayerPrefs.GetFloat("startingHealth", 3));
        
    }
    public void Respawn()
    {

        dead = false; 
        AddHealth(PlayerPrefs.GetFloat("startingHealth", 3));
        anim.ResetTrigger("die");
        anim.Play("idle");
        StartCoroutine(Invulnerability());
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
        Physics2D.IgnoreLayerCollision(10, 12, false);
        Physics2D.IgnoreLayerCollision(10, 13, false);
        Physics2D.IgnoreLayerCollision(10, 14, false);

    }

}
