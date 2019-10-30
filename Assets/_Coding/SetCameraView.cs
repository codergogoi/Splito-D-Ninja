using UnityEngine;
using System.Collections;

public class SetCameraView : MonoBehaviour {
	
	private float height,width;
	
	public GameObject MainCamera;
	
	// Use this for initialization
	void Start () {
		
		height = Screen.height;
		width = Screen.width;
		
		if(width ==1136){
			print("it is working");
			MainCamera.SendMessage("SetHeight",11.8f);
			MainCamera.camera.orthographicSize = 16f;
			MainCamera.camera.transform.position = new Vector3(-15.7f,11.8f,-20.0f);
			
		}else {
			MainCamera.camera.orthographicSize = 16f;
			MainCamera.camera.transform.position = new Vector3(-15.7f,12.5f,-20.0f);
			MainCamera.SendMessage("SetHeight",12.5f);
		}
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
