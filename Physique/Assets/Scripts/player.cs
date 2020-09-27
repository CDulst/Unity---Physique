using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Uduino;
public class player : MonoBehaviour
{
    public List<GameObject> PlayerPositions;
    private int CurrentPosition = 2;
    public int lives = 3;
    public float moveSpeed = 1f;
    public bool invinsible;
    public bool invtriggering;
    public int substr;
    public bool moveright = true;
    public bool moveleft = true;
    public bool red;
    public bool orange;
    public bool green;
    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.OnDataReceived += ReadIMU;
        
    }

    // Update is called once per frame
    void Update()
    {
        red = FindObjectOfType<UduinoController>().RedLed;
        orange = FindObjectOfType<UduinoController>().OrangeLed;
        green = FindObjectOfType<UduinoController>().GreenLed;
        if (substr > 200 && moveleft)
        {
            Moveleft();
            moveleft = false;
        }
        if (substr < 100)
        {
            moveleft = true;
        }
        if (substr < -200 && moveright)
        {
            MoveRight();
            moveright = false;
        }
        if (substr > -100)
        {
            moveright = true;
        }
        if (lives == 0)
        {
            SceneManager.LoadScene("Gamescene");
        }
        if (invinsible)
        {
            if (!invtriggering)
            {
                StartCoroutine(invinsibilityframes());
            }
        }
    }

    private void Moveleft()
    {
        if (transform.position.x != PlayerPositions[0].transform.position.x)
        {
            CurrentPosition -= 1;

            transform.position = Vector3.MoveTowards(transform.position, PlayerPositions[CurrentPosition].transform.position, moveSpeed * Time.deltaTime);
        }
    }

    
    private void MoveRight()
    {
        if (transform.position.x != PlayerPositions[4].transform.position.x)
        {
            CurrentPosition += 1;
            transform.position = Vector3.MoveTowards(transform.position, PlayerPositions[CurrentPosition].transform.position, moveSpeed * Time.deltaTime);
        }
    }

    public IEnumerator invinsibilityframes()
    {
        invtriggering = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        invtriggering = false;
    }

    public IEnumerator invinsibleTime()
    {
        yield return new WaitForSeconds(1);
        invinsible = false;
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
    public void reduceLive()
    {
        if (!invinsible)
        {
            StartCoroutine(hitsounds());
            FindObjectOfType<UduinoController>().putOut();
            if (green)
            {
                FindObjectOfType<UduinoController>().GreenLed = false;
                FindObjectOfType<UduinoController>().Greenstarted = false;
                StartCoroutine(putorange());
            }
            if (orange)
            {
                FindObjectOfType<UduinoController>().OrangeLed = false;
                FindObjectOfType<UduinoController>().Orangestarted = false;
                StartCoroutine(putred());
            }
           
            lives -= 1;
            invinsible = true;
            StartCoroutine(invinsibleTime());
        }
      
    }
    public IEnumerator putorange()
    {
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<UduinoController>().OrangeLed = true;
    }
    public IEnumerator putred()
    {
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<UduinoController>().RedLed = true;
    }
    public IEnumerator hitsounds()
    {
        FindObjectOfType<UduinoController>().Hitsound = true;
        yield return new WaitForSeconds(3);
    }
}

