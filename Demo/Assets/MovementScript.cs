using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    public int speed = 6;
    Vector3 direction;
    CharacterController controller;

    // Use this for initialization
	void Start () {
        direction = new Vector3();
        controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        direction = CalculateDirection(direction);

        controller.Move(direction * speed * Time.deltaTime);
	}

    Vector3 CalculateDirection(Vector3 direction) {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction.Normalize();

        return direction;
    }
}
