using System.Collections;
using UnityEngine;

public class FallingTerrain : MonoBehaviour
{

    private Vector3 initialPosition;
    private Rigidbody2D body;
    private bool isFalling = false;


    private void Awake()
    {
        initialPosition= this.transform.position;
        body = GetComponent<Rigidbody2D>();
    }
    public IEnumerator Fall()
    {
        
        if (!isFalling)
        {
        isFalling = true;
        yield return new WaitForSeconds(0.5f);
        body.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(4);
        body.bodyType = RigidbodyType2D.Static;
        this.transform.position = initialPosition;
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        isFalling = false;
    }
}
