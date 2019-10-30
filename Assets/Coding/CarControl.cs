using UnityEngine;
using System.Collections;
//using UnityEditor;

public class CarControl : MonoBehaviour 
{
	
	
	public float speed;
	
	void Awake(){
		
		
		
		
	}
	
	
	void Start(){
		
		
	
	}

	// Update is called once per frame
	void Update () 
	{
		
		Vector3 dir = Vector3.zero;
	
		
		dir.x = Input.acceleration.x;
		
		
		
		if(dir.sqrMagnitude > 1)
				
			dir.Normalize();
			
		dir *= (Time.deltaTime * speed);
		
		transform.Translate(dir);
		
		
		
		
		
		
	}
	

}

