#pragma strict

function Start () {

}

function Update () {
	var target = 270.0;
	var speed = 45.0;
	var angle : float = Mathf.MoveTowardsAngle
			(transform.eulerAngles.y, target, speed * Time.deltaTime);
		transform.eulerAngles = Vector3(angle, 0, 0);

}

function ToOptions(){

}