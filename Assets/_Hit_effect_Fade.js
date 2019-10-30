private var time_ : float;
var time_to_fade : float;


function Start ()
{
time_ = Time.time;
}

function Update () 
{
	
	
		transform.localScale = new Vector3(0,0,0);
		
		
		guiTexture.color.a = Mathf.Cos((Time.time - time_)*((Mathf.PI/2)/time_to_fade));
		
		Destroy (gameObject,time_to_fade);

		
}