using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowCamera : MonoBehaviour
{
    public Transform Player;
    public Vector3 offer = new Vector3(-0.55f, 2.64f, -10.92f);

    private void Start()
    {
        Player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        transform.position = Player.transform.position + offer;
    }
}
