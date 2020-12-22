using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mdidle : MonoBehaviour
{
    //public LinkedList<GameObject> PlayersSkins = new LinkedList<GameObject>();
    public List<GameObject> PlayersSkins = new List<GameObject>();
    int sayac = 0;
    bool first = true;
    public GameObject NextButton;
    public GameObject BackButton;
    // Start is called before the first frame update
    void Start()
    {
        if (first)
        {
            BackButton.SetActive(false);
            PlayersSkins[sayac].gameObject.SetActive(true);
            PlayersSkins[sayac + 1].gameObject.SetActive(false);
            first = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sayac);
    }
    
    public void Next()
    {
        BackButton.SetActive(true);
        sayac++;
        if (sayac==3)
        {
            NextButton.SetActive(false);
            PlayersSkins[sayac].gameObject.SetActive(true);
            PlayersSkins[sayac - 1].gameObject.SetActive(false);
        }
        
        else
        {
            PlayersSkins[sayac].gameObject.SetActive(true);
            PlayersSkins[sayac - 1].gameObject.SetActive(false);

            NextButton.SetActive(true);
        }
        

    }
    
    public void Back()
    {
        NextButton.SetActive(true);
        sayac--;
        if (sayac == 0)
        {
            BackButton.SetActive(false);
            PlayersSkins[sayac].gameObject.SetActive(true);
            PlayersSkins[sayac + 1].gameObject.SetActive(false);
        }
        else
        {
            PlayersSkins[sayac].gameObject.SetActive(true);
            PlayersSkins[sayac + 1].gameObject.SetActive(false);

            BackButton.SetActive(true);
        }

    }
}
