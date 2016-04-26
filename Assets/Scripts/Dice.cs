using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {


    [HideInInspector]
    public string number;

    //public TextAsset imageAsset;

    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}


    //Replace current texture with a new texture.
    public void numberChange(Texture tex) {
        rend.material.mainTexture = tex;
    }

}
