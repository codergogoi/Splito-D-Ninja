using UnityEngine;
using System.Collections;

public class _loadingAnimAutoplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.animation.Play("patrolanimation");
		transform.animation.wrapMode = WrapMode.Loop;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
