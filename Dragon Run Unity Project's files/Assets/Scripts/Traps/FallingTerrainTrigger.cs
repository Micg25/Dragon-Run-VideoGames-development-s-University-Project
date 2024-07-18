using UnityEngine;

public class FallingTerrainTrigger : MonoBehaviour
{
    private FallingTerrain fallingTerrain;
    private void Awake()
    {
        fallingTerrain = GetComponentInParent<FallingTerrain>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(fallingTerrain.Fall());
        }
        
    }
}
