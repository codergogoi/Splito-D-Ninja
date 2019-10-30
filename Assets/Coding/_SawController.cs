using UnityEngine;
using System.Collections;

public class _SawController : MonoBehaviour {
	
	private float moveSpeed;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,5.0f);
		moveSpeed = Random.Range(5,15);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
		
	
	}
}
