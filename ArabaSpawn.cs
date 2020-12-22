using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabaSpawn : MonoBehaviour
{
    public GameObject Araba;
    public bool Basla;
    public float Rast;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ArabaUret();
    }
   public void ArabaUret()
    {
        
        if (Basla)
        {
            
            Rast -= Time.deltaTime;
            //Debug.Log(Rast);
            if (Rast <= 0)
            {
                Instantiate(Araba, transform.position, transform.rotation);
                Basla = false;
            }
        }
        
    }
}
