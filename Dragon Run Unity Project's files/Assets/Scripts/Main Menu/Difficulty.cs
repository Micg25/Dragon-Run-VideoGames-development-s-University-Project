using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private string textIntro;
    private TextMeshProUGUI txt;

    private void Awake()
    {
 
        txt = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        UpdateDifficulty();
    }

    private void UpdateDifficulty()
    { 
        if (PlayerPrefs.GetFloat("enemyDamage", 1) == 1)
        {
            txt.text = textIntro + "Facile";

        }
        else 
        txt.text = textIntro + "Diffcile";

    }



}
