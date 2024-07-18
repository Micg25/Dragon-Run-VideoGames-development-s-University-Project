using UnityEngine;

public class Door : MonoBehaviour
{
   
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    
    
    private void Awake()

    {
   

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            print("collisione");
                if(collision.transform.position.x < transform.position.x)
            {   
                previousRoom.GetComponent<Room>().ActivateRoom(false);
                nextRoom.GetComponent<Room>().ActivateRoom(true);
               
            }
            else
            {
                previousRoom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);
            }
        }
    }

}
