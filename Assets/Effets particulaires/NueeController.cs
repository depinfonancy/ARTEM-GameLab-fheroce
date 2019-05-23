using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NueeController : MonoBehaviour
{

    public float timer2 = 3.0f;
    public GameObject firePrefab;

    void OnEnable()
    {
        StartCoroutine(Fire());
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            Debug.Log("Detruit");

        }
        
    }

    IEnumerator Fire()
    {
        float ttt = Time.time;
        yield return new WaitForSeconds(3.0f);

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