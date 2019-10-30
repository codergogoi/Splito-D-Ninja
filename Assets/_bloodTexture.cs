using UnityEngine;
using System.Collections;

public class _bloodTexture : MonoBehaviour {
	
	private float height,width;
	
	public GUITexture texture;
	// Use this for initialization
	void Start () {
		
		height = Screen.height;
		width = Screen.width;
		
		texture.pixelInset = new Rect(0,0,width,height);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
