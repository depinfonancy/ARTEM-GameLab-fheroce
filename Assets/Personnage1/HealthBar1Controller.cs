using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar1Controller : MonoBehaviour
{
    
    /*public GameObject healthIconPrefab; // this should be initialized in Unity Editor (see explanation in provided document)

    protected GameObject[] m_HealthIcons; // will store the icon created proceduraly depending on maximum number of life
    // in order to enable/disable them to display the right number of life
    public float m_IconTranslate = 100f;

  

    void Start()
    {
        Debug.Log("HB Start");
        m_HealthIcons = new GameObject[PersistantData.Instance.m_NbLiveInit];
        // create a new array with the right number of element (eg the number of life)

        for (int i = 0; i < PersistantData.Instance.m_NbLiveInit; i++)
        {
            GameObject healthIcon = Instantiate(healthIconPrefab);
            // Instantiation (eg creation) of a new object in the scene, the new object is a copy
            // of the prefab provided in parameter (the latter should be present in the scene)

            healthIcon.transform.SetParent(transform);
            // Set the new object has a child (in the scene hierarchy) of the HealthBar object.
            // This is important in order to have the icons to be descendent in the scene of the
            // Canvas object (in order to be rendered on screen) and to be child of the current object 
            // in order to be rendered in front of it
            // Then update the icon position in order for all icons to be visible :
            RectTransform healthIconRect = healthIcon.transform as RectTransform;
            healthIconRect.position += new Vector3(m_IconTranslate, 0f, 0f) * i;
            healthIcon.SetActive(true);

            m_HealthIcons[i] = healthIcon; // save in array to enable/disable them in function of number of remaining life
        }

        ChangeHitPointUI();
    }

    public void ChangeHitPointUI()
    {
        Debug.Log("HB ChangeHitPointUI");
        if (m_HealthIcons == null)
            return;

        for (int i = 0; i < m_HealthIcons.Length; i++)
        {
            m_HealthIcons[i].SetActive(i < PersistantData.Instance.m_NbLive1);
            // only activate the icons which index are smaller than the current number of lives
        }
    }*/


}
