using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public GUITexture ResumeBtn,ExitBtn,bg;
	
	private float height,width;
	private bool isResume;
	
	
	// Use this for initialization
	void Start () {
		width = Screen.width;
		height = Screen.height;
		bg.pixelInset = new Rect(0,0,width,height);
		ResumeBtn.pixelInset = new Rect(0,0,width/5,height/10);
		ExitBtn.pixelInset = new Rect(0,0,width/5,height/10);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetMouseButtonDown(0)){
			
				Vector3 pos = Input.mousePosition;
				
				if(ResumeBtn.HitTest(pos)){
					Time.timeScale =1f;
					Destroy(gameObject,0.2f);
					
				}
				
				if(ExitBtn.HitTest(pos)){
					Time.timeScale = 1;
					Application.LoadLevel("_MainMenu");
					
				}
			
			
		}
	
	}
}
