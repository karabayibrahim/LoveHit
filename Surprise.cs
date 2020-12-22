using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Surprise : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] surpriseArray = { "npcSpeedUp", "npcSpeedDown", "npcStop","AntiArrow" };
    private string drawed;
    public Main Maincode;
    public bool Supriz = false;
    public bool AntiArrow = false;
    public float Bekleme = 5f;
    public GameObject slowImage;
    public GameObject superImage;
    public GameObject freezeImage;
    public GameObject slowedCntTxt;
    public GameObject freezeCntTxt;
    public GameObject AntiCntTxt;
    public GameObject effectBar;
    public GameObject efctSlow;
    public GameObject efctAnti;
    public GameObject efctFreeze;
    public GameObject efctFast;
    public GameObject efctTimeBar;
    public GameObject AntiEros;
    public GameObject YavaslamaParticle;
    public GameObject DonmaParticle;
    public GameObject HızlanmaParticle;
    public bool OzellikKontrol = false;
    bool AntiKontrol = false;
    GameManager Manager;
    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        AntiEros = GameObject.FindGameObjectWithTag("Anti");
        Maincode = FindObjectOfType<Main>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCounts();
        if (GameObject.FindGameObjectWithTag("Anti")==true)
        {
            AntiKontrol = true;
        }
        else
        {
            AntiKontrol = false;
        }

        if (Maincode.slowhappened == true)
        {
            Cooldown();
            effectBar.SetActive(true);
            efctSlow.SetActive(true);
            if (slowImage.GetComponent<Image>().fillAmount == 1f)
            {
                OzellikKontrol = false;
                Manager.SesCal.PlayOneShot(Manager.Sesler[9]);
                effectBar.SetActive(false);
                efctSlow.SetActive(false);
                efctTimeBar.GetComponent<Image>().fillAmount = 1f;
                Maincode.slowhappened = false;
                for (int i = 0; i < Maincode.npcArray.Count; i++)
                {
                    if (Maincode.npcArray[i].GetComponent<NavMeshAgent>() != null)
                    {
                        //Maincode.npcArray[i].GetComponent<NavMeshAgent>().speed *= 2f;
                        Maincode.npcArray[i].GetComponent<AIControl>().Hız = 2;
                    }
                }
            }
        }
        if (Maincode.antihappened == true)
        {
            Cooldown();
            effectBar.SetActive(true);
            efctAnti.SetActive(true);
            if (superImage.GetComponent<Image>().fillAmount == 1f)
            {
                OzellikKontrol = false;
                Manager.SesCal.PlayOneShot(Manager.Sesler[12]);
                effectBar.SetActive(false);
                efctAnti.SetActive(false);
                efctTimeBar.GetComponent<Image>().fillAmount = 1f;
                Maincode.antihappened = false;
                AntiArrow = false;
            }
        }

        if (Maincode.freezehappened == true)
        {

            Cooldown();
            effectBar.SetActive(true);
            efctFreeze.SetActive(true);
            if (freezeImage.GetComponent<Image>().fillAmount == 1f)
            {
                OzellikKontrol = false;
                Manager.SesCal.PlayOneShot(Manager.Sesler[10]);
                effectBar.SetActive(false);
                efctFreeze.SetActive(false);
                efctTimeBar.GetComponent<Image>().fillAmount = 1f;
                Maincode.freezehappened = false;
                for (int i = 0; i < Maincode.npcArray.Count; i++)
                {
                    if (Maincode.npcArray[i].GetComponent<NavMeshAgent>() != null)
                    {
                        // Maincode.npcArray[i].GetComponent<NavMeshAgent>().speed += 2f;
                        Maincode.npcArray[i].GetComponent<AIControl>().Hız = 2;
                    }
                }
            }
        }
        //if (gameObject.transform.Find("SurpriseBox") != null)
        //{
        //    Debug.Log("SURPRISE found");
        if (AntiEros==null)
        {
            for (int i = 0; i < Maincode.npcArray.Count; i++)
            {
                Maincode.npcArray[i].GetComponent<npcMatch>().IsAnti = false;
            }
        }

        //}
        //Debug.Log(Bekleme);
        if (Supriz)
        {
            slowImage.SetActive(false);
            freezeImage.SetActive(false);
            superImage.SetActive(false);
            efctTimeBar.GetComponent<Image>().fillAmount -= 1 / 5f * Time.deltaTime;
            Bekleme -= Time.deltaTime;
            if (Bekleme <= 0f&&Manager.ComplateKontrol==false&&Manager.FailedKontol==false)
            {
                slowImage.SetActive(true);
                freezeImage.SetActive(true);
                superImage.SetActive(true);
                for (int i = 0; i < Maincode.npcArray.Count; i++)
                {
                    if (Maincode.npcArray[i].GetComponent<NavMeshAgent>() != null)
                    {
                        Maincode.npcArray[i].GetComponent<AIControl>().Bekleme = false;
                        if (Maincode.npcArray[i]!=null)
                        {
                            Maincode.npcArray[i].GetComponent<NavMeshAgent>().speed = FindObjectOfType<AIControl>().Hız;
                        }


                    }

                }
                
                efctTimeBar.GetComponent<Image>().fillAmount = 1f;
                Supriz = false;
                Bekleme = 5f;
                AntiArrow = false;
                effectBar.SetActive(false);
                efctSlow.SetActive(false);
                efctFreeze.SetActive(false);
                efctAnti.SetActive(false);
                efctFast.SetActive(false);
                if (efctSlow.activeSelf==false)
                {
                    Manager.SesCal.PlayOneShot(Manager.Sesler[9]);
                }
                if (efctFast.activeSelf==false)
                {
                    Manager.SesCal.PlayOneShot(Manager.Sesler[8]);
                }
                if (efctFreeze.activeSelf==false)
                {
                    Manager.SesCal.PlayOneShot(Manager.Sesler[10]);
                }
                if (efctAnti.activeSelf==false)
                {
                    Manager.SesCal.PlayOneShot(Manager.Sesler[12]);
                }

            }
        }
    }

    public void DrawSurprise()
    {
        if (Manager.ComplateKontrol!=true)
        {
            if (!OzellikKontrol)
            {
                Supriz = true;
                Debug.Log("gİRDİM");
                if (AntiKontrol==false)
                {
                    drawed = surpriseArray[Random.Range(0, surpriseArray.Length)];
                    if (drawed=="AntiArrow")
                    {
                        while (true)
                        {
                            drawed = surpriseArray[Random.Range(0, surpriseArray.Length)];
                            if (drawed!="AntiArrow")
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    drawed = surpriseArray[Random.Range(0, surpriseArray.Length)];
                }
                
                if (drawed == "npcSpeedUp")
                {
                    Manager.SesCal.PlayOneShot(Manager.Sesler[9]);
                    effectBar.SetActive(true);
                    efctFast.SetActive(true);
                    Debug.Log("npcSpeedUp");
                    if (Supriz)
                    {
                        for (int i = 0; i < Maincode.npcArray.Count; i++)
                        {
                            if (Maincode.npcArray[i].GetComponent<NavMeshAgent>() != null)
                            {
                                GameObject Yenipar = Instantiate(HızlanmaParticle, Maincode.npcArray[i].gameObject.transform.GetChild(3).transform.position, Quaternion.identity);
                                Maincode.npcArray[i].GetComponent<NavMeshAgent>().speed = FindObjectOfType<AIControl>().Hız * 2f;
                                Destroy(Yenipar, 2f);

                            }

                        }
                    }

                }
                else if (drawed == "npcSpeedDown")
                {
                    Manager.SesCal.PlayOneShot(Manager.Sesler[8]);
                    effectBar.SetActive(true);
                    efctSlow.SetActive(true);

                    // Bekleme -= Time.deltaTime;
                    Debug.Log("npcSpeedDown");
                    if (Supriz)
                    {
                        for (int i = 0; i < Maincode.npcArray.Count; i++)
                        {
                            if (Maincode.npcArray[i].GetComponent<NavMeshAgent>() != null)
                            {
                                GameObject Yenipar = Instantiate(YavaslamaParticle, Maincode.npcArray[i].gameObject.transform.GetChild(3).transform.position, Quaternion.identity);
                                Maincode.npcArray[i].GetComponent<NavMeshAgent>().speed = FindObjectOfType<AIControl>().Hız / 2f;
                                Destroy(Yenipar, 2f);
                            }

                        }
                    }

                }
                else if (drawed == "npcStop")
                {
                    Manager.SesCal.PlayOneShot(Manager.Sesler[7]);
                    effectBar.SetActive(true);
                    efctFreeze.SetActive(true);

                    // Bekleme -= Time.deltaTime;
                    Debug.Log("npcStop");
                    if (Supriz)
                    {
                        for (int i = 0; i < Maincode.npcArray.Count; i++)
                        {

                            //Maincode.npcArray[i].GetComponent<NavMeshAgent>().enabled = false;
                            //Maincode.npcArray[i].GetComponent<AIControl>().enabled = false;

                            //Maincode.npcArray[i].GetComponent<AIControl>().Bekleme = true;
                            Maincode.npcArray[i].GetComponent<Animator>().SetBool("Walk", false);

                            if (Maincode.npcArray[i].GetComponent<NavMeshAgent>() != null)
                            {
                                GameObject Yenipar = Instantiate(DonmaParticle, Maincode.npcArray[i].gameObject.transform.GetChild(3).transform.position, Quaternion.identity);
                                Maincode.npcArray[i].GetComponent<NavMeshAgent>().speed = 0;
                                Destroy(Yenipar, 2f);
                            }




                        }
                    }

                }
                else if (drawed == "AntiArrow")
                {
                    Manager.SesCal.PlayOneShot(Manager.Sesler[11]);
                    effectBar.SetActive(true);
                    efctAnti.SetActive(true);

                    //Bekleme -= Time.deltaTime;
                    AntiArrow = true;

                    Debug.Log("Anti Aktif");
                }
            }
        }
       
    }
    public void AntiAr()
    {
        if (Maincode.powerUpCount_anti>0)
        {
            OzellikKontrol = true;
            
            
            if (Maincode.antihappened != true && Maincode.freezehappened != true && Maincode.slowhappened != true)
            {
                AntiArrow = true;
                Manager.SesCal.PlayOneShot(Manager.Sesler[11]);
                Maincode.antihappened = true;
                slowImage.GetComponent<Image>().fillAmount = 0;
                superImage.GetComponent<Image>().fillAmount = 0;
                freezeImage.GetComponent<Image>().fillAmount = 0;
                Maincode.powerUpCount_anti--;
            }
            
            PlayerPrefs.SetInt("SavePowerAnti", Maincode.powerUpCount_anti);
        }

        Debug.Log("Anti Aktif");
    }
    public void SlowDown()
    {
        
        Debug.Log("YAVAAAAAAAAAAAAAŞ");
        if (Maincode.powerUpCount_slowed>0)
        {
            OzellikKontrol = true;
            
            if (Maincode.slowhappened != true && Maincode.freezehappened != true && Maincode.antihappened != true)
            {
                Manager.SesCal.PlayOneShot(Manager.Sesler[8]);
                for (int i = 0; i < Maincode.npcArray.Count; i++)
                {
                    if (Maincode.npcArray[i].GetComponent<NavMeshAgent>() != null)
                    {
                        GameObject Yenipar = Instantiate(YavaslamaParticle, Maincode.npcArray[i].gameObject.transform.GetChild(3).transform.position, Quaternion.identity);
                        //Maincode.npcArray[i].GetComponent<NavMeshAgent>().speed /= 2f;
                        Maincode.npcArray[i].GetComponent<AIControl>().Hız /= 2;
                        Maincode.slowhappened = true;
                        slowImage.GetComponent<Image>().fillAmount = 0;
                        superImage.GetComponent<Image>().fillAmount = 0;
                        freezeImage.GetComponent<Image>().fillAmount = 0;
                        Destroy(Yenipar, 2f);
                    }
                }
                Maincode.powerUpCount_slowed -= 1;
                PlayerPrefs.SetInt("SavePowerYavas",Maincode.powerUpCount_slowed);
                
            }
        }

    }
    
    public void Freeze()
    {
        
        Debug.Log("Donmaaaaaa");
        if (Maincode.powerUpCount_freeze>0)
        {
            OzellikKontrol = true;
            
            if (Maincode.freezehappened != true && Maincode.slowhappened != true && Maincode.antihappened != true)
            {
                Manager.SesCal.PlayOneShot(Manager.Sesler[7]);
                for (int i = 0; i < Maincode.npcArray.Count; i++)
                {
                    if (Maincode.npcArray[i].GetComponent<NavMeshAgent>() != null)
                    {
                        GameObject Yenipar = Instantiate(DonmaParticle, Maincode.npcArray[i].gameObject.transform.GetChild(3).transform.position, Quaternion.identity);
                        //Maincode.npcArray[i].GetComponent<NavMeshAgent>().speed = 0f;
                        Maincode.npcArray[i].GetComponent<AIControl>().Bekleme = true;
                        //Maincode.npcArray[i].GetComponent<Animator>().SetBool("Walk", false);
                        Maincode.npcArray[i].GetComponent<AIControl>().Hız = 0;
                        Maincode.freezehappened = true;
                        slowImage.GetComponent<Image>().fillAmount = 0;
                        superImage.GetComponent<Image>().fillAmount = 0;
                        freezeImage.GetComponent<Image>().fillAmount = 0;
                        Destroy(Yenipar, 2f);
                    }
                }
                Maincode.powerUpCount_freeze -= 1;
                PlayerPrefs.SetInt("SavePowerDonma",Maincode.powerUpCount_freeze);
            }
        }
    }
    public void Cooldown()
    {
        slowImage.GetComponent<Image>().fillAmount += 1 / 5f * Time.deltaTime;
        superImage.GetComponent<Image>().fillAmount += 1 / 5f * Time.deltaTime;
        freezeImage.GetComponent<Image>().fillAmount += 1 / 5f * Time.deltaTime;
        efctTimeBar.GetComponent<Image>().fillAmount -= 1 / 5f * Time.deltaTime;

    }
    public void DisplayCounts()
    {
        slowedCntTxt.GetComponent<Text>().text = Maincode.powerUpCount_slowed.ToString();
        freezeCntTxt.GetComponent<Text>().text = Maincode.powerUpCount_freeze.ToString();
        AntiCntTxt.GetComponent<Text>().text = Maincode.powerUpCount_anti.ToString();

    }
}
