using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGenerator : MonoBehaviour
{
    public int[,] Objectplacement;
    public string errorcheck = " ";
    public GameObject Tree;
    // Start is called before the first frame update
    void Start()
    {
        Objectplacement = new int[3, 5];
        DecidePlacement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecidePlacement()
    {
        // setting all values in array to 0
        for(int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                Objectplacement[x, y] = 0;
            }
       
        }
        CheckError();
        DecideTrees();
        
    }

    public void DecideTrees()
    {
        int treenumber = 3;
        int treesplaced = 0;

        for (int x = 0; x < 3; x++)
        {
            while (treesplaced < treenumber)
            {
                int position = Random.Range(0, 5);
                int descision = Random.Range(0, 2);
                if (descision == 1)
                {
                    if (Objectplacement[x,position] == 0)
                    {
                        Objectplacement[x, position] = 1;
                        treesplaced += 1;
                    }
                }
            }
            treesplaced = 0;
        }
        CheckError();
        PlaceTrees();
    }

    public void CheckError()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                errorcheck += Objectplacement[x, y].ToString();
            }
            Debug.Log(errorcheck);
            errorcheck = " ";
        }
    }

    public void PlaceTrees()
    {
        Debug.Log(transform.GetChild(1).GetChild(1));
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (Objectplacement[x,y] == 1)
                {
                   GameObject deployedTree = Instantiate(Tree, transform.GetChild(1).GetChild(x).GetChild(y).transform.position, Quaternion.identity).gameObject;
                    deployedTree.transform.parent = gameObject.transform;
                }
            }
            Debug.Log(errorcheck);
            errorcheck = " ";
        }
    }
}
