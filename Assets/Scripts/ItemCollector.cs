using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    [SerializeField] Text coinsText;

    [SerializeField] AudioSource coinsAudioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            coins++;
            coinsAudioSource.Play();
            savecoins();
            coinsText.text = "Coins :" + coins;
            
        }

    }
    public void savecoins()
    {
        PlayerPrefs.SetInt("CoinsScene1", coins);
        PlayerPrefs.Save();
       
    }
    private void Awake()
    {
        savecoins();
    }
}
