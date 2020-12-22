using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poz : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kaya"))
        {

            //Debug.Log("Poz Çakıştı");
            other.gameObject.GetComponent<AIControl>().PozKontrol = true;
            other.gameObject.GetComponent<AIControl>().Bekleme = true;
        }
        if (other.CompareTag("Anti"))
        {

            //Debug.Log("Poz Çakıştı");
            other.gameObject.GetComponent<AIControl>().PozKontrol = true;
            other.gameObject.GetComponent<AIControl>().Bekleme = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
