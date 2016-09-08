using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FateData : MonoBehaviour {

	public string name;
	Camera c; 
	public Text nameText;

	// Use this for initialization
	void Start () {
		c = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		Vector3 screenPosition = c.WorldToScreenPoint (transform.position + new Vector3 (0, 4, 0));
		//print (screenPosition.x + "/" + screenPosition.y + "/" + screenPosition.z);
		//print (name + ":" + nameText.rectTransform.position.x);
		nameText.text = name;
		nameText.rectTransform.Translate (screenPosition - nameText.rectTransform.position); 
	}
}
	// Update is called once per frame