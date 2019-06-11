using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocsGenerator : MonoBehaviour
{
    public int lengthBloc = 4;

    public GameObject player;
    public GameObject spot;
    public GameObject eclairage;

    private int longueurTableau = 36;
    private GameObject[] tableauDesCopiesDeBlocs = new GameObject[36];
    public GameObject[] monstres = new GameObject[8];
  
    private int parcoursTableau = 0;
  
    public GameObject[] tableauDeBlocs = new GameObject[8];
    
    private int blocNumberAdded;
   
    private float zLastBlocCenter = 0.0f;

    void Start()
    {
        
        
     }

// Update is called once per frame
void Update()
    { if (player.transform.position.z >= (parcoursTableau - 26) * lengthBloc)
        {
            blocNumberAdded = Random.Range(0, tableauDeBlocs.Length - 1);
            for (int i = 0; i < 9; i++)
            {
                
                Destroy(tableauDesCopiesDeBlocs[parcoursTableau % longueurTableau]);
                tableauDesCopiesDeBlocs[parcoursTableau % longueurTableau] = Instantiate(tableauDeBlocs[blocNumberAdded], new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
                parcoursTableau++; zLastBlocCenter += lengthBloc;
                if (i == 5)
                {
                    Destroy(tableauDesCopiesDeBlocs[parcoursTableau % longueurTableau]);
                    tableauDesCopiesDeBlocs[parcoursTableau % longueurTableau] = Instantiate(eclairage, new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
                    parcoursTableau++;
                }
                int monstreNumberAdded = Random.Range(0, monstres.Length - 1);
				
				if (monstreNumberAdded == 5)
				{
					Instantiate(monstres[monstreNumberAdded], new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, zLastBlocCenter), Quaternion.identity);
				}
				else
				{
					Instantiate(monstres[monstreNumberAdded], new Vector3(Random.Range(-1.0f, 1.0f), -0.6f, zLastBlocCenter), Quaternion.identity);
				}
                
                
            }
            Destroy(tableauDesCopiesDeBlocs[parcoursTableau % longueurTableau]);
            tableauDesCopiesDeBlocs[parcoursTableau % longueurTableau] = Instantiate(spot, new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
            parcoursTableau++;

            
                
            }

    }
}
