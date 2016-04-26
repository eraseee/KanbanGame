using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiceGenerator : MonoBehaviour {

    public Texture[] textures;
    Transform diceToRoll;
    List<Transform> TEST;
    List<Dice> ana;

    // Use this for initialization
    void Start () {
        ana = new List<Dice>();
        TEST = new List<Transform>();
        List<Dice> dev = new List<Dice>();
        List<Dice> test = new List<Dice>();
        List<Dice> deploy = new List<Dice>();
    }
	
    


	// Update is called once per frame
	void Update () {
	    
	}

    // Handler for generating the new numbers and the acquiring the new textures for the dice.

    public void startGenerator()
    {
        print("DiceGenerator called");
        /* Generator, looks for all elements under each category, e.g. dice_assing -> Analysis -> Dice_ana + others assigned to this category.
         * WORK RELATED NEEDS TO BE DELETED AFTER COMPLETION:
         * Test for one category and it should work for all categories, Assignment and the category used for the call will be determined by the round system.
         * 
         * Assignment system will be worked on after round system, to make sure this system works before advancing it to handle assignments in different categories.
         *  
         */
        // if(cycle == analysis) { for(int i = 0; i<gameObject.transform.childCount; i++){
        for (int i = 0; i < gameObject.transform.GetChild(0).childCount; i++)
        {
            print("number of children: " + gameObject.transform.GetChild(0).childCount);
            diceToRoll = this.gameObject.transform.GetChild(i);
            TEST.Add(diceToRoll.transform.GetChild(i));
            Dice TESTING = TEST[i].gameObject.GetComponent<Dice>();
            int roll = randomGenerator();
            TESTING.numberChange(textures[roll - 1]);
            TEST.Clear();
        }
        //} }
    }

    // Generates a random number between 1 and 6.
    int randomGenerator()
    {
        float rng =  Random.Range(2, 18);
        int tmp = Mathf.CeilToInt(rng / 3);
        print(tmp);
        return tmp;
    }



}
