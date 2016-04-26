using UnityEngine;
using System.Collections;

public class RoundSystem : MonoBehaviour {

    int round;


	// Use this for initialization
	void Start () {
        round = 0;
	}
	
	// Update is called once per frame
	void Update () {
	


	}


    void nextRound()
    {
        round++;
        if (round == 0)
        {
            //CycleSystem.stuff Where we start with planning the first few assignments
        }
        if(round == 1)
        {
            //CycleSystem.Otherstuff Where we start from analyse
        }
        if (round == 2)
        {
            //CycleSystem.stuff Start at development
        }
        if (round == 3)
        {
            //CycleSystem.Otherstuff Start at Test
        }
        if (round > 3)
        {
            //CycleSystem.stuff Start at deploy
        }
    }


}
