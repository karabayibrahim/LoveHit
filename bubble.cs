using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{

    public GameObject cam;
    private Vector3 c;
    
    // Start is called before the first frame update
    void Start()
    {
        //c = new Vector3(59f, 59f, 0);
    
        //gameObject.transform.rotation = Quaternion.Euler(c);
        //gameObject.transform.LookAt(cam.transform);
    }

    // Update is called once per frame
    void Update()
    {
        c = new Vector3(59f, 59f, 0);

        gameObject.transform.rotation = Quaternion.Euler(c);
    }
}
