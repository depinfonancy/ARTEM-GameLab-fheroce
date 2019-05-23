using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour
{
    public int timeLeft = 0; //Seconds Overall
    public Text countdown; //UI Text Object
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }

    private void Awake()
    {
        timeLeft = 0;
        StartCoroutine("LoseTime");
        //Time.timeScale = 1;
    }
    void Update()
    {
        countdown.text = ("" + timeLeft); //Showing the Score on the Canvas
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            //yield return new WaitForSeconds(1);
            timeLeft = timeLeft + 1;
        }
    }
}