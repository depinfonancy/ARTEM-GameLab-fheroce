using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    private Vector3 offset;
    private Vector3 init;

    void Start()
    {
        offset = transform.position - player1.transform.position;
        init = transform.position;
    }

    void LateUpdate()
    {
        if (player1.transform.position.z >= player2.transform.position.z)
        {
            transform.position = new Vector3(0, init.y, (player2.transform.position + offset).z);
        }
        else
        {
            transform.position = new Vector3(0, init.y, (player1.transform.position + offset).z);
        }
    }
}
