using UnityEngine;
using System.Collections;

public class _baseDestroy : MonoBehaviour {
	
	private float des_time;
	private float tm;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		tm += Time.deltaTime;
		
		if(tm > 15.0f){
			
			Destroy(gameObject);
		}
		
	}
}
