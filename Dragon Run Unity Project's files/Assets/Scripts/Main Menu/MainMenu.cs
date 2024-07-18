using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        //Time.timeScale = 1;
        Physics2D.IgnoreLayerCollision(10, 12, false);
        Physics2D.IgnoreLayerCollision(10, 13, false);
        Physics2D.IgnoreLayerCollision(10, 14, false);
        PlayerPrefs.SetFloat("startingHealth", 3);
        PlayerPrefs.SetInt("currentScene", 1);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("levelScore", 0);
    }
    public void Quit()
    {
        Application.Quit();


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif


    }
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);

    }
    public void MusicVolume()
    {

        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

    public void Difficulty()
    {
        if(PlayerPrefs.GetFloat("enemyDamage", 1) == 1)
        {
            PlayerPrefs.SetFloat("enemyDamage", 2);
        }
        else
            PlayerPrefs.SetFloat("enemyDamage", 1);
    }
    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentScene", 1));
        PlayerPrefs.SetFloat("startingHealth", 3);
        Physics2D.IgnoreLayerCollision(10, 12, false);
        Physics2D.IgnoreLayerCollision(10, 13, false);
        Physics2D.IgnoreLayerCollision(10, 14, false);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("levelScore", 0);
        //Time.timeScale = 1;

    }
}
