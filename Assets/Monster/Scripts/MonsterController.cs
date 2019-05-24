using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    
    Vector3 Movement;
    public float speed;
    private GameObject Player1;
    private GameObject Player2;
    private Vector3 position1;
    private Vector3 position2;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        
        Movement = new Vector3(0, 0, -speed);
        Player1 = GameObject.Find("Personnage");
        Player2 = GameObject.Find("Personnage2 Variant");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_Rigidbody.velocity = Movement;
        position1 = Player1.transform.position;
        position2 = Player2.transform.position;
        if(transform.position.z < position1.z -10.0f && transform.position.z < position2.z -10.0f)
        {
            print("Le monstre a été évité");
            Destroy(transform.gameObject);
        }       
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
        {
            print("Attention à toi");
            Destroy(m_Rigidbody.gameObject);
        }
    
    }

}
