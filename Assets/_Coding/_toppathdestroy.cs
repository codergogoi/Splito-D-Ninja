using UnityEngine;
using System.Collections;

public class _toppathdestroy : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
		Destroy(gameObject,20);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
			
		
	
	}
	
	
	void OnTriggerEnter(Collider coll){
		
		print(coll);
		
		
	}
}
