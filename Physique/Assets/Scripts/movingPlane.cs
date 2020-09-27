using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlane : MonoBehaviour
{
    public GameObject MovePosition;
    public float moveSpeed;
    public bool moving;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "rightplane")
        {
            MovePosition = GameObject.FindGameObjectWithTag("rightpoint");
        }
        else if (gameObject.tag == "leftplane")
        {
            MovePosition = GameObject.FindGameObjectWithTag("leftpoint");
        }
        else
        {
            MovePosition = GameObject.FindGameObjectWithTag("movepoint");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
            moving = true;   
        

        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, MovePosition.transform.position, moveSpeed * Time.deltaTime);
        }

    }
}
