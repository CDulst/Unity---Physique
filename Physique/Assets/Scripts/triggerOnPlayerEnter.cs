using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerOnPlayerEnter : MonoBehaviour
{
    public UI UI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            UI = FindObjectOfType<UI>();
            UI.UpdateScore();
        }
    }
}
