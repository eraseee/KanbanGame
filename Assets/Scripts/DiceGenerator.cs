using UnityEngine;
using System.Collections;

public class DiceGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void startGenerator()
    {
        randomGenerator();
    }


    int randomGenerator()
    {
        float rng =  Random.Range(2, 18);
        int tmp = Mathf.CeilToInt(rng / 3);
        print(tmp);
        return tmp;
    }



}
