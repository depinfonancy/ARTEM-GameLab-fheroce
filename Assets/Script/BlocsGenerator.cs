using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocsGenerator : MonoBehaviour
{
    public int lengthBloc = 4;
    public GameObject player;
    public GameObject spot;
    public GameObject eclairage;

    private GameObject[] tableauDesCopiesDeBlocs = new GameObject[50];
    private int parcoursTableau = 0;
    private GameObject[] tableauDeBlocs;
    private int NumberOfBlocs = 1;
    private int blocNumberAdded;
    private float zLastBlocCenter = 0.0f;

    void Start()
    {
        tableauDeBlocs = GameObject.FindGameObjectsWithTag("Blocs");
        blocNumberAdded = Random.Range(0, tableauDeBlocs.Length-1);
        for (int i = 0; i < 6; i++)
        {
            zLastBlocCenter += lengthBloc;
            NumberOfBlocs++;
            tableauDesCopiesDeBlocs[parcoursTableau] = Instantiate(tableauDeBlocs[blocNumberAdded], new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
            parcoursTableau++;
        }
    }

// Update is called once per frame
void Update()
    { if (player.transform.position.z >= (NumberOfBlocs - 30) * lengthBloc)
        {
            blocNumberAdded = Random.Range(0, tableauDeBlocs.Length - 1);
            for (int i = 0; i < 10; i++)
            {
                zLastBlocCenter += lengthBloc;
                NumberOfBlocs++;
                Destroy(tableauDesCopiesDeBlocs[parcoursTableau % 50]);
                tableauDesCopiesDeBlocs[parcoursTableau % 50] = Instantiate(tableauDeBlocs[blocNumberAdded], new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
                parcoursTableau++;
                if (i == 5)
                {
                    Destroy(tableauDesCopiesDeBlocs[parcoursTableau % 50]);
                    tableauDesCopiesDeBlocs[parcoursTableau % 50] = Instantiate(eclairage, new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
                    parcoursTableau++;
                }
            }
            Destroy(tableauDesCopiesDeBlocs[parcoursTableau % 50]);
            tableauDesCopiesDeBlocs[parcoursTableau % 50] = Instantiate(spot, new Vector3(0.0f, 0.0f, zLastBlocCenter), Quaternion.identity);
            parcoursTableau++;
        }

    }
}
