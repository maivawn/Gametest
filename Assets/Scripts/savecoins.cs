using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class savecoins : MonoBehaviour
{
    private int coinsScene2 = 0;
    [SerializeField] Text coinsText;
    [SerializeField] AudioSource coinsAudioSource;
    private void Start()
    {
       
        // coinsScene2 = PlayerPrefs.GetInt("CoinsScene1");

        int coinsFromScene1 = PlayerPrefs.GetInt("CoinsScene1", 0);
        coinsScene2 = coinsFromScene1;
        Debug.Log(coinsScene2);
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + coinsScene2;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            coinsAudioSource.Play();
            coinsScene2++;
            coinsText.text = "Coins :" + coinsScene2;

        }
    }
}