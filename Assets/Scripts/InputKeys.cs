using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeys : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    Playercontrol playercontrol;

    private void Awake()
    {
        playercontrol = FindObjectOfType<Playercontrol>();
    }
    public void OnLeftDown()
    {
        playercontrol.HorizontalInput(-1f);
    }
    public void OnleftUp() 
    {
        playercontrol.HorizontalInput(0f);

    }

    public void OnRightDown() 
    {
        playercontrol.HorizontalInput(1f);

    }
    public void OnRightUp() 
    {

        playercontrol.HorizontalInput(0f);
    }
    public void JumpInput()
    {
       
        playercontrol.JumpInput();
        audioSource.Play();
    }
}
