
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform[] Pozlar;
    public Animator Anim;
    public GameObject Move;
    public bool PozKontrol = false;
    public bool Bekleme = false;
    float BeklemeSüre = 5f;
    public int Sec;
    public int Secilen;
    public int Hız = 2;
    private Surprise surpriseCode;
    


    void Start()
    {
        
        Move = GameObject.Find("MoveTargets");
        surpriseCode = FindObjectOfType<Surprise>();

        Anim = GetComponent<Animator>();
        PozKontrol = true;
        Agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Pozlar" + Pozlar.Length);
        if (Bekleme&&gameObject.GetComponent<NavMeshAgent>()!=null)
        {
            if (gameObject.GetComponent<npcMatch>().SitNpc==false)
            {
                if (gameObject.GetComponent<npcMatch>().IsSurprise == true)
                {
                    if (surpriseCode.Supriz == false)
                    {
                        gameObject.GetComponent<NavMeshAgent>().speed = 0f;
                        Anim.SetBool("Walk", false);
                        Anim.SetBool("Carry", true);
                        BeklemeSüre -= Time.deltaTime;
                    }
                   
                }
                else
                {
                    gameObject.GetComponent<NavMeshAgent>().speed = 0f;
                    Anim.SetBool("Walk", false);
                    //gameObject.GetComponent<NavMeshAgent>().speed = 0f;
                    BeklemeSüre -= Time.deltaTime;
                }

                if (BeklemeSüre <= 0)
                {
                    BeklemeSüre = 5f;
                    Bekleme = false;
                }
            }
        }
        PozFind();
        PozSecim();
        Secme();
    }
    void Secme()
    {
        if (PozKontrol&&!Bekleme)
        {
            Sec = Random.Range(1, Pozlar.Length+1);
            PozKontrol = false;
            while (Sec == Secilen)
            {
                Sec = Random.Range(1, Pozlar.Length+1);
                if (Sec != Secilen)
                {
                    break;
                }
            }
        }
        
    }
   public void PozSecim()
    {
        
        
       

        if ((Sec==1&&!Bekleme && gameObject.GetComponent<npcMatch>().Vurulma==false) && surpriseCode.Supriz == false)
        {
            Secilen = Sec;
            if (gameObject.GetComponent<npcMatch>().SitNpc == false)
            {
                if (gameObject.GetComponent<npcMatch>().IsSurprise == false)
                {
                    if (surpriseCode.Supriz == false)
                    {
                        gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                        Anim.SetBool("Walk", true);
                    }
                    
                }
                else
                {
                    gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                    Anim.SetBool("Carry", false);

                }
            }
            //gameObject.GetComponent<NavMeshAgent>().speed = 2f;
            if (Agent != null)
            {
                Agent.SetDestination(Pozlar[0].transform.position);
            }



        }
        if ((Sec == 2 && !Bekleme && gameObject.GetComponent<npcMatch>().Vurulma == false) && surpriseCode.Supriz == false)
        {
            Secilen = Sec;
            if (gameObject.GetComponent<npcMatch>().SitNpc == false)
            {
                if (gameObject.GetComponent<npcMatch>().IsSurprise == false)
                {
                    if (surpriseCode.Supriz == false)
                    {
                        gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                        Anim.SetBool("Walk", true);
                    }
                }
                else
                {
                    gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                    Anim.SetBool("Carry", false);
                }
            }

            //gameObject.GetComponent<NavMeshAgent>().speed = 2f;
            if (Agent != null)
            {
                Agent.SetDestination(Pozlar[1].transform.position);
            }



        }
        if ((Sec == 3 && !Bekleme && gameObject.GetComponent<npcMatch>().Vurulma == false) && surpriseCode.Supriz == false)
        {
            Secilen = Sec;
            if (gameObject.GetComponent<npcMatch>().SitNpc == false)
            {
                if (gameObject.GetComponent<npcMatch>().IsSurprise == false)
                {
                    if (surpriseCode.Supriz == false)
                    {
                        gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                        Anim.SetBool("Walk", true);
                    }
                }
                else
                {
                    gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                    Anim.SetBool("Carry", false);
                }
            }
            //gameObject.GetComponent<NavMeshAgent>().speed = 2f;
            if (Agent!=null)
            {
                Agent.SetDestination(Pozlar[2].transform.position);
            }
            
            
            
        }
        if ((Sec == 4 && !Bekleme && gameObject.GetComponent<npcMatch>().Vurulma == false) && surpriseCode.Supriz == false)
        {
            Secilen = Sec;
            if (gameObject.GetComponent<npcMatch>().SitNpc == false)
            {
                if (gameObject.GetComponent<npcMatch>().IsSurprise == false)
                {
                    if (surpriseCode.Supriz == false)
                    {
                        gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                        Anim.SetBool("Walk", true);
                    }
                }
                else
                {
                    gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                    Anim.SetBool("Carry", false);
                }
            }
            //gameObject.GetComponent<NavMeshAgent>().speed = 2f;
            if (Agent != null)
            {
                Agent.SetDestination(Pozlar[3].transform.position);
            }



        }
        if ((Sec == 5 && !Bekleme && gameObject.GetComponent<npcMatch>().Vurulma == false) && surpriseCode.Supriz == false)
        {
            Secilen = Sec;
            if (gameObject.GetComponent<npcMatch>().SitNpc==false)
            {
                if (gameObject.GetComponent<npcMatch>().IsSurprise == false)
                {
                    if (surpriseCode.Supriz == false)
                    {
                        gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                        Anim.SetBool("Walk", true);
                    }
                }
                else
                {
                    gameObject.GetComponent<NavMeshAgent>().speed = Hız;
                    Anim.SetBool("Carry", false);
                }
            }
            //gameObject.GetComponent<NavMeshAgent>().speed = 2f;
            if (Agent != null)
            {
                Agent.SetDestination(Pozlar[4].transform.position);
            }



        }

    }
    void PozFind()
    {

        for (int i = 0; i <Pozlar.Length ; i++)
        {
            Pozlar[i] = Move.transform.GetChild(i).gameObject.transform;

        }
    }
}
