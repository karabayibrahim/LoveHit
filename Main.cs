using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Main : MonoBehaviour
{
    public GameObject Target;
    public GameObject Player;
    public GameObject Kamera;
    public LayerMask Deneme;
    public float Range = 1000.0f;
    public bool first = false;
    public string istek;
    public GameObject firstHit;
    public RectTransform Bow;
    public bool IsAnti;
    public bool slowhappened;
    public bool freezehappened;
    public bool antihappened;
    public int powerUpCount_slowed;
    public int powerUpCount_freeze;
    public int powerUpCount_anti;

    public bool Fire = false;
    public List<GameObject> npcArray = new List<GameObject>();
    //public string[] femArray = new string[10];
    //public string[] maleArray = new string[10];

    public List<string> femList = new List<string>();
    public List<string> maleList = new List<string>();
    public string surpriseNpc;
    public GameObject box;
    //public DynamicJoystick Joy;
    public GameObject surpriseNpcObj;
    public bool kontrol;
    public GameObject active;
    //public AudioSource a;
    //public AudioSource arrow;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Kamera = GameObject.FindGameObjectWithTag("MainCamera");
        Target = GameObject.Find("Target");
        int j = 0;
        int rangeObj = GameObject.FindGameObjectWithTag("MainObjects").transform.childCount;
        GameObject ob = GameObject.FindGameObjectWithTag("MainObjects");
        for (int i = 0; i < rangeObj; i++)
        {
            GameObject currentObj = ob.transform.GetChild(i).transform.gameObject;
            Debug.Log(currentObj.name);


            if (currentObj.tag == "Kaya")
            {
                npcArray.Add(currentObj);
                j++;
            }



        }
        powerUpCount_slowed= PlayerPrefs.GetInt("SavePowerYavas");
        powerUpCount_anti= PlayerPrefs.GetInt("SavePowerAnti");
        powerUpCount_freeze= PlayerPrefs.GetInt("SavePowerDonma");


        for (int i = 0; i < npcArray.Count; i++)
        {
            if (npcArray[i].name == "Male1B")
            {
                maleList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Male2B")
            {
                maleList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Male3B")
            {
                maleList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Male4B")
            {
                maleList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Male5B")
            {
                maleList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Male6B")
            {
                maleList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Male7B")
            {
                maleList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Male8B")
            {
                maleList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Male9B")
            {
                maleList.Add(npcArray[i].name);
            }


        }


        for (int i = 0; i < npcArray.Count; i++)
        {
            if (npcArray[i].name == "Female1B")
            {
                femList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Female2B")
            {
                femList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Female3B")
            {
                femList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Female4B")
            {
                femList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Female5B")
            {
                femList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Female6B")
            {
                femList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Female7B")
            {
                femList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Female8B")
            {
                femList.Add(npcArray[i].name);
            }
            else if (npcArray[i].name == "Female9B")
            {
                femList.Add(npcArray[i].name);
            }
        }
        Debug.Log("==========MALE ARRAY===========");
        for (int i = 0; i < maleList.Count; i++)
        {
            Debug.Log(maleList[i]);
        }

        //Surprise kutu icin secilen npc
        //surpriseNpc = npcArray[Random.Range(0, npcArray.Count)].name;
        //surpriseNpcObj = npcArray[Random.Range(0, npcArray.Count)];
       // Debug.Log(surpriseNpc + " SEÇİLDİİ");

        
        Debug.Log("COROUTINE STARTED");
        do
        {
            surpriseNpc = npcArray[Random.Range(0, npcArray.Count)].name;
            surpriseNpcObj = npcArray[Random.Range(0, npcArray.Count)];
            Debug.Log(surpriseNpc + " SEÇİLDİİ");


            Debug.Log("COROUTINE STARTED");
            if (surpriseNpcObj.gameObject.GetComponent<npcMatch>().SitNpc == false)
            {
                Invoke("SpawnSurprise", Random.Range(1f, 4f));
                break;
            }
            
        } while (surpriseNpcObj.gameObject.GetComponent<npcMatch>().SitNpc == true);
        
        

        //a.Play();

    }
    void Targetidentification()
    {
        //Target.transform.Translate(new Vector3(-Joy.Vertical, 0f, Joy.Horizontal) * 10f * Time.deltaTime);

        if (Input.GetButtonUp("Fire1"))
        {


            RaycastHit Contact;
            Ray Light = Kamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Light, out Contact, Range, Deneme))
            {
                //if (Contact.transform.gameObject.CompareTag("Nps"))
                //{
                //    Target.transform.position = Contact.point;
                //}

                if (Contact.transform.gameObject.CompareTag("Kaya") && FindObjectOfType<Surprise>().AntiArrow == false)
                {

                    //Debug.Log("NpsTemas");
                    Target.transform.position = Contact.point;
                    Player.transform.LookAt(Target.transform);
                    FindObjectOfType<Shooting>().Shoot();
                    for (int i = 0; i < npcArray.Count; i++)
                    {
                        npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    }
                    Contact.transform.gameObject.GetComponent<CapsuleCollider>().enabled = true;

                }
                if (FindObjectOfType<Surprise>().AntiArrow == true&&Contact.transform.gameObject.CompareTag("Anti"))
                {
                    Target.transform.position = Contact.point;
                    Player.transform.LookAt(Target.transform);
                    FindObjectOfType<Shooting>().Shoot();
                }




            }


        }



        //if (Touch.TouchDist.x > 0)
        //{
        //    Bow.transform.rotation = Quaternion.Lerp(Bow.transform.rotation, Quaternion.Euler(0f, 0f, 90f), 10f * Time.deltaTime);
        //}
        //if (Touch.TouchDist.x < 0)
        //{
        //    Bow.transform.rotation = Quaternion.Lerp(Bow.transform.rotation, Quaternion.Euler(0f, 0f, -90f), 10f * Time.deltaTime);
        //}
        //if (Touch.TouchDist.y > 0)
        //{
        //    Bow.transform.rotation = Quaternion.Lerp(Bow.transform.rotation, Quaternion.Euler(0f, 0f, -90f),10f* Time.deltaTime);
        //}
        //if (Touch.TouchDist.y < 0)
        //{
        //    Bow.transform.rotation = Quaternion.Lerp(Bow.transform.rotation, Quaternion.Euler(0f, 0f, 90f),10f* Time.deltaTime);
        //}
        //Debug.Log("X"+Touch.TouchDist.x);
        //Debug.Log("Y"+Touch.TouchDist.y);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Bow.transform.position = new Vector2(Touch.PointerOld.x, Touch.PointerOld.y);
        //}


        //Player.transform.LookAt(new Vector3(Target.transform.position.x, 0f, Target.transform.position.z))
        //Player.transform.LookAt(new Vector3(transform.position.x + Target.transform.position.x, 0f,transform.position.z + Target.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        Targetidentification();
    }

    void StartSpawn()
    {
        //StartCoroutine(SpawnSurprise());
    }

    void SpawnSurprise()
    {
        if (surpriseNpcObj!=null)
        {
            FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[15]);
            GameObject instantiated = Instantiate(box, surpriseNpcObj.transform.GetChild(3).transform.position, Quaternion.identity);
            instantiated.transform.parent = surpriseNpcObj.transform.GetChild(3).transform;
        }
        


        //yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        //StartCoroutine(SpawnBox());

    }
}
