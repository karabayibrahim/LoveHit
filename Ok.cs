using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ok : MonoBehaviour
{
    // Start is called before the first frame update
    private npcMatch code;

    public GameObject bubble;
    public Transform pos;
    public GameObject Target;
    public GameObject AntiYokParticle;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Vurdun");
        
        if (other.gameObject.tag == "Kaya")
        {
            code = other.gameObject.GetComponent<npcMatch>();
            //Target.transform.position = new Vector3(0f, 0f, 0f);
            //pos = other.gameObject.transform;
            code.Istek();

            //FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[0]);
           // FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[5]);

            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Anti"&&FindObjectOfType<Surprise>().AntiArrow==true)
        {
            // FindObjectOfType<Main>().antihappened = false;
            //FindObjectOfType<Surprise>().effectBar.SetActive(false);
            // FindObjectOfType<Surprise>().efctAnti.SetActive(false);
            FindObjectOfType<GameManager>().SesCal.PlayOneShot(FindObjectOfType<GameManager>().Sesler[13]);
            GameObject Yenipar= Instantiate(AntiYokParticle, gameObject.transform.position,Quaternion.Euler(90,0,0) );
            Destroy(other.gameObject);
            Destroy(Yenipar, 2f);
            FindObjectOfType<Surprise>().AntiArrow = false;
            //FindObjectOfType<Surprise>().Maincode.antihappened = true;


        }
        
    }
    void Start()
    {
        YokOl();
        Target = GameObject.Find("Target");
    }
    void YokOl()
    {
        Destroy(gameObject, 2f);
    }
    // Update is called once per frame
    
}
