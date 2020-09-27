using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeShredder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
        Destroy(other.gameObject);
    }
}
