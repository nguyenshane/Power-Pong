#pragma strict

function Start () {

}

var target = 0;
var speed = 45.0;
var doneAnimation = true;
	
function Update () {

	var angle : float = Mathf.MoveTowardsAngle
			(transform.eulerAngles.x, target, speed * Time.deltaTime);
		transform.eulerAngles = Vector3(angle, 0, 0);
	if (angle == target) doneAnimation = true;

}

function ToOptions(){
	target = 270;
	doneAnimation = false;
}