using UnityEngine;
using System.Collections;

public class TogglePanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle_Panel()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }


}
