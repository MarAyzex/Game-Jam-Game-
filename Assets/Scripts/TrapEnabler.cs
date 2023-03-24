using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEnabler : MonoBehaviour
{
    public GameObject Trap;
    public Vector3 trapPosition;

    void Start()
    {
        trapPosition = transform.position;
    }

    
    void Update()
    {
        
    }
    //var arī ar gravity, bet tad jānomaina gameobject uz rigidbody
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Trap.SetActive(true);
        }
        else
        {
            trapPosition = transform.position;
        }
    }
}
