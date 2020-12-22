using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrowTarget;
    public GameObject target;
    public GameObject arrowPrefab;
    public Transform shootPoint;
    GameManager Manager;
    public Animator Anim;
    public float Speed=200;
    
    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        Anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("arrowTarget");
        shootPoint = GameObject.Find("shootPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Speed);
        Deneme();

    }

    void Deneme()
    {
        if (Input.GetButton("Fire1"))
        {
            Anim.SetBool("Germe", true);
            //Speed = Speed + Time.deltaTime * 50f;
        }
        if (Input.GetButtonUp("Fire1"))
        {


            //Speed = 0f;
            Anim.SetBool("Germe", false);
        }
    }
   public void Shoot()
    {
        GameObject NewArrow= Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);
        //NewArrow.transform.LookAt(shootPoint.transform);
        NewArrow.transform.LookAt(target.transform.position);
        NewArrow.transform.position = Vector3.MoveTowards(NewArrow.transform.position, target.transform.position, 3f * Time.deltaTime);
        //NewArrow.transform.LookAt(new Vector3(target.transform.position.x,target.transform.position.y-Speed,target.transform.position.z-Speed));
        //NewArrow.transform.LookAt(new Vector3(target.transform.position.x,0f,target.transform.position.z));
        //Vector3 direction = (target.transform.position - NewArrow.transform.position).normalized;
        //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //NewArrow.transform.rotation = Quaternion.Slerp(NewArrow.transform.rotation, lookRotation, Time.deltaTime * 0.5f);
        //NewArrow.GetComponent<Rigidbody>().AddForce(target.transform.position - transform.position);
        //NewArrow.GetComponent<Rigidbody>().velocity = shootPoint.forward;
        //NewArrow.GetComponent<Rigidbody>().velocity = new Vector3(shootPoint.forward.x, 0f, shootPoint.forward.z) * Speed;
        NewArrow.GetComponent<Rigidbody>().velocity = NewArrow.transform.forward * Speed;
        if (FindObjectOfType<Surprise>().AntiArrow==false)
        {
            FindObjectOfType<GameManager>().Arrow--;
        }
        //Debug.Log("Shoooot");
        
        Manager.SesCal.PlayOneShot(Manager.Sesler[1]);
        //Look at yanlış onu düzelt onun dışında dümdüz gidiyor ok
    }
}
