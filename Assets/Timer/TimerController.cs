using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TimerController : MonoBehaviour
{
    public Transform Player1;
    public Text countdown; //UI Text Object
    public float score = 0f;
    void Start()
    {

    }

    private void Awake()
    {

    }
    void Update()
    {
        score = Player1.position.z;
        countdown.text = "Score :" + (Player1.position.z); //Showing the Score on the Canvas
    }
}