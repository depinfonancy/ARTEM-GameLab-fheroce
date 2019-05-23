using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;
    private Vector3 init;

    void Start()
    {
        offset = transform.position - player.transform.position;
        init = transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(0, init.y, (player.transform.position + offset).z);
    }
}
