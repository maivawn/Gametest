using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowCamera : MonoBehaviour
{
    //public Transform Player;
    //public Vector3 offer = new Vector3(-0.55f, 2.64f, -10.92f);
    [SerializeField] Transform player;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.y = 0;
        transform.position = targetPos;
    }
}
