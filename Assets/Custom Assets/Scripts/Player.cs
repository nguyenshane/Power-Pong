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
	public float maxSize;
	public float minSize;
	public ePlayer player;
	

	void Start() {

	}

	// Update is called once per frame
	void Update () {
		if (player == ePlayer.Left) {
			inputSpeed = Input.GetAxisRaw("PlayerLeft");
		} else if (player == ePlayer.Right) {
			inputSpeed = Input.GetAxisRaw("PlayerRight");
		}

		transform.position += new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);
	}

	public void increaseSize(float size) {
		if (transform.localScale.z + size > maxSize) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.z, maxSize);
		else if (transform.localScale.z + size < minSize) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.z, minSize);
		else transform.localScale += new Vector3(0, 0, size);
	}
}