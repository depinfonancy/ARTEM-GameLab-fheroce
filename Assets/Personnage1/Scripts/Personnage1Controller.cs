using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
public class Personnage1Controller : MonoBehaviour
{
    //General imports  
    private Rigidbody m_RigidBody;
    private Animator m_Animator;
    private BoxCollider m_Collider;

    //Speeds 

    public float maxVSpeed=10f;
    public float maxHSpeed=10f;
    private float multiplicateur = 1.0f;
    private readonly int m_HSpeed = Animator.StringToHash("Speed");
    private readonly int m_Attack = Animator.StringToHash("Attacking");

    //Tir 
    protected bool en_tir = false;

    //Coroutine 
    protected Coroutine m_BaboucheShoot;
    protected float m_NextShotTime = 0.5f;
    protected float m_DeltaTime = 1 / 2f;
    public float BaboucheSpeed = 10f;
    public GameObject BaboucheSprite;
    public Transform m_PointDepart;

    //Life 
    public Transform HealthBar;
    public GameObject Heart;
    public int life = 5;
    static int max_life = 5;
    protected GameObject[] m_Hearts = new GameObject[max_life];
    public float space = 0.01f;
    public float x=22;
    public float y=50;
    public float z;

    //Game Over Menue 
    public GameObject Menue;
    public Text scorefinal;

    //Collisions avec les murs 
    public float minx;
    public float maxx;

    //Rolling carpet 
    private bool on_rolling_carpet = false;
    private int times_on_roll = 5;
    

    void Start()
    {
        
    }

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
        //GetComponent<PersistantData>().ResetPlayerLife();
        life = max_life;
        //Debug.Log("Ici");
        for (int i = 0; i < max_life; i++)
        {
            m_Hearts[i] = Instantiate(Heart);
            m_Hearts[i].transform.SetParent(HealthBar);
            //RectTransform HeartRect = m_Hearts[i].transform as RectTransform;
            m_Hearts[i].transform.position = new Vector3(x+30*i,y,z);
            //HeartRect.position += new Vector3(i * space, 0f, 0f);
            m_Hearts[i].SetActive(true);
            //Debug.Log(i);
        }

    }

    private void FixedUpdate()
    {
        //Debug 
        //Debug.Log(Input.GetAxis("Fire3"));
        //Moving 

        if (Input.GetAxis("Horizontal") != 0)
        {
            //Debug.Log(Input.GetAxis("Horizontal"));
        }

        Move(Input.GetAxis("Horizontal"), false);

        //Attacking 

        m_Animator.SetBool(m_Attack, en_tir);

        //Life 

        Update_healthbar(life);

    }

    private void Update_healthbar(int life0)
    {
        for (int i =0; i<max_life; i++)
        {
            if (i >= life0)
            {
                m_Hearts[i].SetActive(false);
            }
        }
        if (life0 == 0)
        {
            //game over
            //SceneManager.LoadScene("GameOver");
            m_RigidBody.velocity = new Vector3(0, 0, 0);
            Menue.SetActive(true);
            scorefinal.text = "Score final :" + m_RigidBody.position.z;

        }
    }

    private void Move(float x, bool jump)
    {
        multiplicateur = multiplicateur * 1.001f;
        if (jump)
        {
            m_RigidBody.velocity = new Vector3(x * maxHSpeed,  maxVSpeed, 0.5f*multiplicateur);
        }
        else
        {
            m_RigidBody.velocity = new Vector3(x * maxHSpeed, 0, 0.5f*multiplicateur);
        }
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


        m_Animator.SetFloat(m_HSpeed,Mathf.Abs(x));
    }
    

    //Lancer de babouche 

    protected IEnumerator Shoot()
    {
        while (en_tir)
        {
            yield return new WaitForSeconds(0.5f);
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
        if (Input.GetButtonDown("Fire1"))
        {
            en_tir = true;
            m_BaboucheShoot = StartCoroutine(Shoot());
        
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            en_tir = false;
            StopCoroutine(Shoot());
            m_BaboucheShoot = null;
        }
    }


    protected void Projectile()
    {
        Vector3 posStart = m_PointDepart.transform.position;

        GameObject Bababouche = Instantiate(BaboucheSprite, posStart, Quaternion.identity); // Create a new game object from the prefab

        Transform t = Bababouche.GetComponent<Transform>();

        Bababouche.SetActive(true); // ensure the new object is Active to be visible within the scene

        Bababouche.GetComponent<Rigidbody>().velocity = new Vector3(0,BaboucheSpeed/2f,BaboucheSpeed);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Looselife();
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
            Looselife();
        }
    }

    public void Looselife()
    {
        life = life-1;
        Debug.Log("life 1 decreased");
    }
}

    

