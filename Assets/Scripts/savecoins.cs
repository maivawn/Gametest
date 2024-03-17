using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class savecoins : MonoBehaviour
{
    private int coinsScene2 = 0;
    private int highcoinsScene2 = 0;
    [SerializeField] Text coinsText;
    [SerializeField] Text highcoinsText;
    [SerializeField] AudioSource coinsAudioSource;
    private void Start()
    {
       
        // coinsScene2 = PlayerPrefs.GetInt("CoinsScene1");

        int coinsFromScene1 = PlayerPrefs.GetInt("CoinsScene1", 0);
        int highFromScene1 = PlayerPrefs.GetInt("highCoins");
        highcoinsScene2 = highFromScene1;
        coinsScene2 = coinsFromScene1;

        coinsText.text = "Coins :" + coinsScene2;
        highcoinsText.text = "High Coins :" + PlayerPrefs.GetInt("highCoinsScene2");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            coinsAudioSource.Play();
            coinsScene2++;

            if (coinsScene2 > PlayerPrefs.GetInt("highCoinsScene2"))
            {
                PlayerPrefs.SetInt("highCoinsScene2", coinsScene2);
            }
            coinsText.text = "Coins :" + coinsScene2;

           

        }
    }
}