using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    PlayerSave playerSave;
    bool Kontrol = false;
    private void Start()
    {
        playerSave = FindObjectOfType<PlayerSave>();
    }
    // Start is called before the first frame update
    public void BuyYavas()
    {
        if (Kontrol)
        {
            Debug.Log("Paran Bitt");
            playerSave.Coin = 0;
        }
        else
        {
            
            playerSave.PowerUpYavaslama++;
            playerSave.Coin -= 100;
            PlayerPrefs.SetInt("SavePowerYavas", playerSave.PowerUpYavaslama);
            PlayerPrefs.SetInt("SaveCoin", playerSave.Coin);
        }
        
        
    }
    public void BuyDonma()
    {
        if (Kontrol)
        {
            Debug.Log("Paran Bitt");
            playerSave.Coin = 0;
        }
        else
        {
            
            playerSave.PowerUpDonma++;
            playerSave.Coin -= 150;
            PlayerPrefs.SetInt("SavePowerDonma", playerSave.PowerUpDonma);
            PlayerPrefs.SetInt("SaveCoin", playerSave.Coin);

        }
        
        
    }
    public void BuyAnti()
    {
        if (Kontrol)
        {
            Debug.Log("Paran Bitt");
            playerSave.Coin = 0;
        }
        else
        {
            
            playerSave.AntiArrowAdet++;
            playerSave.Coin -= 200;
            PlayerPrefs.SetInt("SavePowerAnti", playerSave.AntiArrowAdet);
            PlayerPrefs.SetInt("SaveCoin", playerSave.Coin);

        }
        
        
    }
   
    private void Update()
    {
        if (playerSave.Coin==0)
        {
            Kontrol = true;
        }
        else
        {
            Kontrol = false;
        }
    }

}
