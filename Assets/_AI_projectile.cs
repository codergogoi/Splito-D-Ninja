using UnityEngine;
using System.Collections;

public class _AI_projectile : MonoBehaviour {
	
	
	public GameObject projectile;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(transform.position.x,17.0f,transform.position.z);
		/*
		tm+= Time.deltaTime * 2;
		
		if(tm > Random.Range(5,12)){
			
			//GameObject go = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			//go.rigidbody.AddForce(transform.forward * 1000);
			//go.rigidbody.velocity = new Vector3(Random.Range(-5,-15),Random.Range(5,20),0);
			//go.rigidbody.velocity = new Vector3(0,Random.Range(20,50),Random.Range(30,70));
			tm = 0;
			
		}
		*/
	
	}
}
