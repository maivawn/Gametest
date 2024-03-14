using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    public GameObject selectMenu;

    public void GameNext()
    {
        selectMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
