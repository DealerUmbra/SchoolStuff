using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

    public int f_Status;
    public int f_Culture;

    public int o_community;
    public int o_authority;
    public int o_inclusivity;
    public int o_tolerance;
    int id;
    List<int> opinions;

    public Unit(int id)
    {
        f_Status = Random.Range(0, 100);
        f_Culture = Random.Range(1, 4);

        o_community = Random.Range(0, 100); //Opinion modifier toward people of same Culture
        o_authority = Random.Range(0, 100); //Opinion modifier toward people of different Status: positive if higher, negative if lower
        o_inclusivity = Random.Range(0, 100);
        o_tolerance = Random.Range(0, 100);

        this.id = id;
    }

	// Use this for initialization
	void Start () {
        

        opinions = new List<int>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
