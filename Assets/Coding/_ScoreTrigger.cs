using UnityEngine;
using System.Collections;

public class _ScoreTrigger : MonoBehaviour {

	private int Score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void OnTriggerEnter(Collider coll){
		
		
		if(coll.collider.tag == "axe"){
			
			Score+= 1;
			
			print(Score);
			
		}	
		
		
	}
		
	
}
