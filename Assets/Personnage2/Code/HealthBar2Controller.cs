using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar2Controller : MonoBehaviour
{
    /*public GameObject healthIconPrefab; // this should be initialized in Unity Editor (see explanation in provided document)

    protected GameObject[] m_HealthIcons; // will store the icon created proceduraly depending on maximum number of life
    // in order to enable/disable them to display the right number of life
    public float m_IconTranslate = 5f;

    void Start()
    {
        m_HealthIcons = new GameObject[PersistantData.Instance.m_NbLiveInit];
        // create a new array with the right number of element (eg the number of life)

        for (int i = 0; i < PersistantData.Instance.m_NbLiveInit; i++)
        {
            GameObject healthIcon = Instantiate(healthIconPrefab);

            healthIcon.transform.SetParent(this.transform);

            RectTransform healthIconRect = healthIcon.transform as RectTransform;
            healthIconRect.position += new Vector3(m_IconTranslate, 0f, 0f) * i;
            healthIcon.SetActive(true);

            //m_HealthIcons[i] = healthIcon; // save in array to enable/disable them in function of number of remaining life
        }

       // ChangeHitPointUI();
    }

    public void ChangeHitPointUI()
    {
        Debug.Log("Ici !");
        if (m_HealthIcons == null)
            return;

        for (int i = 0; i < m_HealthIcons.Length; i++)
        {
            if (i < PersistantData.Instance.m_NbLive2)
            {
                m_HealthIcons[i].SetActive(true);
            }
            
            // only activate the icons which index are smaller than the current number of lives
        }
    }*/
}
