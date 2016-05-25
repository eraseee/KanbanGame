using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiceGenerator : MonoBehaviour {

    public Texture[] textures;
    Transform diceToRoll;
    List<Transform> dice;
    CycleSystem cycle;

    int totalDiceRoll;
    DiceCalculator calc;



    // Use this for initialization
    void Start () {
        dice = new List<Transform>();
        cycle = GameObject.Find("CycleSystem").GetComponent<CycleSystem>();
        totalDiceRoll = 0;
    }
	
    


	// Update is called once per frame
	void Update () {
	    
	}

    // Handler for generating the new numbers and the acquiring the new textures for the dice.

    public void startGenerator()
    { 
        // Handles each state of the game seperatly, depending on what cycle is active.
        if (cycle.stateAna)
        {
            calc = GameObject.FindWithTag("Analyse").GetComponent<DiceCalculator>();
            for (int i = 0; i < GameObject.FindWithTag("AnalyseDice").transform.childCount; i++)
            {
                diceToRoll = GameObject.FindWithTag("AnalyseDice").transform.GetChild(i);
                dice.Add(diceToRoll);
                Dice TESTING = dice[i].gameObject.GetComponent<Dice>();
                int roll = randomGenerator();
                TESTING.numberChange(textures[roll - 1]);
            }
            calc.anaCalc(totalDiceRoll);
            totalDiceRoll = 0;
            dice.Clear();
        }
        if (cycle.stateDev)
        {
            for (int i = 0; i < GameObject.FindWithTag("DevDice").transform.childCount; i++)
            {
                diceToRoll = GameObject.FindWithTag("DevDice").transform.GetChild(i);
                dice.Add(diceToRoll);
                Dice TESTING = dice[i].gameObject.GetComponent<Dice>();
                int roll = randomGenerator();
                TESTING.numberChange(textures[roll - 1]);
            }
            calc.devCalc(totalDiceRoll);
            totalDiceRoll = 0;
            dice.Clear();
        }
        if (cycle.stateDeploy)
        {
            for (int i = 0; i < GameObject.FindWithTag("DeployDice").transform.childCount; i++)
            {
                diceToRoll = GameObject.FindWithTag("DeployDice").transform.GetChild(i);
                dice.Add(diceToRoll);
                Dice TESTING = dice[i].gameObject.GetComponent<Dice>();
                int roll = randomGenerator();
                TESTING.numberChange(textures[roll - 1]);
            }
            calc.deployCalc(totalDiceRoll);
            totalDiceRoll = 0;
            dice.Clear();
        }
        if (cycle.stateTest)
        {
            for (int i = 0; i < GameObject.FindWithTag("TestDice").transform.childCount; i++)
            {
                diceToRoll = GameObject.FindWithTag("TestDice").transform.GetChild(i);
                dice.Add(diceToRoll);
                Dice TESTING = dice[i].gameObject.GetComponent<Dice>();
                int roll = randomGenerator();
                TESTING.numberChange(textures[roll - 1]);
            }
            calc.testCalc(totalDiceRoll);
            totalDiceRoll = 0;
            dice.Clear();
        }

        toggleScript();

    }

    // Generates a random number between 1 and 6.
    int randomGenerator()
    {
        float rng =  Random.Range(2, 18);
        int tmp = Mathf.CeilToInt(rng / 3);
        totalDiceRoll += tmp;
        //print(tmp);
        return tmp;

    }



    public void toggleScript()
    {
        this.gameObject.GetComponent<DiceCalculator>().enabled = !this.gameObject.GetComponent<DiceCalculator>().enabled;
    }



}
