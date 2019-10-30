using UnityEngine;
using System.Collections;

public class RoadControl : MonoBehaviour {
	
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 down = transform.TransformDirection (Vector3.up);
			
		if (Physics.Raycast (transform.TransformPoint(0,0,0),down,out hit,100F)) {
			
			
			print(hit.collider.gameObject.name);
			
			}
			
	
	}
}
