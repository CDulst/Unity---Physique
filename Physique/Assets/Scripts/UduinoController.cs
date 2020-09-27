using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using UnityEngine.SceneManagement;

public class UduinoController : MonoBehaviour
{
    public bool RedLed;
    public bool OrangeLed;
    public bool GreenLed;
    public bool Hitsound;
    public bool Deathsound;
    public bool Redstarted;
    public bool Orangestarted;
    public bool Greenstarted;
    public bool Hitstarted;
    [Range(0, 20)] public int intensity = 0;
    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.writeTimeout = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Redstarted)
        {
            StartCoroutine(blinkred());
        }
        if (!Orangestarted)
        {
            StartCoroutine(blinkorange());
        }
        if (!Greenstarted)
        {
            StartCoroutine(blinkgreen());
        }
        if (!Hitstarted)
        {
            StartCoroutine(hitsound());
        }
    }
    public IEnumerator blinkred()
    {
        while (RedLed)
        {
            Debug.Log("red");
            if (!Redstarted)
            {
                Redstarted = true;
            }
            UduinoManager.Instance.analogWrite(11, 0);
            while (intensity < 20)
            {
                intensity = intensity + 1;
                UduinoManager.Instance.analogWrite(3, intensity);
                yield return new WaitForSeconds(0.001f);
            }
            if (intensity == 20)
            {
                while (intensity > 0)
                {
                    intensity = intensity - 1;
                    UduinoManager.Instance.analogWrite(3, intensity);
                    yield return new WaitForSeconds(0.001f);
                }
            }
        }
        if (!RedLed)
        {
            Redstarted = false;
        }



    }
    public IEnumerator blinkorange()
    {
        while (OrangeLed)
        {
            Debug.Log("orange");
            if (!Orangestarted)
            {
                Orangestarted = true;
            }
            UduinoManager.Instance.analogWrite(11, 0);
            while (intensity < 20)
            {
                intensity = intensity + 1;
                UduinoManager.Instance.analogWrite(10, intensity);
                yield return new WaitForSeconds(0.001f);
            }
            if (intensity == 20)
            {
                while (intensity > 0)
                {
                    intensity = intensity - 1;
                    UduinoManager.Instance.analogWrite(10, intensity);
                    yield return new WaitForSeconds(0.001f);
                }
            }
        }
        if (!OrangeLed)
        {
            Orangestarted = false;
        }



    }
    public IEnumerator blinkgreen()
    {
        while (GreenLed)
        {
            Debug.Log("green");
            if (!Greenstarted)
            {
                UduinoManager.Instance.analogWrite(11, 0);
                Greenstarted = true;
            }
            while (intensity < 20)
            {
                intensity = intensity + 1;
                UduinoManager.Instance.analogWrite(5, intensity);
                yield return new WaitForSeconds(0.001f);
            }
            if (intensity == 20)
            {
                while (intensity > 0)
                {
                    intensity = intensity - 1;
                    UduinoManager.Instance.analogWrite(5, intensity);
                    yield return new WaitForSeconds(0.001f);
                }
            }
        }
        if (!GreenLed)
        {
            Greenstarted = false;
        }



    }
    public IEnumerator hitsound()
    {
        if(Hitsound)
        {
            UduinoManager.Instance.analogWrite(11, 100);
            Hitsound = false;
            yield return new WaitForSeconds(2);


        }
        if (!Hitsound)
        {
            Hitstarted = false;
        }


    }
    public void putOut()
    {
        Debug.Log("kanker");
        UduinoManager.Instance.digitalWrite(5, State.LOW);
        UduinoManager.Instance.digitalWrite(10, State.LOW);
        UduinoManager.Instance.digitalWrite(3, State.LOW);
    }
    public void Resetscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


       
}
