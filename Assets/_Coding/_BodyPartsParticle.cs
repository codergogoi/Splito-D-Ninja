using UnityEngine;
using System.Collections;

public class _BodyPartsParticle : MonoBehaviour {
	
	public AudioClip CrashSound;
	
	public GameObject[] parts;

	// Use this for initialization
	void Start () {
		
		
		
		for(int i = 0; i < 11; i++){
			
			GameObject go1 = Instantiate(parts[i],transform.position,transform.rotation) as GameObject;
			go1.rigidbody.velocity = new Vector3(Random.Range(5,20),Random.Range(5,20),Random.Range(5,20));
		}
		
		audio.PlayOneShot(CrashSound);
		
		Destroy(gameObject,3.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDestroy(){
		
		//instantiate gameover menu
		
	}
}
