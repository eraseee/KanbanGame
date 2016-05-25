using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryCards : MonoBehaviour {

    public int businessValue;
    public int plannedRound;
    public int startedRound;
    public int completedRound;
    public int fullValueRound;
    public int score;
    public int analyse;
    public int develop;
    public int test;
    public int deploy;

    public bool special;


    GameObject text;


    GameObject planned;
    GameObject started;
    GameObject completed;
    GameObject fullvalue;
    GameObject total;
    GameObject ana;
    GameObject dev;
    GameObject testing;
    GameObject depl;
    GameObject business;



	// Use this for initialization
	void Start () {
        text = this.transform.Find("Text").gameObject;
        planned = text.transform.Find("plannedRound").gameObject;
        started = text.transform.Find("startedRound").gameObject;
        completed = text.transform.Find("finishedRound").gameObject;
        fullvalue = text.transform.Find("fullValueRound").gameObject;
        business = text.transform.Find("businessValue").gameObject;
        total = text.transform.Find("Score").gameObject;
        ana = text.transform.Find("Analyse_text").gameObject;
        dev = text.transform.Find("Development_text").gameObject;
        testing = text.transform.Find("Test_text").gameObject;
        depl = text.transform.Find("Deploy_text").gameObject;


        UpdateVariables();
 
       

    }
	
	// Update is called once per frame
	void Update () {
	
	}



    public void UpdateVariables() {
        if (plannedRound != 0)
        {
            planned.transform.GetComponent<Text>().text = "Planned round: " + plannedRound;
        }
        else
        {
            planned.GetComponent<Text>().text = "Planned round: 0";
        }

        if (startedRound != 0)
        {
            started.transform.GetComponent<Text>().text = "Started round: " + startedRound;
        }
        else
        {
            started.GetComponent<Text>().text = "Started round: ";
        }

        if (completedRound != 0)
        {
            completed.transform.GetComponent<Text>().text = "Completed round: " + completedRound;
        }
        else
        {
            completed.GetComponent<Text>().text = "Completed round: ";
        }

        if (fullValueRound != 0)
        {
            fullvalue.transform.GetComponent<Text>().text = "Full value round: " + fullValueRound;
        }
        else
        {
            fullvalue.GetComponent<Text>().text = "Full value round: ";
        }

        if (businessValue != 0)
        {
            business.transform.GetComponent<Text>().text = "Business value: " + businessValue;
        }
        else
        {
            business.GetComponent<Text>().text = "Business value: 0";
        }

        if (score != 0)
        {
            total.transform.GetComponent<Text>().text = "Score: " + score;
        }
        else
        {
            total.GetComponent<Text>().text = "Score: 0";
        }

        if (analyse != 0)
        {
            ana.transform.GetComponent<Text>().text = "Analyse: " + analyse;
        }
        else
        {
            ana.GetComponent<Text>().text = "Analyse: 0";
        }

        if (develop != 0)
        {
            dev.transform.GetComponent<Text>().text = "Development: " + develop;
        }
        else
        {
            dev.GetComponent<Text>().text = "Development: 0";
        }

        if (test != 0)
        {
            testing.transform.GetComponent<Text>().text = "Test: " + test;
        }
        else
        {
            testing.GetComponent<Text>().text = "Test: 0";
        }

        if (deploy != 0)
        {
            depl.transform.GetComponent<Text>().text = "Deploy: " + deploy;
        }
        else
        {
            depl.GetComponent<Text>().text = "Deploy: 0";
        }
    }
}
