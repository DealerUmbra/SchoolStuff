using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    CharacterController cc;
    Vector3 direction;
    public int speed = 6;

	// Use this for initialization
	void Start () {

        cc = GetComponent<CharacterController>();
        direction = new Vector3(0, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction.Normalize();

        cc.Move(direction * speed * Time.deltaTime);
	}
}
