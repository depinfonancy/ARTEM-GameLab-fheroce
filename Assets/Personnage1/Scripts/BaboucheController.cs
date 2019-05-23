using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaboucheController : MonoBehaviour
{

    public float timer = 3.0f;
    public GameObject firePrefab;
    public CapsuleCollider m_collider;
    
    void OnEnable()
    {
        StartCoroutine(Fire());
    }


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            Explode();
        }
    }

    void Update()
    {
        //OnTriggerEnter(m_collider);
    }

    void Awake()
    {
        m_collider = GetComponent<CapsuleCollider>();
    }


    IEnumerator Fire()
    {
        float ttt = Time.time;
        yield return new WaitForSeconds(3f);

        // We can check that the time is only at least 0.7 seconds
        //Debug.Log("TIME :");
        //Debug-.Log(Time.time - ttt);

        Explode();
    }

    void Explode()
    {
        //var explode = Instantiate(firePrefab, transform.position, Quaternion.identity);

        //explode.SetActive(true);
        //Destroy(explode, 0.3f); // we want to automatically destroy the explosion game object when the animation is finished
        
        Destroy(gameObject);
    }
}
