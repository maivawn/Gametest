using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float speedZ;


    private void Update()
    {
        transform.Rotate( speedX , 360 *speedY * Time.deltaTime, speedZ  );
    }
}
