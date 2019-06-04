using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class Personnage2Controller : MonoBehaviour
{
    //General imports  
    private Rigidbody m_RigidBody;
    private Animator m_Animator;
    private BoxCollider m_Collider;

    //Speeds 

    public float maxVSpeed;
    public float maxHSpeed;
    private float multiplicateur = 1.0f;



    //Tir 
    protected bool en_attaque = false;

    //Coroutine 
    protected Coroutine m_NueeShoot;
    protected float m_NextShotTime = 0.5f;
    protected float m_DeltaTime = 1 / 2f;
    public float NueeSpeed = 10f;
    public GameObject m_NueeCollider;
    public Transform m_PointDepart2;
    public ParticleSystem m_attaque_particule;
    public ParticleSystem m_nuee_particule;

    //Life 
    public Transform HealthBar;
    public GameObject Heart;
    public int life = 5;
    static int max_life = 5;
    protected GameObject[] m_Hearts = new GameObject[max_life];
    public float space = 0.01f;
    public float x=520;
    public float y=50;
    public float z;

    //Game Over Menue 
    public GameObject Menue;
    public Text scorefinal;

    //Collision avec les murs 
    public float minx;
    public float maxx;

    //Rolling carpet 
    private bool on_rolling_carpet = false;
    private int times_on_roll = 5;


    private void Update()
    {
        CheckAttaque();

    }

    //General imports : 
    private void Awake()
    {
        
        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<BoxCollider>();
        life = max_life;
        //Debug.Log("Ici");
        for (int i = 0; i < max_life; i++)
        {
            m_Hearts[i] = Instantiate(Heart);
            m_Hearts[i].transform.SetParent(HealthBar);
            //RectTransform HeartRect = m_Hearts[i].transform as RectTransform;
            m_Hearts[i].transform.position = new Vector3(x + 30*i, y, z);
            //HeartRect.position += new Vector3(i * space, 0f, 0f);
            m_Hearts[i].SetActive(true);
            //Debug.Log(i);
        }

        
    }

    private void FixedUpdate()
    {

        Move(Input.GetAxis("Vertical"), false);
        //Attacking 
        /*if (Input.GetButtonDown("Fire1"))
        {
            life = life - 1;
            Debug.Log(life);

        }*/
        Update_healthbar(life);

    }


    private void Move(float x, bool jump)
    {
        multiplicateur = multiplicateur * 1.001f; 
        //Debug.Log("Là");
        if (jump)
        {
            m_RigidBody.velocity = new Vector3(x * maxHSpeed, maxVSpeed, 0.5f*multiplicateur);
        }
        else
        {
            m_RigidBody.velocity = new Vector3(x * maxHSpeed, 0, 0.5f*multiplicateur);
        }
        //Debug.Log(m_RigidBody.velocity);
        if (m_RigidBody.position.x > maxx)
        {
            m_RigidBody.position = new Vector3(maxx, m_RigidBody.position.y, m_RigidBody.position.z);
        }
        if (m_RigidBody.position.x < minx)
        {
            m_RigidBody.position = new Vector3(minx, m_RigidBody.position.y, m_RigidBody.position.z);
        }
        if (on_rolling_carpet & times_on_roll > 0)
        {
            m_RigidBody.AddForce(new Vector3(1000, 0, 0));
            times_on_roll -= 1;
        }

        if (times_on_roll == 0)
        {
            on_rolling_carpet = false;
        }

    }


  

    private void Update_healthbar(int life0)
    {
        if (life == 0)
        {
            //SceneManager.LoadScene("GameOver");
            m_RigidBody.velocity = new Vector3(0, 0, 0);
            Menue.SetActive(true);
            scorefinal.text = "Score final :" + m_RigidBody.position.z;
        }
        for (int i = 0; i < max_life; i++)
        {
            if (i >= life0)
            {
                m_Hearts[i].SetActive(false);
            }
        }

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            life = life - 1;
        }
        if (coll.gameObject.tag == "RollingCarpet")
        {
            Debug.Log("TOUCHED ROLLING CARPET");
            on_rolling_carpet = true;
            times_on_roll = 12;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            life = life - 1;
        }
    }

    public void Looselife()
    {
        life = life - 1;
        Debug.Log("Life 2 decreased");
    }


    //Nuée 

    protected IEnumerator Shoot()
    {
        while (en_attaque)
        {
            yield return new WaitForSeconds(5.0f);
            if (Time.time >= m_NextShotTime)
            {
                Projectile();
                m_NextShotTime = Time.time + m_DeltaTime;
            }
            yield return new WaitForFixedUpdate();
            //yield return null;
        }
    }

    public void CheckAttaque()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Escape pushed");
            en_attaque = true;
            /*m_NueeShoot = StartCoroutine(Shoot());
            m_attaque_particule.Play();
            m_nuee_particule.Stop();*/
            m_NueeCollider.SetActive(true);

        }

        else if (Input.GetButtonUp("Fire2"))
        {
            Debug.Log("escape released");
            en_attaque = false;
            /*StopCoroutine(Shoot());
            m_NueeShoot = null;
            m_attaque_particule.Stop();
            m_nuee_particule.Play();*/
            m_NueeCollider.SetActive(false);
        }
    }

    protected void Projectile()
    {
        Vector2 posStart = m_PointDepart2.transform.position;

        GameObject Nuee = Instantiate(m_NueeCollider, posStart, Quaternion.identity); // Create a new game object from the prefab

        Transform t = Nuee.GetComponent<Transform>();

        Nuee.SetActive(true); // ensure the new object is Active to be visible within the scene

    }
}



