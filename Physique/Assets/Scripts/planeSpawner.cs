using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
public class planeSpawner : MonoBehaviour
{
    public GameObject spawnPosition;
    public GameObject spawnObject;
    public GameObject MainMenu;
    public GameObject Score;
    public int substr;
    public bool started;
    public bool coentered;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.OnDataReceived += ReadIMU;
    }

    // Update is called once per frame
    void Update()
    {
  
        if (substr < -200 && !started)
        {
            spawnPlane();
            FindObjectOfType<UduinoController>().GreenLed = true;
            disableMainMenu();
            started = true;
        }
        if (substr > 200 && !started)
        {
            spawnPlane();
            FindObjectOfType<UduinoController>().GreenLed = true;
            disableMainMenu();
            started = true;
        }
      
    }
    public void disableMainMenu()
    {
        MainMenu.SetActive(false);
        Score.SetActive(true);
    }
    public void spawnPlane()
    {
        Instantiate(spawnObject, spawnPosition.transform.position, Quaternion.identity);
    }
    public void ReadIMU(string data, UduinoDevice device)
    {

        try
        {
            substr = int.Parse(data.Substring(6, 5));
        }
        catch (System.FormatException)
        {
            substr = int.Parse(data.Substring(6, 4));
        }
    }
    
}
