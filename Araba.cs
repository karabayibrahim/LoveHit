using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Araba : MonoBehaviour
{
    public float Hız;
    int Levelİndex;
    // Start is called before the first frame update
    void Start()
    {
        Levelİndex = SceneManager.GetActiveScene().buildIndex;

    }
    // Update is called once per frame
    void Update()
    {


        if (Levelİndex==4||Levelİndex==5||Levelİndex==7||Levelİndex==9||Levelİndex==8||Levelİndex==11||Levelİndex==12||Levelİndex==30)
        {
            transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * Hız;
        }
        if (Levelİndex==3||Levelİndex==2||Levelİndex==10||Levelİndex==31 )
        {
            transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * Hız;
        }
        if (Levelİndex == 28)
        {
            transform.position += new Vector3(0f, 0f, -1f) * Time.deltaTime * Hız;
        }
        
        
    }
}
