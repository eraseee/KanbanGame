using UnityEngine;
using System.Collections;

public class CycleSystem : MonoBehaviour {

    public bool stateAna;
    public bool stateDev;
    public bool stateTest;
    public bool stateDeploy;
    public bool functionCalled;
    GameObject previousState;
    GameObject nextState;
    GameObject prevStateDice;
    GameObject nextStateDice;
    DiceGenerator dicetoggler;


    RoundSystem round;

    // Use this for initialization
    void Start () {
        round = GameObject.Find("RoundSystem").GetComponent<RoundSystem>();
        functionCalled = false;
        dicetoggler = GameObject.Find("Dice_assign").GetComponent<DiceGenerator>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextCycle()
    {
        if (stateDeploy && !functionCalled)
        {
            activateTest();
        }
        if (stateTest && !functionCalled)
        {
            activateDev();
        }
        if (stateDev && !functionCalled)
        {
            activateAna();
        }
        if (stateAna && !functionCalled)
        {
            activatePlan();
        }
        functionCalled = false;



    }



    public void activateAna()
    {
        functionCalled = true;
        stateDev = false;
        stateAna = true;
        previousState = GameObject.FindGameObjectWithTag("Development");
        nextState = GameObject.FindGameObjectWithTag("Analyse");
        GameObject Planning = GameObject.FindGameObjectWithTag("Planning");
        GameObject Done = GameObject.Find("Ana_done");

        Planning.GetComponent<DropZone>().enabled = true;

        nextState.GetComponent<DropZone>().enabled = true;

        previousState.GetComponent<DropZone>().enabled = false;
        
        Done.GetComponent<DropZone>().enabled = false;

        // Make sure you can't move cards in other categories, and that we are rolling dice for the correct state.
        // Some loops are primarily precautions loops.

        for (int i = 0; i < Planning.transform.childCount; i++)
        {
            Planning.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
        }
        for(int i = 0; i < nextState.transform.childCount; i++)
        {
            nextState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
        for(int i = 0; i < previousState.transform.childCount; i++)
        {
            previousState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
            if(previousState.transform.GetChild(i).GetComponent<StoryCards>().develop == 0)
            {
                i -= 1;
                previousState.transform.GetChild(i).SetParent(GameObject.Find("Dev_done").transform);
            }
        }
        for(int i = 0; i < Done.transform.childCount; i++)
        {
            Done.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
        if (!dicetoggler.enabled)
        {
            dicetoggler.toggleScript();
        }


    }

    public void activateDev()
    {
        functionCalled = true;
        stateTest = false;
        stateDev = true;
        previousState = GameObject.FindGameObjectWithTag("Test");
        nextState = GameObject.FindGameObjectWithTag("Development");
        GameObject Done = GameObject.Find("Dev_done");
        GameObject Ana = GameObject.Find("Ana_done");

        previousState.GetComponent<DropZone>().enabled = false;
        Done.GetComponent<DropZone>().enabled = false;
        nextState.GetComponent<DropZone>().enabled = true;
        Ana.GetComponent<DropZone>().enabled = true;

        // Make sure you can't move cards in other categories, and that we are rolling dice for the correct state.

        for (int i = 0; i < Ana.transform.childCount; i++)
        {
            Ana.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
        }
        for (int i = 0; i < nextState.transform.childCount; i++)
        {
            nextState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
        for (int i = 0; i < previousState.transform.childCount; i++)
        {
            previousState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
            if (previousState.transform.GetChild(i).GetComponent<StoryCards>().test == 0)
            {
                i -= 1;
                previousState.transform.GetChild(i).SetParent(GameObject.Find("Test_done").transform);
            }
        }
        for (int i = 0; i < Done.transform.childCount; i++)
        {
            Done.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
        if (!dicetoggler.enabled)
        {
            dicetoggler.toggleScript();
        }


    }

    public void activateTest()
    {
        functionCalled = true;
        stateDeploy = false;
        stateTest = true;
        previousState = GameObject.FindGameObjectWithTag("Deploy");
        nextState = GameObject.FindGameObjectWithTag("Test");
        GameObject Done = GameObject.Find("Test_done");
        GameObject dev = GameObject.Find("Dev_done");

        previousState.GetComponent<DropZone>().enabled = false;
        Done.GetComponent<DropZone>().enabled = false;
        nextState.GetComponent<DropZone>().enabled = true;
        dev.GetComponent<DropZone>().enabled = true;

        // Make sure you can't move cards in other categories, and that we are rolling dice for the correct state.

        for (int i = 0; i < dev.transform.childCount; i++)
        {
            dev.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
        }
        for (int i = 0; i < nextState.transform.childCount; i++)
        {
            nextState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
        for (int i = 0; i < previousState.transform.childCount; i++)
        {
            previousState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
            if (previousState.transform.GetChild(i).GetComponent<StoryCards>().deploy == 0)
            {
                i -= 1;
                previousState.transform.GetChild(i).GetComponent<StoryCards>().completedRound = round.round;
                int full = previousState.transform.GetChild(i).GetComponent<StoryCards>().fullValueRound;
                if (round.round <= full)
                {
                    previousState.transform.GetChild(i).GetComponent<StoryCards>().score = previousState.transform.GetChild(i).GetComponent<StoryCards>().businessValue;
                }
                else
                {
                    if (previousState.transform.GetChild(i).GetComponent<StoryCards>().special)
                    {
                        previousState.transform.GetChild(i).GetComponent<StoryCards>().score = 0;
                    }
                    int diff = round.round - full;
                    print(diff);
                    if(diff > 3)
                    {
                        previousState.transform.GetChild(i).GetComponent<StoryCards>().score = 0;
                    }
                    if(diff == 1)
                    {
                        previousState.transform.GetChild(i).GetComponent<StoryCards>().score = Mathf.FloorToInt(previousState.transform.GetChild(i).GetComponent<StoryCards>().businessValue * 0.75f);
                    }
                    if (diff == 2)
                    {
                        previousState.transform.GetChild(i).GetComponent<StoryCards>().score = Mathf.FloorToInt(previousState.transform.GetChild(i).GetComponent<StoryCards>().businessValue * 0.5f);
                    }
                    if (diff == 3)
                    {
                        previousState.transform.GetChild(i).GetComponent<StoryCards>().score = Mathf.FloorToInt(previousState.transform.GetChild(i).GetComponent<StoryCards>().businessValue * 0.25f);
                    }
                }
                previousState.transform.GetChild(i).GetComponent<StoryCards>().UpdateVariables();
                previousState.transform.GetChild(i).SetParent(GameObject.Find("Done_done").transform);
                
            }
        }
        for (int i = 0; i < Done.transform.childCount; i++)
        {
            Done.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }

        if (!dicetoggler.enabled)
        {
            dicetoggler.toggleScript();
        }

    }

    public void activateDeploy()
    {
        round.removeDiceDrag();
        functionCalled = true;
        stateDeploy = true;

        previousState = GameObject.FindGameObjectWithTag("Planning");
        nextState = GameObject.FindGameObjectWithTag("Deploy");
        GameObject test = GameObject.Find("Test_done");
        GameObject Done = GameObject.FindGameObjectWithTag("Backlog");

        previousState.GetComponent<DropZone>().enabled = false;
        Done.GetComponent<DropZone>().enabled = false;
        nextState.GetComponent<DropZone>().enabled = true;
        test.GetComponent<DropZone>().enabled = true;

        // Make sure you can't move cards in other categories, and that we are rolling dice for the correct state.

        for (int i = 0; i < test.transform.childCount; i++)
        {
            test.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
        }
        for (int i = 0; i < nextState.transform.childCount; i++)
        {
            nextState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
        for (int i = 0; i < previousState.transform.childCount; i++)
        {
            if (previousState.transform.GetChild(i).GetComponent<StoryCards>().plannedRound != 0)
            {
                previousState.transform.GetChild(i).GetComponent<StoryCards>().plannedRound = round.round;
                previousState.transform.GetChild(i).GetComponent<StoryCards>().UpdateVariables();
            }
            previousState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
        for (int i = 0; i < Done.transform.childCount; i++)
        {
            Done.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
        if (!dicetoggler.enabled)
        {
            dicetoggler.toggleScript();
        }
    }

    public void activatePlan()
    {
        round.allowDiceDrag();
        functionCalled = true;
        stateAna = false;
        previousState = GameObject.FindGameObjectWithTag("Analyse");
        nextState = GameObject.FindGameObjectWithTag("Planning");
        GameObject Backlog = GameObject.FindGameObjectWithTag("Backlog");
        GameObject Done = GameObject.Find("Ana_done");


        previousState.GetComponent<DropZone>().enabled = false;
        Done.GetComponent<DropZone>().enabled = false;
        nextState.GetComponent<DropZone>().enabled = true;
        Backlog.GetComponent<DropZone>().enabled = true;

        // Make sure you can't move cards in other categories, and that we are rolling dice for the correct state.

        for (int i = 0; i < Backlog.transform.childCount; i++)
        {
            Backlog.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
        }
        for (int i = 0; i < nextState.transform.childCount; i++)
        {
            nextState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
        for (int i = 0; i < previousState.transform.childCount; i++)
        {
            print("Entering the previous state");
            if (previousState.transform.GetChild(i).GetComponent<StoryCards>().fullValueRound != 0 && previousState.transform.GetChild(i).GetComponent<StoryCards>().startedRound != 0)
            {
                previousState.transform.GetChild(i).GetComponent<StoryCards>().fullValueRound = round.round + 4;
                previousState.transform.GetChild(i).GetComponent<StoryCards>().startedRound = round.round;
                previousState.transform.GetChild(i).GetComponent<StoryCards>().UpdateVariables();
            }
            previousState.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
            if (previousState.transform.GetChild(i).GetComponent<StoryCards>().analyse == 0)
            {
                previousState.transform.GetChild(i).SetParent(GameObject.Find("Ana_done").transform);
                print("LETS MOVE THIS BITCH");
                i -= 1;
            }

        }
        for (int i = 0; i < Done.transform.childCount; i++)
        {
            Done.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
        }
    }




}
