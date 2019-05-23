using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    Vector3 Movement;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Movement = new Vector3(0, 0, -speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_Rigidbody.velocity = Movement;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player1")
        {
            GetComponent<Personnage1Controller>().Looselife();
        }


        if (col.gameObject.tag == "Player2")
        {
            GetComponent<Personnage2Controller>().Looselife();
        }



    }


}
