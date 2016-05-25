using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class cycleText : MonoBehaviour {

    CycleSystem cycle;

	// Use this for initialization
	void Start () {
        cycle = GameObject.Find("CycleSystem").GetComponent<CycleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cycle.stateAna)
        {
            this.GetComponent<Text>().text = "Analyse";
        }
        if (cycle.stateDev)
        {
            this.GetComponent<Text>().text = "Development";
        }
        if (cycle.stateTest)
        {
            this.GetComponent<Text>().text = "Test";
        }
        if (cycle.stateDeploy)
        {
            this.GetComponent<Text>().text = "Deploy";
        }
        if(!cycle.stateAna && !cycle.stateDeploy && !cycle.stateDev && !cycle.stateTest)
        {
            this.GetComponent<Text>().text = "Planning";
        }
	}
}
