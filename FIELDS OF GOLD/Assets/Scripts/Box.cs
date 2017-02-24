using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    BoxData boxData;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setBoxData(int x, int y, int z)
    {
        boxData = new BoxData(x, z);
        boxData.setHeight(y);
    }
}
