using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOpenningDoor : MonoBehaviour
{
    public float speed;
    public float currentValue = 0.0f;
    public float maxOpenValue;

    public Transform door;
    public bool opening = false;
    public bool closing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { if (opening)
        {
            OpenDoor();
        }   
    if (closing)
        {
            CloseDoor();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            opening = true;
            closing = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Player") { 
            closing = true;
            opening = false;
        }
    } 

    void OpenDoor() {
        {
            float movement = speed * Time.deltaTime;
            currentValue += movement;

            if (currentValue <= maxOpenValue)
            {
                door.position = new Vector3(door.position.x, door.position.y - movement, door.position.z);
            } else
            {
                opening = false;
            }
        }
    }

    void CloseDoor()
    {
        {
            float movement = speed * Time.deltaTime;
            currentValue -= movement;

            if (currentValue >= 0)
            {
                door.position = new Vector3(door.position.x, door.position.y + movement, door.position.z);
            } else
            {
                closing = false;
            }
        }
    }
}
