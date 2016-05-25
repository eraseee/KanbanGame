using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class RoundSystem : MonoBehaviour {

    [HideInInspector]
    public int round;

    CycleSystem cycle;

    GameObject planning, analyse, dev, deploy, test;

    GameObject expedite1, expedite3, expedite4, expedite5;


	// Use this for initialization
	void Start () {
        round = 0;
        cycle = gameObject.transform.Find("CycleSystem").GetComponent<CycleSystem>();

        planning = GameObject.FindGameObjectWithTag("Planning");
        analyse = GameObject.FindGameObjectWithTag("Analyse");
        dev = GameObject.FindGameObjectWithTag("Development");
        deploy = GameObject.FindGameObjectWithTag("Deploy");
        test = GameObject.FindGameObjectWithTag("Test");

        planning.GetComponent<WIPLimit>().enabled = false;
        analyse.GetComponent<WIPLimit>().enabled = false;
        dev.GetComponent<WIPLimit>().enabled = false;
        deploy.GetComponent<WIPLimit>().enabled = false;
        test.GetComponent<WIPLimit>().enabled = false;

        expedite1 = GameObject.Find("Expedite1");
        expedite3 = GameObject.Find("Expedite3");
        expedite4 = GameObject.Find("Expedite4");
        expedite5 = GameObject.Find("Expedite5");
        expedite1.SetActive(false);
        expedite3.SetActive(false);
        expedite4.SetActive(false);
        expedite5.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {

    }


    public void nextRound()
    {
        if (!cycle.stateAna && !cycle.stateDeploy && !cycle.stateDev && !cycle.stateTest)
        {
            if (round == 0)
            {
                cycle.activateDeploy();
                cycle.activateTest();
                cycle.activateDev();
                cycle.activateAna();
                cycle.functionCalled = false;
            }
            if (round == 1)
            {
                cycle.activateDeploy();
                cycle.activateTest();
                cycle.activateDev();
                cycle.functionCalled = false;
            }
            if (round == 2)
            {
                cycle.activateDeploy();
                cycle.activateTest();
                cycle.functionCalled = false;
            }
            if (round > 3 && round < 20)
            {
                if(round == 5)
                {
                    activateLimit();
                }
                if(round == 7)
                {
                    expedite3.SetActive(true);
                    expedite3.transform.SetParent(analyse.transform);
                }

                if(round == 10)
                {
                    expedite1.SetActive(true);
                    expedite1.transform.SetParent(analyse.transform);
                }

                if(round == 14)
                {
                    expedite5.SetActive(true);
                    expedite5.transform.SetParent(analyse.transform);
                }

                if(round == 17)
                {
                    expedite4.SetActive(true);
                    expedite4.transform.SetParent(analyse.transform);
                }

                cycle.activateDeploy();
                cycle.functionCalled = false;
            }
            else
            {
                // Gameover
                // This is most likely gonna be function within this script, that goes to a game over screen, probably a new sceen which will be loaded with variables saved in a highscore element.
                // this highscore element will exist in all scenes, carrying highscores accross scenes, making it possible to save these.
            }
            round++;
          }
    }


    void activateLimit()
    {
        planning.GetComponent<WIPLimit>().enabled = true;
        analyse.GetComponent<WIPLimit>().enabled = true;
        dev.GetComponent<WIPLimit>().enabled = true;
        deploy.GetComponent<WIPLimit>().enabled = true;
        test.GetComponent<WIPLimit>().enabled = true;

        GameObject.Find("Analysis").transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Analysis  WIP: 2";
        GameObject.Find("Development").transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Development  WIP: 3";
        GameObject.Find("Test").transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Test  WIP: 2";
        GameObject.Find("Deploy").transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Deploy  WIP: 1";
        GameObject.Find("Planned").transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Planning  WIP: 5";

    }



    public void allowDiceDrag()
    {
        GameObject diceA, diceDev, diceDep, diceTest;
        diceA = GameObject.FindGameObjectWithTag("AnalyseDice");
        diceDev = GameObject.FindGameObjectWithTag("DevDice");
        diceDep = GameObject.FindGameObjectWithTag("DeployDice");
        diceTest = GameObject.FindGameObjectWithTag("TestDice");

        for(int i = 0; i < diceA.transform.childCount; i++)
        {
            diceA.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
        }

        for (int i = 0; i < diceDev.transform.childCount; i++)
        {
            diceDev.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
        }


        for (int i = 0; i < diceDep.transform.childCount; i++)
        {
            diceDep.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
        }


        for (int i = 0; i < diceTest.transform.childCount; i++)
        {
            diceTest.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
        }

    }



    public void removeDiceDrag()
    {
        GameObject diceA, diceDev, diceDep, diceTest;
        diceA = GameObject.FindGameObjectWithTag("AnalyseDice");
        diceDev = GameObject.FindGameObjectWithTag("DevDice");
        diceDep = GameObject.FindGameObjectWithTag("DeployDice");
        diceTest = GameObject.FindGameObjectWithTag("TestDice");

        for (int i = 0; i < diceA.transform.childCount; i++)
        {
            diceA.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }

        for (int i = 0; i < diceDev.transform.childCount; i++)
        {
            diceDev.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }


        for (int i = 0; i < diceDep.transform.childCount; i++)
        {
            diceDep.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }


        for (int i = 0; i < diceTest.transform.childCount; i++)
        {
            diceTest.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
    }

}
