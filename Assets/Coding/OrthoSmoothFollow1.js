/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

// The target we are following
var target : Transform;
// The distance in the x-z plane to the target
var distance:float = 10.0;
// the height we want the camera to be above the target
var height:float = 5.0;
// How much we 
var heightDamping:float = 2.0;
var rotationDamping:float = 0.0;
var isClear: boolean  = false;
var isForward : boolean = false;
var timeB: float;
var valB:float;
var isSetB: boolean;

var timeF : float;
var valF: float;
var isSetF: boolean;


//------------------


function Lcomp( x : int){


	isClear = true;


}


function Fdirection(x: int){


	if(x > 1){ 
	
		if(!isForward){
	
			timeF = 0;
			isForward = true;	
			isSetF = true;
		}
	}
	
	else{
		if(isForward){
			timeB = 0;
			 isForward = false;
			isSetB = true;
		}
	}
}







function Start(){

		isClear = false;


}



function LateUpdate () {

	
	


	if(!isClear){

		// Early out if we don't have a target
		if (!target)
			return;
		
		// Calculate the current rotation angles
		var wantedRotationAngle:float = target.eulerAngles.y;
		var wantedHeight:float = target.position.y + height;
			
		var currentRotationAngle:float = transform.eulerAngles.y;
		var currentHeight:float = transform.position.y;
		
		if(isForward){
			
				//Mathf.Lerp(minimum, maximum, Time.time)
				
			//	valF = Mathf.Lerp(0, -3,Time.deltaTime * 50);
			if(isSetF)
			timeF =  timeF + Time.deltaTime *10;
			
			
			if(timeF > 2.9){
				
				isSetF = false;
			
			}
			
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle - timeF, wantedRotationAngle, rotationDamping * Time.deltaTime);
				
			
			}
		else{
		
			
			if(isSetB)
			timeB =  timeB + Time.deltaTime *10;
			
			
			if(timeB > 2.9){
				
				isSetB = false;
			
			}
		
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle + timeB, wantedRotationAngle, rotationDamping * Time.deltaTime);
			// Damp the height
			}
			
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
	
		// Convert the angle into a rotation
		 var currentRotation:Quaternion = Quaternion.Euler (0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
	
		// Set the height of the camera
		transform.position.y = currentHeight;
		
		// Always look at the target
		//transform.LookAt (target);
	}
}