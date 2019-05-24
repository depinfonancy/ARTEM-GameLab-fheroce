using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ennemies;
    public float xmin;
    public float xmax;
    private GameObject[] tableauDesCopiesDeMonstres = new GameObject[30];
    private float zLastMonster = 0;

    private int parcoursTableau = 0;

    public GameObject Perso;

   

    void Start()
    {
        
    }

    void Update()
    {
        if (Perso.transform.position.z >= zLastMonster - 10)
        {
            for (int i = 0; i <= (int)(Random.Range(1,6)); i++)
            {
                int monstreNumberAdded = Random.Range(0, ennemies.Length - 1);
                zLastMonster += 5;
                Destroy(tableauDesCopiesDeMonstres[parcoursTableau % 30]);
                tableauDesCopiesDeMonstres[parcoursTableau % 30] = Instantiate(ennemies[monstreNumberAdded], new Vector3(Random.Range(-1.0f,1.0f), -0.2f, zLastMonster), Quaternion.identity);
                parcoursTableau++;
                

            }
        }

    }

}
