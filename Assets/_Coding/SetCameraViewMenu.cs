using UnityEngine;
using System.Collections;

public class SetCameraViewMenu : MonoBehaviour {
	
	private float height,width;
	
	public Camera MainCamera;
	
	public GameObject iPadBg,iPhoneBg;
	
	// Use this for initialization
	void Start () {
		
		height = Screen.height;
		width = Screen.width;
		
		if(width == 1136){
			iPhoneBg.SetActive(true);
			iPadBg.SetActive(false);
			MainCamera.camera.orthographicSize = 19.94f;
			//MainCamera.camera.transform.position = new Vector3(-15.7f,11.8f,-20.0f);
			
		}else {
			iPhoneBg.SetActive(false);
			iPadBg.SetActive(true);
			MainCamera.camera.orthographicSize = 23.29f;
			//MainCamera.camera.transform.position = new Vector3(-15.7f,12.5f,-20.0f);
		}
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
