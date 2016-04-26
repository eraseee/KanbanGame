using UnityEngine;
using System.Collections;

public class DiceAssignment : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void assignAnalysis()
    {
        Transform temp = gameObject.transform.parent.parent;
        Transform newParent = temp.GetChild(0);
        this.gameObject.transform.SetParent(newParent);
        //print(gameObject.transform.parent.parent.name); 
    }

    public void assingDevelopment()
    {
        Transform temp = gameObject.transform.parent.parent;
        Transform newParent = temp.GetChild(1);
        this.gameObject.transform.SetParent(newParent);
        //print(gameObject.transform.parent.parent.name); 
    }

    public void assingTest()
    {
        Transform temp = gameObject.transform.parent.parent;
        Transform newParent = temp.GetChild(2);
        this.gameObject.transform.SetParent(newParent);
        //print(gameObject.transform.parent.parent.name); 
    }

    public void assingDeploy()
    {
        Transform temp = gameObject.transform.parent.parent;
        Transform newParent = temp.GetChild(3);
        this.gameObject.transform.SetParent(newParent);
        //print(gameObject.transform.parent.parent.name); 
    }

}
