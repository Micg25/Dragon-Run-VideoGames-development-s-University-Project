using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = PlayerPrefs.GetFloat("startingHealth", 3) / 10;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
        totalhealthBar.fillAmount = PlayerPrefs.GetFloat("startingHealth", 3) / 10;

    }
}
