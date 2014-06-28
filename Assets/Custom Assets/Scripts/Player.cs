using UnityEngine;
using System.Collections;

public enum ePlayer 
{
	Left,
	Right
}

public class Player : MonoBehaviour {

	public float speed = 15f;
	public float inputSpeed = 0f;
	public ePlayer player;
	

	// Update is called once per frame
	void Update () {
		if (player == ePlayer.Left) {
			inputSpeed = Input.GetAxisRaw("PlayerLeft");
		} else if (player == ePlayer.Right) {
			inputSpeed = Input.GetAxisRaw("PlayerRight");
		}

		transform.position += new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);
	}
}