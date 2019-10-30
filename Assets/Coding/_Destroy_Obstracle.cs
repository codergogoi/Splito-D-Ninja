using UnityEngine;
using System.Collections;

public class _Destroy_Obstracle : MonoBehaviour {
	
	private float tm;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		tm += Time.deltaTime;
		
		
		if(tm > 10.0f){
			
			Destroy(gameObject);
			
		}
	}
}
