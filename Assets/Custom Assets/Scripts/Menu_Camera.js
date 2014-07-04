#pragma strict

function Start () {

}
var target : float;
var speed = 200.0;
var doneAnimation = true;
 
	
function Update () {
	
	var angle : float = Mathf.MoveTowardsAngle
			(transform.eulerAngles.x, target, speed * Time.deltaTime);
	transform.rotation = Quaternion.Euler(angle,0,0); 
	/*var angle : float = Mathf.MoveTowardsAngle
			(transform.eulerAngles.x, target, speed * Time.deltaTime);
		transform.eulerAngles = Vector3(angle, 0, 0);
		*/
	//Debug.Log("target=" + target);
	
	if(target == 0.0) {
		Debug.Log("target=" + target);
		var linkToScript = GameObject.Find("Main Menu Light").GetComponent(Menu_Light);
	 		linkToScript.activate = true;
	 		GameObject.Find("Main Menu Light").collider.isTrigger = true;
	 		
		}	
	if(target == 270.0) {
		var linkToScript2 = GameObject.Find("Options Menu Light").GetComponent(Options_Light);
	 		linkToScript2.activate = true;
	 		//Debug.Log("angle=" + angle);
		}
	if (angle == target) {
		doneAnimation = true;
	}

}

function ToOptions(){
	target = 270.0;
	doneAnimation = false;
}

function ToMain(){
	target = 0.0;
	doneAnimation = false;
}