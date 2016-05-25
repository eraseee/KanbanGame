using UnityEngine;
using System.Collections;

public class Testmovement : MonoBehaviour {

    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float h = speed * Input.GetAxis("Horizontal");
        float v = speed * Input.GetAxis("Vertical");
        transform.Translate(h, 0, v);    
	}
}
