using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeTrigger : MonoBehaviour
{
    public planeSpawner planeSpawner;
    public sidePlaneSpawner SidePlaneSpawner;
    private void OnTriggerEnter(Collider other)
    {
        planeSpawner = FindObjectOfType<planeSpawner>();
        SidePlaneSpawner = FindObjectOfType<sidePlaneSpawner>();
        if (other.gameObject.tag == "player")
        {
            if (gameObject.tag == "sideplanespawner")
            {
                SidePlaneSpawner.spawnPlane();
            }
            else
            {
                planeSpawner.spawnPlane();
            }
            
            
        }
    }
}
