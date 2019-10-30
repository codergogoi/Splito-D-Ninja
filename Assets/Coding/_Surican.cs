using UnityEngine;
using System.Collections;

public class _Surican : MonoBehaviour {
	
	private Vector3 target;
	
	private Ray ray;
	private RaycastHit hit;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject,1.0f);
		//target = GameObject.Find();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
		if(Input.GetKeyUp("mouse 0")){
			
			if(Physics.Raycast(ray, out hit,500)){
				
				target = hit.point;
				
			}
		}
		////transform.position = Vector3.Lerp(gameObject.transform.position,target,Time.deltaTime * 10);
		//transform.LookAt(target);
		
	
	}
	
	
	void OnCollisionEnter(Collision coll){
		
		
		
	}
}
