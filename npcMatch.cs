
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class npcMatch : MonoBehaviour
{
    public bool erkek = false;
    public bool kadın = false;
    //private string[] erkekArray = { "Male1B", "Male2B", "Male3B" };
    //private string[] kadınArray = {"Female1B", "Female2B", "Female3B"};
    //public string istek;
    public GameObject arrow;
    private Collider coll;

    private Ok okCode;
    private Surprise surpriseCode;
    public bool IsSurprise;
    //public bool first = false;

    public Main Maincode;
    //public GameObject bubble;
    // Start is called before the first frame update
    [Header("Males")]
    public GameObject Male1;
    public GameObject Male2;
    public GameObject Male3;
    public GameObject Male4;
    public GameObject Male5;
    public GameObject Male6;
    public GameObject Male7;
    public GameObject Male8;
    public GameObject Male9;
    [Header("Females")]
    public GameObject Female1;
    public GameObject Female2;
    public GameObject Female3;
    public GameObject Female4;
    public GameObject Female5;
    public GameObject Female6;
    public GameObject Female7;
    public GameObject Female8;
    public GameObject Female9;
    public GameObject LovePar;
    public bool Vurulma = false;
    public ParticleSystem Kalp1;
    public ParticleSystem Kalp2;
    public bool IsAnti = false;
    public Text cnt;
    public int count = 0;
    public GameObject MatchPar;
    public Transform Parpoz;
    public GameObject BrokePar;
    Animator Anim;
    public bool SitNpc;
    GameManager Manager;
    
    void Start()
    {
        
        Manager = FindObjectOfType<GameManager>();
        //arrow = GameObject.FindGameObjectWithTag("Arrow");
        //coll = arrow.GetComponent<Collider>();
        Anim = GetComponent<Animator>();
        Maincode = FindObjectOfType<Main>();
        okCode = FindObjectOfType<Ok>();
        surpriseCode = FindObjectOfType<Surprise>();
        //Kalp1 = GameObject.Find("Kalp1").GetComponent<ParticleSystem>();
        //Kalp2 = GameObject.Find("Kalp2").GetComponent<ParticleSystem>();
        Parpoz = GameObject.Find("ParPoz").transform;
        if (gameObject.name == "Female1B" || gameObject.name == "Female2B" || gameObject.name == "Female3B" || gameObject.name == "Female4B" || gameObject.name == "Female5B" || gameObject.name == "Female6B" || gameObject.name == "Female7B" || gameObject.name == "Female8B" || gameObject.name == "Female9B")
        {
            kadın = true;
        }
        else if (gameObject.name == "Male1B" || gameObject.name == "Male2B" || gameObject.name == "Male3B"|| gameObject.name == "Male4B" || gameObject.name == "Male5B" || gameObject.name == "Male6B" || gameObject.name == "Male7B" || gameObject.name == "Male8B" || gameObject.name == "Male9B")
        {
            erkek = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //cnt.text = count.ToString();
        if (SitNpc==false)
        {
            if (gameObject.transform.GetChild(3).childCount == 1)
            {
                if (gameObject.transform.GetChild(3).transform.GetChild(0).name == "SurpriseBox(Clone)")
                {
                    Debug.Log("SURPRISE found");
                    IsSurprise = true;
                    Anim.SetBool("Walk", false);
                    Anim.SetBool("WalkBox", true);
                    //animasyonu kutu tutsun
                }

            }
            else
            {
                IsSurprise = false;
                Anim.SetBool("WalkBox", false);
                Anim.SetBool("Carry", false);
                //normal anim
            }
        }
        

    }

    //IEnumerator Waiter()
    //{
    //    yield return new WaitForSeconds(5);
    //}
    public void Yoket()
    {
        Destroy(Maincode.firstHit);
    }
    public void Istek()
    {
        if (kadın == true)
        {
            if (Maincode.first == false)
            {
                if (IsAnti==true)
                {
                    Manager.SesCal.PlayOneShot(Manager.Sesler[14]);
                    GameObject NewBroke = Instantiate(BrokePar, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                    Destroy(NewBroke, 2f);
                    
                    for (int i = 0; i < Maincode.npcArray.Count; i++)
                    {
                        Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                    }
                }
                else
                {
                    FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[5]);
                    for (int i = 0; i < Maincode.npcArray.Count; i++)
                    {
                        Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                    }
                    Handheld.Vibrate();
                    if (SitNpc==false)
                    {
                        if (gameObject.GetComponent<NavMeshAgent>() != null && IsSurprise == false)
                        {
                            gameObject.GetComponent<Animator>().SetBool("Dizzy", true);
                            gameObject.GetComponent<NavMeshAgent>().speed = 0f;
                            gameObject.GetComponent<Animator>().SetBool("Walk", false);
                        }
                        else
                        {
                            gameObject.GetComponent<Animator>().SetBool("Carry", true);
                            gameObject.GetComponent<NavMeshAgent>().speed = 0f;
                        }
                    }

                    GameObject Yenipar = Instantiate(LovePar, gameObject.transform.position, Quaternion.identity);

                    LovePar.GetComponent<ParticleSystem>().Play(true);
                    Maincode.kontrol = false;
                    Vurulma = true;
                    //Maincode.istek = erkekArray[Random.Range(0, 3)];
                    Maincode.istek = Maincode.maleList[Random.Range(0, Maincode.maleList.Count)];
                    if (Maincode.istek == "Male1B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject a = Instantiate(Male1, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        a.transform.parent = gameObject.transform;
                        
                        Maincode.firstHit = gameObject;

                        //Vector3 newPos = new Vector3(a.transform.position.x, 3f, -3.3f);
                    }
                    else if (Maincode.istek == "Male2B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject b = Instantiate(Male2, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        b.transform.parent = gameObject.transform;
                        
                        Maincode.firstHit = gameObject;

                    }
                    else if (Maincode.istek == "Male3B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Male3, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Male4B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Male4, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Male5B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Male5, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Male6B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Male6, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Male7B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Male7, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Male8B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Male8, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Male9B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Male9, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        
                        Maincode.firstHit = gameObject;
                    }
                    //Debug.Log("İsteğim erkek = " + Maincode.istek);
                    Maincode.first = true;
                    //Debug.Log(Maincode.first);
                }

            }
            else
            {

                Debug.Log("ENTER");
                if (Maincode.istek == gameObject.name && IsAnti == false)
                {
                    Debug.Log(Maincode.firstHit.name);
                    if (Maincode.firstHit.transform.GetChild(4).gameObject != null)
                    {
                        if (Maincode.firstHit.GetComponent<npcMatch>().IsAnti ==true)
                        {
                            Manager.SesCal.PlayOneShot(Manager.Sesler[14]);
                            Maincode.kontrol = true;
                            GameObject NewBroke = Instantiate(BrokePar, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                            Destroy(NewBroke, 2f);
                            Destroy(Maincode.firstHit.transform.GetChild(4).gameObject);
                            Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", true);
                            Maincode.firstHit.GetComponent<Animator>().SetBool("Dizzy", false);
                            Destroy(GameObject.Find("Particle System(Clone)"));
                            for (int i = 0; i < Maincode.npcArray.Count; i++)
                            {
                                Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < Maincode.npcArray.Count; i++)
                            {
                                Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                            }
                            if ((IsSurprise == true || Maincode.firstHit.GetComponent<npcMatch>().IsSurprise == true)&&this.gameObject!=null)
                            {


                                if (Manager.ComplateKontrol==false&&Manager.FailedKontol==false)
                                {
                                    Maincode.firstHit.GetComponent<Animator>().SetBool("Carry", true);
                                    gameObject.GetComponent<Animator>().SetBool("Carry", true);
                                    surpriseCode.DrawSurprise();
                                }
                                
                            }
                            FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[6]);
                            Destroy(GameObject.Find("Particle System(Clone)"));
                            FindObjectOfType<GameManager>().Count++;
                            GameObject NewParMath = Instantiate(MatchPar, Parpoz.position, Quaternion.identity);
                            Destroy(NewParMath, 2f);
                            Destroy(Maincode.firstHit.transform.GetChild(3).gameObject);
                            //Kalp1.Play();
                            //Kalp2.Play();
                            //Maincode.firstHit.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Play();
                            //gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
                            //Invoke("Yoket",2f);
                            //StartCoroutine(Waiter());
                            Maincode.maleList.Remove(Maincode.maleList.Find(x => x == Maincode.firstHit.name));
                            Maincode.femList.Remove(Maincode.femList.Find(x => x == gameObject.name));
                            Maincode.npcArray.Remove(Maincode.npcArray.Find(x => x == Maincode.firstHit));
                            Maincode.npcArray.Remove(Maincode.npcArray.Find(x => x == gameObject));
                            Maincode.kontrol = true;
                            Debug.Log("==========FEMALE ARRAY===========");
                            for (int i = 0; i < Maincode.femList.Count; i++)
                            {
                                Debug.Log(Maincode.femList[i]);
                            }
                            Maincode.first = false;
                            if (gameObject.GetComponent<AIControl>()!=null&&Maincode.firstHit.GetComponent<AIControl>()!=null)
                            {
                                Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", false);
                                gameObject.GetComponent<Animator>().SetBool("Walk", false);
                                gameObject.GetComponent<AIControl>().Hız = 0;
                                gameObject.GetComponent<AIControl>().Bekleme = true;
                                Maincode.firstHit.GetComponent<AIControl>().Bekleme = true;
                                Maincode.firstHit.GetComponent<AIControl>().Hız = 0;
                            }
                            if (gameObject.GetComponent<AIControl>()!=null)
                            {
                                gameObject.GetComponent<Animator>().SetBool("Walk", false);
                                gameObject.GetComponent<AIControl>().Hız = 0;
                                gameObject.GetComponent<AIControl>().Bekleme = true;
                               // Maincode.firstHit.GetComponent<AIControl>().Bekleme = true;
                            }
                            if (Maincode.firstHit.GetComponent<AIControl>() != null)
                            {
                                // gameObject.GetComponent<AIControl>().Hız = 0;
                                // gameObject.GetComponent<AIControl>().Bekleme = true;
                                Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", false);
                                Maincode.firstHit.GetComponent<AIControl>().Bekleme = true;
                                Maincode.firstHit.GetComponent<AIControl>().Hız = 0;

                            }
                            Maincode.firstHit.GetComponent<CapsuleCollider>().enabled = false;
                            gameObject.GetComponent<CapsuleCollider>().enabled = false;
                            if (Maincode.firstHit.GetComponent<NavMeshAgent>() != null)
                            {
                                Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", false);
                                Destroy(Maincode.firstHit.GetComponent<NavMeshAgent>());

                            }
                            if (gameObject.GetComponent<NavMeshAgent>() != null)
                            {
                                gameObject.GetComponent<Animator>().SetBool("Walk", false);
                                Destroy(gameObject.GetComponent<NavMeshAgent>());
                            }
                            GameObject YeniPar = Instantiate(FindObjectOfType<GameManager>().NpsParticle, Maincode.firstHit.transform.position, Quaternion.Euler(-90, 0, 0));
                            GameObject YeniPar2 = Instantiate(FindObjectOfType<GameManager>().NpsParticle, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
                            Destroy(Maincode.firstHit, 1f);
                            Maincode.firstHit = null;
                            Destroy(gameObject, 1f);
                           // Destroy(Maincode.firstHit, 1f);
                            Destroy(YeniPar, 1f);
                            Destroy(YeniPar2, 1f);
                            
                           // Maincode.firstHit = null;
                           // Destroy(gameObject);
                            
                        }
                        
                    }
                    //else if (Maincode.firstHit.transform.GetChild(2).gameObject != null)
                    //{
                    //    Destroy(gameObject.transform.Find("Male2B"));
                    //}
                    //else if (gameObject.transform.Find("Male3B(Clone)") != null)
                    //{
                    //    Destroy(gameObject.transform.Find("Male3B"));
                    //}

                }
                else
                {
                    if (IsAnti == true)
                    {
                        Manager.SesCal.PlayOneShot(Manager.Sesler[14]);
                        GameObject NewBroke = Instantiate(BrokePar, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        Destroy(NewBroke, 2f);
                        Maincode.kontrol = true;
                        for (int i = 0; i < Maincode.npcArray.Count; i++)
                        {
                            Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                        }
                        Destroy(Maincode.firstHit.transform.GetChild(4).gameObject);
                        if (Maincode.firstHit.GetComponent<NavMeshAgent>() != null)
                        {
                            Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", true);
                            Maincode.firstHit.GetComponent<Animator>().SetBool("Dizzy", false);
                            Maincode.firstHit.GetComponent<NavMeshAgent>().speed = 2f;
                        }
                        Destroy(GameObject.Find("Particle System(Clone)"));
                        Maincode.firstHit.GetComponent<npcMatch>().Vurulma = false;
                        Maincode.firstHit = null;
                    }
                    else
                    {
                        FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[0]);
                        if (Maincode.firstHit.transform.GetChild(4).gameObject != null)
                        {
                            Maincode.kontrol = true;
                            Destroy(Maincode.firstHit.transform.GetChild(4).gameObject);
                            for (int i = 0; i < Maincode.npcArray.Count; i++)
                            {
                                Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                            }
                            //Sürpriz kutusu yok olması
                            if (SitNpc == false)
                            {
                                if (IsSurprise == true || Maincode.firstHit.GetComponent<npcMatch>().IsSurprise == true)
                                {
                                    if (gameObject.transform.Find("SurpriseBox(Clone)") != null)
                                    {
                                        gameObject.GetComponent<Animator>().SetBool("Carry", false);
                                        gameObject.GetComponent<Animator>().SetBool("WalkBox", false);

                                        Destroy(gameObject.transform.GetChild(3).transform.Find("SurpriseBox(Clone)").transform.gameObject);
                                    }
                                   

                                }

                            }

                            if (Maincode.firstHit.GetComponent<NavMeshAgent>() != null)
                            {
                                Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", true);
                                Maincode.firstHit.GetComponent<Animator>().SetBool("Dizzy", false);
                                Maincode.firstHit.GetComponent<NavMeshAgent>().speed = 2f;
                            }
                            Destroy(GameObject.Find("Particle System(Clone)"));
                            Maincode.firstHit.GetComponent<npcMatch>().Vurulma = false;
                            Maincode.firstHit = null;
                        }
                    }
                    //Debug.Log("YANLIŞ VURUŞ X");
                    
                }
                Maincode.first = false;
            }
            
        }


        else if (erkek == true)
        {
            if (Maincode.first == false )
            {
                if (IsAnti== true)
                {
                    Maincode.kontrol = true;
                    Manager.SesCal.PlayOneShot(Manager.Sesler[14]);
                    GameObject NewBroke = Instantiate(BrokePar, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                    Destroy(NewBroke, 2f);
                    
                    for (int i = 0; i < Maincode.npcArray.Count; i++)
                    {
                        Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                    }
                }
                else
                {
                    FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[5]);
                    for (int i = 0; i < Maincode.npcArray.Count; i++)
                    {
                        Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                    }
                    Handheld.Vibrate();
                    if (SitNpc == false)
                    {
                        if (gameObject.GetComponent<NavMeshAgent>() != null && IsSurprise == false)
                        {
                            gameObject.GetComponent<Animator>().SetBool("Dizzy", true);
                            gameObject.GetComponent<NavMeshAgent>().speed = 0f;
                            gameObject.GetComponent<Animator>().SetBool("Walk", false);
                        }
                        else
                        {
                            gameObject.GetComponent<Animator>().SetBool("Carry", true);
                            gameObject.GetComponent<NavMeshAgent>().speed = 0f;
                        }
                    }
                    GameObject Yenipar = Instantiate(LovePar, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);

                    Vurulma = true;
                    Maincode.kontrol = false;
                    //Maincode.istek = kadınArray[Random.Range(0, 3)];
                    Maincode.istek = Maincode.femList[Random.Range(0, Maincode.femList.Count)];
                    if (Maincode.istek == "Female1B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject a = Instantiate(Female1, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        a.transform.parent = gameObject.transform;
                        Maincode.firstHit = gameObject;
                        //Vector3 newPos = new Vector3(a.transform.position.x, 3f, -3.3f);
                    }
                    else if (Maincode.istek == "Female2B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject b = Instantiate(Female2, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        b.transform.parent = gameObject.transform;
                        Maincode.firstHit = gameObject;

                    }
                    else if (Maincode.istek == "Female3B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Female3, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Female4B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Female4, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Female5B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Female5, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Female6B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Female6, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Female7B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Female7, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Female8B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Female8, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        Maincode.firstHit = gameObject;
                    }
                    else if (Maincode.istek == "Female9B")
                    {
                        //GameObject bubble = GameObject.Find(Maincode.istek);
                        //Debug.Log(bubble.name);
                        //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
                        GameObject c = Instantiate(Female9, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        c.transform.parent = gameObject.transform;
                        Maincode.firstHit = gameObject;
                    }
                    //Debug.Log("İsteğim kadın = " + Maincode.istek);
                    Maincode.first = true;
                    //Debug.Log(Maincode.first);
                }

            }
            else
            {
                //Debug.Log("ENTER");
                if (Maincode.istek == gameObject.name&&IsAnti==false)
                {
                    //Debug.Log(Maincode.firstHit.name);
                    if(Maincode.firstHit.transform.GetChild(4).gameObject != null)
                    {
                        if (Maincode.firstHit.GetComponent<npcMatch>().IsAnti==true)
                        {
                            Manager.SesCal.PlayOneShot(Manager.Sesler[14]);
                            Maincode.kontrol = true;
                            GameObject NewBroke = Instantiate(BrokePar, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                            Destroy(NewBroke, 2f);
                            
                            Destroy(Maincode.firstHit.transform.GetChild(4).gameObject);
                            Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", true);
                            Maincode.firstHit.GetComponent<Animator>().SetBool("Dizzy", false);
                            Destroy(GameObject.Find("Particle System(Clone)"));
                            for (int i = 0; i < Maincode.npcArray.Count; i++)
                            {
                                Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            
                            for (int i = 0; i < Maincode.npcArray.Count; i++)
                            {
                                Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                            }
                            if ((IsSurprise == true || Maincode.firstHit.GetComponent<npcMatch>().IsSurprise == true) && this.gameObject != null)
                            {



                                if (Manager.ComplateKontrol == false && Manager.FailedKontol == false)
                                {
                                    Maincode.firstHit.GetComponent<Animator>().SetBool("Carry", true);
                                    gameObject.GetComponent<Animator>().SetBool("Carry", true);

                                    surpriseCode.DrawSurprise();
                                }
                            }
                            FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[6]);
                            Destroy(GameObject.Find("Particle System(Clone)"));
                            FindObjectOfType<GameManager>().Count++;
                            GameObject NewParMath = Instantiate(MatchPar, Parpoz.position, Quaternion.identity);
                            Destroy(NewParMath, 2f);
                            //Kalp1.Play();
                            //Kalp2.Play();
                            Destroy(Maincode.firstHit.transform.GetChild(3).gameObject);
                            //Maincode.firstHit.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Play();
                            //gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
                            //Invoke("Yoket",2f);
                            //StartCoroutine(Waiter());
                            Maincode.maleList.Remove(Maincode.maleList.Find(x => x == gameObject.name));
                            Maincode.femList.Remove(Maincode.femList.Find(x => x == Maincode.firstHit.name));
                            Maincode.npcArray.Remove(Maincode.npcArray.Find(x => x == gameObject));
                            Maincode.npcArray.Remove(Maincode.npcArray.Find(x => x == Maincode.firstHit));
                            Maincode.kontrol = true;
                            Debug.Log("==========MALE ARRAY===========");
                            for (int i = 0; i < Maincode.maleList.Count; i++)
                            {
                                Debug.Log(Maincode.maleList[i]);
                            }
                            
                            Maincode.first = false;
                            if (gameObject.GetComponent<AIControl>()!=null&&Maincode.firstHit.GetComponent<AIControl>()!=null)
                            {
                                gameObject.GetComponent<AIControl>().Hız = 0;
                                gameObject.GetComponent<AIControl>().Bekleme = true;
                                Maincode.firstHit.GetComponent<AIControl>().Bekleme = true;
                                Maincode.firstHit.GetComponent<AIControl>().Hız = 0;
                            }
                            if (gameObject.GetComponent<AIControl>() != null)
                            {
                                gameObject.GetComponent<AIControl>().Hız = 0;
                                gameObject.GetComponent<AIControl>().Bekleme = true;
                                //Maincode.firstHit.GetComponent<AIControl>().Bekleme = true;
                            }
                            if (Maincode.firstHit.GetComponent<AIControl>()!=null)
                            {
                               // gameObject.GetComponent<AIControl>().Hız = 0;
                               // gameObject.GetComponent<AIControl>().Bekleme = true;
                                Maincode.firstHit.GetComponent<AIControl>().Bekleme = true;
                                Maincode.firstHit.GetComponent<AIControl>().Hız = 0;

                            }
                            Maincode.firstHit.GetComponent<CapsuleCollider>().enabled = false;
                            gameObject.GetComponent<CapsuleCollider>().enabled = false;
                            if (Maincode.firstHit.GetComponent<NavMeshAgent>() != null)
                            {
                                Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", false);
                                Destroy(Maincode.firstHit.GetComponent<NavMeshAgent>());

                            }
                            if (gameObject.GetComponent<NavMeshAgent>() != null)
                            {
                                gameObject.GetComponent<Animator>().SetBool("Walk", false);
                                Destroy(gameObject.GetComponent<NavMeshAgent>());
                            }
                            GameObject YeniPar = Instantiate(FindObjectOfType<GameManager>().NpsParticle, Maincode.firstHit.transform.position, Quaternion.Euler(-90,0,0));
                            GameObject YeniPar2 = Instantiate(FindObjectOfType<GameManager>().NpsParticle, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
                            Destroy(Maincode.firstHit, 1f);
                            Maincode.firstHit = null;
                            
                            Destroy(YeniPar, 1f);
                            Destroy(YeniPar2, 1f);
                            Destroy(gameObject, 1f);
                            

                        }
                        
                    }
                    //else if (Maincode.firstHit.transform.GetChild(2).gameObject != null)
                    //{
                    //    Destroy(gameObject.transform.Find("Male2B"));
                    //}
                    //else if (gameObject.transform.Find("Male3B(Clone)") != null)
                    //{
                    //    Destroy(gameObject.transform.Find("Male3B"));
                    //}

                }
                else
                {
                    //Debug.Log("YANLIŞ VURUŞ X");
                    if (IsAnti == true)
                    {
                        Maincode.kontrol = true;
                        Manager.SesCal.PlayOneShot(Manager.Sesler[14]);
                        GameObject NewBroke = Instantiate(BrokePar, gameObject.transform.Find("bubbleSpawnPoint").transform.position, Quaternion.identity);
                        Destroy(NewBroke, 2f);
                        for (int i = 0; i < Maincode.npcArray.Count; i++)
                        {
                            Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                        }
                        Destroy(Maincode.firstHit.transform.GetChild(4).gameObject);//Bubble yok edilioyr
                        if (Maincode.firstHit.GetComponent<NavMeshAgent>() != null)
                        {
                            Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", true);
                            Maincode.firstHit.GetComponent<Animator>().SetBool("Dizzy", false);
                            Maincode.firstHit.GetComponent<NavMeshAgent>().speed = 2f;
                        }
                        Destroy(GameObject.Find("Particle System(Clone)"));
                        Maincode.firstHit.GetComponent<npcMatch>().Vurulma = false;
                        Maincode.firstHit = null;
                    }
                    else
                    {
                        FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[0]);
                        if (Maincode.firstHit.transform.GetChild(4).gameObject != null)
                        {
                            Maincode.kontrol = true;
                            Destroy(Maincode.firstHit.transform.GetChild(4).gameObject);
                            for (int i = 0; i < Maincode.npcArray.Count; i++)
                            {
                                Maincode.npcArray[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
                            }
                            //Sürpriz kutusu yok olması
                            if (SitNpc == false)
                            {
                                if (IsSurprise == true || Maincode.firstHit.GetComponent<npcMatch>().IsSurprise == true)
                                {
                                    if (gameObject.transform.Find("SurpriseBox(Clone)") != null)
                                    {
                                        gameObject.GetComponent<Animator>().SetBool("Carry", false);
                                        gameObject.GetComponent<Animator>().SetBool("WalkBox", false);

                                        Destroy(gameObject.transform.GetChild(3).transform.Find("SurpriseBox(Clone)").transform.gameObject);
                                    }
                                    

                                }
                            }
                            if (Maincode.firstHit.GetComponent<NavMeshAgent>() != null)
                            {
                                Maincode.firstHit.GetComponent<Animator>().SetBool("Walk", true);
                                Maincode.firstHit.GetComponent<Animator>().SetBool("Dizzy", false);
                                Maincode.firstHit.GetComponent<NavMeshAgent>().speed = 2f;
                            }


                            Destroy(GameObject.Find("Particle System(Clone)"));
                            Maincode.firstHit.GetComponent<npcMatch>().Vurulma = false;
                            Maincode.firstHit = null;
                        }
                    }

                    
                }
                Maincode.first = false;
            }
        }
        
    }
}
