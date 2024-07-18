using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{
    //Follow room
    [SerializeField]private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float currentY;
    private Vector3 targetPosition;
    private float lookAhead;
    private bool moving = false;
    [SerializeField] private float yedge;
    [SerializeField] private bool movingtoY = false;
    

    private void Awake()
    {
        currentY=player.transform.position.y;
    }
    private void Update()
    {

        if (PlayerSingleton.Instance != null)
        {
            player = PlayerSingleton.Instance.transform;
        }


            if (moving && !movingtoY)
        {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, speed);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                moving = false;
        }

        if (!moving && !movingtoY)
        {
            transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        }
        if(Mathf.Abs(player.transform.position.y - currentY) > yedge && !movingtoY)
        {   
            
            Vector3 currentPos = player.position;
            movingtoY = true;
            currentY=currentPos.y;
            StartCoroutine (movingToY(currentPos));
        }

    }
    IEnumerator movingToY(Vector3 targetPos)
    {
        
        while (Mathf.Abs(transform.position.y - targetPos.y) > 0.01f)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, targetPos.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, speed);
            yield return null;
        }
        
        movingtoY = false;
    }
        public void MoveToNewRoom()
    {

        moving = true;
        targetPosition = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
        
        
    }
    public void MoveToCheckpoint(Transform checkpoint)
    {

        moving = true;
        targetPosition = new Vector3(checkpoint.position.x + lookAhead, transform.position.y, transform.position.z);


    }
}
