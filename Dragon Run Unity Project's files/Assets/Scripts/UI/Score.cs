using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private string textIntro;
    private TextMeshProUGUI txt;

    private void Awake()
    {
        txt = GetComponentInChildren<TextMeshProUGUI>();
        if (txt == null)
        {
            Debug.LogError("Text component not found on " + gameObject.name);
        }
    }
    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        txt.text = textIntro + PlayerPrefs.GetInt("Score", 0).ToString();
        
    }



}
