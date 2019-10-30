//#pragma strict

 var TimeToDestroy:float=0.5;
private var time:float=0.0;


function Start()
{
	time=0;
}

function Update () 
{
	if(time>TimeToDestroy)
	Destroy(gameObject);
	
	
	time+=Time.deltaTime;
	//print(time);

}