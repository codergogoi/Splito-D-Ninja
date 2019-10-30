using UnityEngine;
using System.Collections;

public class _screenAdjust : MonoBehaviour {
	
	float width,height;
	public GUITexture bg;
	// Use this for initialization
	void Start () {
	
		width = Screen.width;
		height = Screen.height;
		
		bg.pixelInset = new Rect(0,0,width,height);
		
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(Input.GetMouseButtonDown(0)){
			
			
			Vector3 pos = Input.mousePosition;
			
			if(bg.HitTest(pos)){
				
				
				Application.LoadLevel("sample");
			}
			
			
		}
		
	}
}
