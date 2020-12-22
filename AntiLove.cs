using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiLove : MonoBehaviour
{
    // Start is called before the first frame update
    //public Main MainCode;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Kaya"))
        {
            Debug.Log("ANTIIILOVE");
            other.gameObject.GetComponent<npcMatch>().IsAnti = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.tag == "Kaya")
         {
             other.gameObject.GetComponent<npcMatch>().IsAnti = false; 
           }
       // foreach (var a in other)
       // {
           // a.gameObject.GetComponent<npcMatch>().IsAnti = false;
        //}
    }
}
