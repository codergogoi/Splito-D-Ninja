using UnityEngine;
using System.Collections;

public class _CanonController : MonoBehaviour {

	private Ray ray;
	private RaycastHit hit;
	
	public Transform GunPoint;
	public GameObject Projectile;
	public LayerMask lm;

	private bool isFire;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		
	
		
		if (Physics.Raycast(transform.position,Vector3.left, out hit,40,lm)){
			
			Debug.DrawLine(transform.position,hit.point,Color.red);
			
			
			if(hit.collider.tag=="Player" && !isFire){
				isFire = true;
				StartCoroutine(waitForFire(0.3f));
				//suricanPoint.LookAt(hit.point);
				GameObject go = Instantiate(Projectile, GunPoint.position, Quaternion.identity) as GameObject;
				go.rigidbody.AddForce(GunPoint.forward * 5000);
			}
			
			
			
		}

	
	}


	IEnumerator waitForFire(float tm){

		yield return new WaitForSeconds(tm);

		isFire = false;


	}
}
