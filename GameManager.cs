using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int PlayerCoin;
    public int Count;
    public int Arrow;
    public int LevelTargetCount;
    public int LevelTargetArrow;
    public Text TextC;
    public Text TextArrow;
    public Text TextC2;
    GameObject Complete;
    GameObject FailedObje;
    public int LovePoint;
    public RawImage Countİmage;
    public float WaitTime;
    public Image Fill;
    int Skinİndex;
    public List<GameObject> Players = new List<GameObject>();
    public Transform SpawnPoint;
    public GameObject NpsParticle;
    Main MainCode;
    public List<AudioClip> Sesler = new List<AudioClip>();
    public AudioSource SesCal;
    int sayac = 0;
    public bool ComplateKontrol = false;
    public bool FailedKontol = false;
    GameObject Ses;
    Surprise Sup;
    GameObject Pause;
    public float İlkZaman;
    public int YıldızKalp;
    public GameObject Yıldız1;
    public GameObject Yıldız2;
    public GameObject Yıldız3;
    GameObject LovePointDimbo;
    public int sayac1 = 0;
    public int sayac2 = 0;
    public int sayac3 = 0;
    public int sayac4 = 0;
    public int sayac5 = 0;
    int Levelİndex;
    int İlkKalp;
    int buildIndex = 0;
    AudioSource TikTok;
    float TikTokTime = 0f;
    int Tiktoksayac = 0;
    
    private void Awake()
    {

        
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        Skinİndex = PlayerPrefs.GetInt("SaveSkinİndex");
        SkinSpawn();
        Debug.Log("sKİNiNDEX"+Skinİndex);
    }
    void Start()
    {
        Debug.Log("iLK"+İlkKalp);
        TikTokTime = WaitTime;
        TikTok = GameObject.FindGameObjectWithTag("TikTok").GetComponent<AudioSource>();
        
        İlkKalp = PlayerPrefs.GetInt(Levelİndex.ToString());
        Levelİndex = SceneManager.GetActiveScene().buildIndex;
        PlayerCoin = PlayerPrefs.GetInt("SaveCoin");
        İlkZaman = WaitTime;
        Pause = GameObject.Find("Pause");
        Sup = FindObjectOfType<Surprise>();
        Ses = GameObject.Find("Players");
        SesCal = GetComponent<AudioSource>();
        MainCode = FindObjectOfType<Main>();
        SpawnPoint = GameObject.Find("SpawnPoint").transform;
        //Application.targetFrameRate = 60;
        Complete = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        FailedObje = GameObject.Find("Canvas").transform.GetChild(8).gameObject;
        Arrow = LevelTargetArrow;
        TextC = GameObject.Find("CountText").GetComponent<Text>();
        TextArrow = GameObject.Find("TextArrow").GetComponent<Text>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        İlkKalp = PlayerPrefs.GetInt(Levelİndex.ToString());
        Debug.Log("yILZIKALP" + YıldızKalp);
        Debug.Log("İlk Kalp" + İlkKalp);
        TikTokTime -= Time.deltaTime;
        if (TikTokTime<=4)
        {
            Tiktoksayac++;
            if (Tiktoksayac==1&&ComplateKontrol==false&&FailedKontol==false)
            {
                TikTok.Play();
                TikTokTime = 0;
            }
            
            
        }
        if (!ComplateKontrol&&!FailedKontol)
        {
            Fill.fillAmount -= 1.0f / WaitTime * Time.deltaTime;
        }
        
        
        TextCount();
        LevelKontrol();
        Failed();
    }
    void TextCount()
    {
        TextC.text = Count.ToString() + "/" + LevelTargetCount.ToString();
        TextC2.text = Count.ToString() + "/" + LevelTargetCount.ToString();
        TextArrow.text = Arrow.ToString() + "/" + LevelTargetArrow.ToString();

    }
    public void NextLevel()
    {

        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if (buildIndex > saveIndex)
        {
            PlayerPrefs.SetInt("SaveIndex", buildIndex);
        }
        if (buildIndex == 21)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(buildIndex + 1);
        }


    }
    void LevelKontrol()
    {
        if (Count==LevelTargetCount&&ComplateKontrol==false)
        {
            TikTok.Stop();
            
            LovePointDimbo = Complete.transform.GetChild(8).gameObject;
            Yıldız1 = Complete.transform.GetChild(2).gameObject;
            Yıldız2 = Complete.transform.GetChild(3).gameObject;
            Yıldız3 = Complete.transform.GetChild(4).gameObject;
            LovePointDimbo = Complete.transform.GetChild(8).gameObject;
            if (Arrow >= 2 && Fill.fillAmount>=0.5f)
            {
                
                YıldızKalp = 3;
                Yıldız1.SetActive(true);
                Yıldız2.SetActive(true);
                Yıldız3.SetActive(true);
                PlayerPrefs.SetInt(Levelİndex.ToString(), YıldızKalp);

                //PlayerPrefs.SetInt("SaveHal2Yılız",YıldızKalp);
            }
            else if (Arrow<=2&&Fill.fillAmount>=0.25 )
            {
                
                YıldızKalp = 2;
                Yıldız1.SetActive(true);
                Yıldız2.SetActive(true);
                Yıldız3.SetActive(false);
                PlayerPrefs.SetInt(Levelİndex.ToString(), YıldızKalp);
                //PlayerPrefs.SetInt("SaveHal2Yılız", YıldızKalp);

            }
            else if (Arrow<=2&&Fill.fillAmount<=0.25f )
            {
                
                YıldızKalp = 1;
                Yıldız1.SetActive(true);
                Yıldız2.SetActive(false);
                Yıldız3.SetActive(false);
                PlayerPrefs.SetInt(Levelİndex.ToString(), YıldızKalp);
                // PlayerPrefs.SetInt("SaveHal2Yılız", YıldızKalp);

            }


            
            Pause.SetActive(false);
            Sup.slowImage.SetActive(false);
            Sup.superImage.SetActive(false);
            Sup.freezeImage.SetActive(false);
            Ses.GetComponent<AudioSource>().Stop();
            ComplateKontrol = true;
            sayac++;
            if (sayac==1)
            {
                
                SesCal.PlayOneShot(Sesler[4]);
                if ((YıldızKalp==3&&YıldızKalp==3)||(YıldızKalp==2&İlkKalp==2)||(YıldızKalp==1&&İlkKalp==1))
                {
                    
                    LovePointDimbo.GetComponent<Text>().text = "0";
                }
               if (YıldızKalp == 3 && İlkKalp <= 2)
                {
                    Debug.Log("a");
                    PlayerCoin += 300;
                    PlayerPrefs.SetInt("SaveCoin", PlayerCoin);
                    LovePointDimbo.GetComponent<Text>().text = "300";

                }
                else if (YıldızKalp == 2 && İlkKalp <= 1 )
                {
                    Debug.Log("b");
                    PlayerCoin += 150;
                    PlayerPrefs.SetInt("SaveCoin", PlayerCoin);
                    LovePointDimbo.GetComponent<Text>().text = "150";
                }
                else if (YıldızKalp == 1 && İlkKalp == 0 )
                {
                    Debug.Log("c");
                    PlayerCoin += 50;
                    PlayerPrefs.SetInt("SaveCoin", PlayerCoin);
                    LovePointDimbo.GetComponent<Text>().text = "50";
                }

            }
            

            Complete.SetActive(true);
            for (int i = 0; i <MainCode.npcArray.Count; i++)
            {
                MainCode.npcArray[i].gameObject.SetActive(false);
            }
           // Time.timeScale = 0f;

        }
        
    }
    
    public void PauseGame(bool Pause)
    {
        if (Pause)
        {
            SesCal.PlayOneShot(Sesler[2]);
            Time.timeScale = 0f;
        }
        else
        {
            SesCal.PlayOneShot(Sesler[3]);
            Time.timeScale = 1f;
        }
    }
    public void Restart()
    {
        
        Count = 0;
        ComplateKontrol = false;
        Ses.GetComponent<AudioSource>().Play();
        
        FailedKontol = false;
        sayac = 0;
        SesCal.PlayOneShot(Sesler[3]);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Arrow = LevelTargetArrow;
        Fill.fillAmount = 1f;
        Time.timeScale = 1f;


    }
    public void Failed()
    {
        if (Arrow==-1||Fill.fillAmount==0)
        {
            TikTok.Stop();
            Arrow = 0;
            Pause.SetActive(false);
            Sup.slowImage.SetActive(false);
            Sup.superImage.SetActive(false);
            Sup.freezeImage.SetActive(false);
            Ses.GetComponent<AudioSource>().Stop();
            sayac++;
            if (sayac == 1)
            {
                SesCal.PlayOneShot(Sesler[16]);

            }
            
            for (int i = 0; i < MainCode.npcArray.Count; i++)
            {
                MainCode.npcArray[i].gameObject.SetActive(false);
            }
            FailedKontol = true;
            Fill.fillAmount = 1f;

            Time.timeScale = 0f;
            FailedObje.SetActive(true);


        }
    }
    public void MainMenü()
    {
        //int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        SesCal.PlayOneShot(Sesler[3]);
        SceneManager.LoadScene(0);
    }
    public void SkinSpawn()
    {
        if (Skinİndex==1)
        {
            Instantiate(Players[Skinİndex], SpawnPoint.transform.position, Quaternion.identity);
        }
        else if (Skinİndex==2)
        {
            Instantiate(Players[Skinİndex], SpawnPoint.transform.position, Quaternion.identity);
        }
        else if (Skinİndex==3)
        {
            Instantiate(Players[Skinİndex], SpawnPoint.transform.position, Quaternion.identity);
        }
        else if (Skinİndex==4)
        {
            Instantiate(Players[Skinİndex], SpawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Players[0], SpawnPoint.transform.position, Quaternion.identity);
        }
    }

}
