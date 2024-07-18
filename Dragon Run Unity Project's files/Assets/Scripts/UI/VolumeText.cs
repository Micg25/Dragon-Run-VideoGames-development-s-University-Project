using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    [SerializeField] private string volumeName;
    [SerializeField] private string textIntro;
    private TextMeshProUGUI txt;

    private void Awake()
    {
        txt = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat(volumeName)*100;
        txt.text = textIntro + PlayerPrefs.GetFloat(volumeName).ToString();

    }



}
