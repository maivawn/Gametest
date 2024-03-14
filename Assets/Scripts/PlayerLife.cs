using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    [SerializeField] float timeLoadScene = 0.2f;
    bool dead = false;
    [SerializeField] AudioSource deathSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            /*
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            */
            Die();
        }
    }


    private void Update()
    {
        if(transform.position.y < -4f && !dead)
        {
            Die();
        }    
    }
    void Die()
    {
        
        Invoke(nameof(ReloadLevel), timeLoadScene);
        dead = true;
        deathSound.Play();
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
