using UnityEngine;
using System.Collections;

public class buttonEffect : MonoBehaviour {

    private float tm;

    private float val, valx;


    
    void Start () {
	
	}
	
	void Update () 
	{

        tm += Time.deltaTime;

        if (tm > 0.6F) {
			
			val = Mathf.Clamp(0.0f,0.03f, Time.deltaTime);
            valx = Mathf.Clamp(0.0f,0.08f, Time.deltaTime);
            transform.localScale = new Vector3(val, valx, 0);
            StartCoroutine(WaitForNormal(0.2f));
        
        }else{
			
			val = Mathf.Clamp(0.05f,0.0f, Time.smoothDeltaTime/50);
			 transform.localScale = new Vector3(val, val, 0);
		}

	}
	
	
	IEnumerator WaitForNormal(float waitTime){
		
		
		yield return new WaitForSeconds(waitTime);
		
		tm = 0;
		
	}
	
}