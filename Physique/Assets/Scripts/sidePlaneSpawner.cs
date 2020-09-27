using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidePlaneSpawner : MonoBehaviour
{
    public GameObject rightpoint;
    public GameObject leftpoint;
    public GameObject leftplane;
    public GameObject rightplane;
    // Start is called before the first frame update
    void Start()
    {
        spawnPlane();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPlane()
    {
        Instantiate(rightplane, rightpoint.transform.position, Quaternion.identity);
        Instantiate(leftplane, leftpoint.transform.position, Quaternion.identity);
    }
}
