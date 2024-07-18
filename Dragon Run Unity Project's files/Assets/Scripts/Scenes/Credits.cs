using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI creditsText;
    [SerializeField] private float scrollSpeed = 50f;
    [SerializeField] private float endPositionY;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip gameMusic;
    private RectTransform rectTransform;


    private void Start()
    {
        rectTransform = creditsText.GetComponent<RectTransform>();
        SoundManager.instance.StopMusic();
        SoundManager.instance.PlayMusic(backgroundMusic);
    }

    private void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
        if (rectTransform.anchoredPosition.y >= endPositionY)
        {   
            SoundManager.instance.StopMusic();
            SoundManager.instance.PlayMusic(gameMusic);
            SceneManager.LoadScene(0);
        }
    }
}
