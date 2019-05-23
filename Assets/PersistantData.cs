using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// exemple to keep data between scene

public class PersistantData : MonoBehaviour
{
    /*public int m_NbLiveInit = 5;
    public int m_NbLive1 = 2;
    public int m_NbLive2 = 3;


    public static PersistantData Instance
    {
        get
        {
            Debug.Log("PD Instance");
            // if static variable is already initialized, use it
            if (s_Instance != null)
                return s_Instance;

            // otherwise find if it is already present in the scene
            s_Instance = FindObjectOfType<PersistantData>();
            if (s_Instance != null)
                return s_Instance;

            // if not found create it
            Create();

            return s_Instance;
        }
    }

    protected static PersistantData s_Instance;

    public static PersistantData Create()
    {
        Debug.Log("PD Create");
        // Create a new empty game object ot store the script
        GameObject persistentDataGameObject = new GameObject("PersistantData");
        DontDestroyOnLoad(persistentDataGameObject); // GameObject (and associated script) should not be destroyed between scene
        s_Instance = persistentDataGameObject.AddComponent<PersistantData>();
        return s_Instance;
    }

    void Awake()
    {
        Debug.Log("PD Awake");
        if (s_Instance != this)
        {
            // if the static instence does not correspond to this object, destroy it to avoid duplicates
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // GameObject (and associated script) should not be destroyed between scene
    }

    public void ResetPlayerLife()
    {
        Debug.Log("PD ResetPlayerLife");
        m_NbLive1 = m_NbLiveInit;
        //m_NbLive2 = m_NbLiveInit;
        Debug.Log("Done");

        // Find the HealthBar if it exist in scene in order to update the UI
        GameObject healthBar1 = GameObject.Find("HealthBar1");
        //GameObject healthBar2 = GameObject.Find("HealthBar2");
        if (healthBar1 != null)
        {
            healthBar1.GetComponent<HealthBar1Controller>().ChangeHitPointUI();
        }

        /*if (healthBar2 != null)
        {
            healthBar2.GetComponent<HealthBar2Controller>().ChangeHitPointUI();
        }
    }

    public void DecrementPlayer1Life()
    {
        Debug.Log("PD DecrementPlayerLife");
        m_NbLive1 -= 1;

        // Find the HealthBar if it exist in scene in order to update the UI
        GameObject healthBar = GameObject.Find("HealthBar1");
        if (healthBar != null)
        {
            healthBar.GetComponent<HealthBar1Controller>().ChangeHitPointUI();
        }

        // No remaining life => GameOver
        if (m_NbLive1 == 0)
        {
            //SceneManager.LoadScene("Opening");
        }
    }

    /*public void DecrementPlayer2Life()
    {
        GameObject healthBar = GameObject.Find("HealthBar2");
        if (healthBar != null)
        {
            healthBar.GetComponent<HealthBar2Controller>().ChangeHitPointUI();
        }
    
        if (m_NbLive2 == 0)
        {
            // GAME OVER
        }
    }*/
}
