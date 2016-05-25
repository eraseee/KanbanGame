using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    Renderer rend;

    // Use this for initialization
    void Start () {
        //rend = this.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}


    //Replace current texture with a new texture.
    public void numberChange(Texture tex) {
        this.gameObject.GetComponent<RawImage>().texture = tex;
    }

}
