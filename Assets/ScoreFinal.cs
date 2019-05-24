using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class ScoreFinal : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scorefinal;
    void Start()
    {
        
    }

    void Awake()
    {
        scorefinal.text = ""+GetComponent<TimerController>().score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
