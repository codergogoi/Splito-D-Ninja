using UnityEngine;
using System.Collections;

public class jump_message : MonoBehaviour {
	
	public static bool isTrue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(isTrue){
		
			SendMessage("JumpAction",2);
			isTrue = false;
		}
	}
	
	
}
