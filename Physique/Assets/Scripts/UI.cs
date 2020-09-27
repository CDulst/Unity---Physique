using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject Score;
    public int currentScore;
    public string scoretext;
    // Start is called before the first frame update
    void Start()
    {
        Score = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoretext = Score.GetComponent<Text>().text;
        currentScore = int.Parse(scoretext);
        currentScore += 1;
        Debug.Log(currentScore);
        Score.GetComponent<Text>().text = currentScore.ToString();
        
    }
}
