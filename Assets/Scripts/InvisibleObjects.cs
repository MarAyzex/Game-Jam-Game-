using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObjects : MonoBehaviour
{
    public GameObject isInvisible;


    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
