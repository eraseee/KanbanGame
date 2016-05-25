using UnityEngine;
using System.Collections;

public class WIPLimit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(this.gameObject.tag == "Planning")
        {
            limitPlan();
        }

        if(this.gameObject.tag == "Analyse")
        {
            limitAna();
        }

        if (this.gameObject.tag == "Development")
        {
            limitDev();
        }

        if (this.gameObject.tag == "Test")
        {
            limitTest();
        }

        if(this.gameObject.tag == "Deploy")
        {
            limitDeploy();
        }



	}


    void limitAna()
    {
        if(this.gameObject.transform.childCount >= 2)
        {
            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
            }
            GameObject tmp = GameObject.FindGameObjectWithTag("Planning");
            tmp.GetComponent<DropZone>().enabled = false;
            for (int i = 0; i < tmp.transform.childCount; i++)
            {
                tmp.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
            }
        }
    }


    void limitDev()
    {
        if (this.gameObject.transform.childCount >= 3)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
            }
            GameObject tmp = GameObject.Find("Ana_done");
            tmp.GetComponent<DropZone>().enabled = false;
            for (int i = 0; i < tmp.transform.childCount; i++)
            {
                tmp.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
            }
        }
    }


    void limitTest()
    {
        if (this.gameObject.transform.childCount >= 2)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
            }
            GameObject tmp = GameObject.Find("Dev_done");
            tmp.GetComponent<DropZone>().enabled = false;
            for (int i = 0; i < tmp.transform.childCount; i++)
            {
                tmp.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
            }
        }
    }



    void limitDeploy()
    {
        if (this.gameObject.transform.childCount >= 1)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
            }
            GameObject tmp = GameObject.Find("Test_done");
            tmp.GetComponent<DropZone>().enabled = false;
            for (int i = 0; i < tmp.transform.childCount; i++)
            {
                tmp.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
            }
        }
    }

    void limitPlan()
    {
        if (this.gameObject.transform.childCount >= 5)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).GetComponent<Draggable>().enabled = true;
            }
            GameObject tmp = GameObject.FindGameObjectWithTag("Backlog");
            tmp.GetComponent<DropZone>().enabled = false;
            for (int i = 0; i < tmp.transform.childCount; i++)
            {
                tmp.transform.GetChild(i).GetComponent<Draggable>().enabled = false;
            }
        }
    }



}
