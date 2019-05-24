using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocsGenerator : MonoBehaviour
{
    public int lengthBloc = 4;
    public GameObject player;
    public GameObject spot;
    public GameObject eclairage;

    private GameObject[] tableauDesCopiesDeBlocs = new GameObject[30];
    private GameObject[] monstres;
  
    private int parcoursTableau = 0;
  
    private GameObject[] tableauDeBlocs;
    
    private int NumberOfBlocs = 1;
    private int blocNumberAdded;
   
    private float zLastBlocCenter = 0.0f;

    void Start()
    {
        tableauDeBlocs = GameObject.FindGameObjectsWithTag("Blocs");
        monstres = GameObject.FindGameObjectsWithTag("Enemy");
     }

// Update is called once per frame
void Update()
    { if (player.transform.position.z >= (NumberOfBlocs - 10) * lengthBloc)
        {
            blocNumberAdded = Random.Range(0, tableauDeBlocs.Length - 1);
            for (int i = 0; i < 10; i++)
            {
                zLastBlocCenter += lengthBloc;
                NumberOfBlocs++;
                Destroy(tableauDesCopiesDeBlocs[parcoursTableau % 30]);
                tableauDesCopiesDeBlocs[parcoursTableau % 30] = Instantiate(tableauDeBlocs[blocNumberAdded], new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
                parcoursTableau++;
                if (i == 5)
                {
                    Destroy(tableauDesCopiesDeBlocs[parcoursTableau % 30]);
                    tableauDesCopiesDeBlocs[parcoursTableau % 30] = Instantiate(eclairage, new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
                    parcoursTableau++;
                }
                int monstreNumberAdded = Random.Range(0, monstres.Length - 1);
                Instantiate(monstres[monstreNumberAdded], new Vector3(Random.Range(-1.0f, 1.0f), -0.6f, zLastBlocCenter), Quaternion.identity);
                    
                
                
            }
            Destroy(tableauDesCopiesDeBlocs[parcoursTableau % 30]);
            tableauDesCopiesDeBlocs[parcoursTableau % 30] = Instantiate(spot, new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
            parcoursTableau++;

            
                
            }

    }
}
