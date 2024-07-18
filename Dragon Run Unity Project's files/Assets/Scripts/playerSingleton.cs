using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    // Singleton instance
    private static PlayerSingleton instance;

  
    public static PlayerSingleton Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
       
        if (instance != null && instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); 
    }



}
