using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSave : MonoBehaviour
{
    public int Coin = 0;
    public int PowerUpYavaslama = 0;
    public int PowerUpDonma = 0;
    public int AntiArrowAdet = 0;
    public int Skinİndex = 0;
    public int MısırSkin = 0;
    public int YunanSkin = 0;
    public int YesilSkin = 0;
    public int MogolSkin = 0;
    public Text CoinText;
    public Text PowerYavasText;
    public Text PowerDonmaText;
    public Text PowerAntiText;
    public GameObject MısırPriceButton;
    public GameObject YunanPriceButton;
    public GameObject YesilPriceButton;
    public GameObject MogolPriceButton;
    public GameObject MısırSelectButton;
    public GameObject YunanSelectButton;
    public GameObject YesilSelectButton;
    public GameObject MogolSelectButton;

    public bool Delete = false;
    void Start()
    {
        if (Delete)
        {
            PlayerPrefs.DeleteAll();
        }
        PowerUpYavaslama = PlayerPrefs.GetInt("SavePowerYavas");
        PowerUpDonma = PlayerPrefs.GetInt("SavePowerDonma");
        AntiArrowAdet = PlayerPrefs.GetInt("SavePowerAnti");
        Coin = PlayerPrefs.GetInt("SaveCoin");
        YunanSkin = PlayerPrefs.GetInt("SaveYunanSkin");
        MısırSkin = PlayerPrefs.GetInt("SaveMısırSkin");
        YesilSkin = PlayerPrefs.GetInt("SaveYesilSkin");
        MogolSkin = PlayerPrefs.GetInt("SaveMogolSkin");
        Skinİndex = PlayerPrefs.GetInt("SaveSkinİndex");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("sKİNiNDEX" + Skinİndex);
        if (CoinText!=null)
        {
            CoinText.text = Coin.ToString();
        }
        PowerYavasText.text = PowerUpYavaslama.ToString();
        PowerDonmaText.text = PowerUpDonma.ToString();
        PowerAntiText.text = AntiArrowAdet.ToString();
        SkinKontrol();
        if (Coin<=0)
        {
            Coin = 0;
        }
    }
    void SkinKontrol()
    {
        if (MısırSkin==1)
        {
            if (MısırSelectButton.GetComponent<Select>()!=null)
            {
                MısırSelectButton.SetActive(true);
            }
            else
            {
                MısırSelectButton.SetActive(false);
            }
            
           
            
            MısırPriceButton.SetActive(false);
            

        }
        else
        {

            MısırPriceButton.SetActive(true);
            MısırSelectButton.SetActive(false);
        }
        if (YunanSkin == 1)
        {
            if (YunanSelectButton.GetComponent<Select>() != null)
            {
                YunanSelectButton.SetActive(true);
            }
            else
            {
                YunanSelectButton.SetActive(false);
            }
            
            
            YunanPriceButton.SetActive(false);
            

        }
        else
        {
            YunanPriceButton.SetActive(true);
            YunanSelectButton.SetActive(false);
        }
        if (YesilSkin == 1)
        {
            if (YesilSelectButton.GetComponent<Select>() != null)
            {
                YesilSelectButton.SetActive(true);
            }
            else
            {
                YesilSelectButton.SetActive(false);
            }
            YesilPriceButton.SetActive(false);
            

        }
        else
        {
            YesilPriceButton.SetActive(true);
            YesilSelectButton.SetActive(false);
        }
        if (MogolSkin == 1)
        {
            if (MogolSelectButton.GetComponent<Select>() != null)
            {
                MogolSelectButton.SetActive(true);
            }
            else
            {
                MogolSelectButton.SetActive(false);
            }
            
            
            MogolPriceButton.SetActive(false);
            

        }
        else
        {
            MogolPriceButton.SetActive(true);
            MogolSelectButton.SetActive(false);
        }
    }
}
