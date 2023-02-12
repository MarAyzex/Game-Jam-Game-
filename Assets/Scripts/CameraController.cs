using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;

    void Start()
    {
        
    }

    // For camera follow while jumping add "player." to "transform.position.y"
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

    }
}
