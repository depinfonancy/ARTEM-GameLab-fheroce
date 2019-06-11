using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    
    Vector3 Movement;
    public float speed;
	public float h_coef = 1.0f ;
	private float hspeed ;
    private GameObject Player1;
    private GameObject Player2;
    private Vector3 position1;
    private Vector3 position2;
	private float amplitude ;
	private float xCenter ;
	private Vector3 orientation ;
    // Start is called before the first frame update
    void Start()
    {
		amplitude = .4f ;
        m_Rigidbody = GetComponent<Rigidbody>();
		xCenter = m_Rigidbody.transform.position.x ;
		hspeed = h_coef * speed ;
        Movement = new Vector3(hspeed, 0, -speed);
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
            Destroy(transform.gameObject);
        }
		if ((m_Rigidbody.transform.position.x >= (xCenter + amplitude)) || (m_Rigidbody.transform.position.x > 1))
		{
			Movement = new Vector3(- hspeed, 0, -speed) ;
			orientation = m_Rigidbody.transform.localScale ;
			orientation.x = - orientation.x ;
			m_Rigidbody.transform.localScale = orientation ;
		}
		if ((m_Rigidbody.transform.position.x <= (xCenter - amplitude)) || (m_Rigidbody.transform.position.x < -1))
		{
			Movement = new Vector3(hspeed, 0, -speed) ;
			orientation = m_Rigidbody.transform.localScale ;
			orientation.x = - orientation.x ;
			m_Rigidbody.transform.localScale = orientation ;
		}
			
		
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
        {
            Destroy(m_Rigidbody.gameObject);
        }
    
    }

}
