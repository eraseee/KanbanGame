using UnityEngine;
using System.Collections;

public class TextFollowStory : MonoBehaviour {

    public Transform target;
    

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = target.position;
        this.transform.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToViewportPoint(pos);
    }
}
