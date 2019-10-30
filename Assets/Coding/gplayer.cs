using UnityEngine;
using System.Collections;


public class gplayer : MonoBehaviour {


    public static bool isObst;





    void OnCollisionEnter(Collision coll) {



       if(coll.collider.tag=="coll"){
						
           if(isObst)
			    rigidbody.velocity = transform.TransformDirection(0,Random.Range(17.0f,55.0f),0);
           else
               rigidbody.velocity = transform.TransformDirection(0, Random.Range(15.0f, 60.0f), 0);
		}
    
    
    }




}
