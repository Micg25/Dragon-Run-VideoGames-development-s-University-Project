using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;
    private AudioSource musicSource;

    private void Awake()
    {
        musicSource=transform.GetChild(0).GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        source = GetComponent<AudioSource>();

        ChangeMusicVolume(0);
        ChangeSoundVolume(0);
    }

    // Update is called once per frame
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PlayMusic(AudioClip _music)
    {
        musicSource.PlayOneShot(_music);

    }
    public void ChangeSoundVolume(float _change)
    {

        float baseVolume = 1;
        float currentVolume = PlayerPrefs.GetFloat("soundVolume",1);
        currentVolume += _change;
        if(currentVolume > 1)
        {

            currentVolume = 0;
        }
        else if(currentVolume < 0)
        {
            currentVolume = 1;

        }

        float finalVolume= currentVolume *baseVolume;
        source.volume = finalVolume;

        PlayerPrefs.SetFloat("soundVolume", currentVolume); 

    }

    public void ChangeMusicVolume(float _change)
    {

        float baseVolume = 0.3f;
        float currentVolume = PlayerPrefs.GetFloat("musicVolume",1);
        currentVolume += _change;
        if (currentVolume > 1)
        {

            currentVolume = 0;
        }
        else if (currentVolume < 0)
        {
            currentVolume = 1;

        }

        float finalVolume = currentVolume * baseVolume;
        musicSource.volume = finalVolume;
        

        PlayerPrefs.SetFloat("musicVolume", currentVolume);

    }
}
