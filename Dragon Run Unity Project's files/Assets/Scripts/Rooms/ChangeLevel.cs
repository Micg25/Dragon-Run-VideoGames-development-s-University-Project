using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            

            
            int nextSceneIndex = currentSceneIndex + 1;
            

            if(nextSceneIndex == 5)
            {
                
                SceneManager.LoadScene(nextSceneIndex);


                PlayerSingleton playerSingleton = FindObjectOfType<PlayerSingleton>();
                if (playerSingleton == null)
                {
                    Debug.LogWarning("PlayerSingleton non trovato nella scena. Assicurati di averlo aggiunto alla scena o che sia stato istanziato correttamente.");
                }
            }

            else if (nextSceneIndex < SceneManager.sceneCountInBuildSettings )
            {
                PlayerPrefs.SetInt("currentScene", nextSceneIndex);

                SceneManager.LoadScene(nextSceneIndex);

             
                PlayerSingleton playerSingleton = FindObjectOfType<PlayerSingleton>();
                if (playerSingleton == null)
                {
                    Debug.LogWarning("PlayerSingleton non trovato nella scena. Assicurati di averlo aggiunto alla scena o che sia stato istanziato correttamente.");
                }
            }
            else
            {
                
                
                Debug.LogWarning("Questo è l'ultimo livello.");
            }
        }
    }
}
