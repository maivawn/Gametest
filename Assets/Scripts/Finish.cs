using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public SelectMenu menu;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Player"))
        {

            menu.GameNext();

            UnlockNewlevel();
        }
        
        
    }
    void UnlockNewlevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex",SceneManager.GetActiveScene().buildIndex +1 );
            PlayerPrefs.SetInt("unlockedLevel", PlayerPrefs.GetInt("unlockedLevel",1) + 1 );
            PlayerPrefs.Save();
        }
    }
}
