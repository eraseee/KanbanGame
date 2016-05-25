using UnityEngine;
using System.Collections;

public class DiceCalculator : MonoBehaviour {

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void anaCalc(int roll)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            StoryCards tmp = this.transform.GetChild(i).GetComponent<StoryCards>();
            if (tmp.analyse < roll)
            {
                roll -= tmp.analyse;
                tmp.analyse = 0;
                tmp.UpdateVariables();
            }
            else
            {
                tmp.analyse -= roll;
                tmp.UpdateVariables();
                return;
            }
        }
    }

    public void devCalc(int roll)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            StoryCards tmp = this.transform.GetChild(i).GetComponent<StoryCards>();
            if (tmp.develop < roll)
            {
                roll -= tmp.develop;
                tmp.develop = 0;
                tmp.UpdateVariables();
            }
            else
            {
                tmp.develop -= roll;
                tmp.UpdateVariables();
                return;
            }
        }
    }

    public void testCalc(int roll)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            StoryCards tmp = this.transform.GetChild(i).GetComponent<StoryCards>();
            if (tmp.test < roll)
            {
                roll -= tmp.test;
                tmp.test = 0;
                tmp.UpdateVariables();
            }
            else
            {
                tmp.test -= roll;
                tmp.UpdateVariables();
                return;
            }
        }
    }

    public void deployCalc(int roll)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            StoryCards tmp = this.transform.GetChild(i).GetComponent<StoryCards>();
            if (tmp.deploy < roll)
            {
                roll -= tmp.deploy;
                tmp.deploy = 0;
                tmp.UpdateVariables();
            }
            else
            {
                tmp.deploy -= roll;
                tmp.UpdateVariables();
                return;
            }
        }
    }


}
