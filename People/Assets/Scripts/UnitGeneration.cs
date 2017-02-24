using UnityEngine;
using System.Collections;

public class UnitGeneration : MonoBehaviour {

    public int unitCount = 0;
    public Transform unitPrefab;
    Vector3 unitPosition;
    int radius = 6;
    private IEnumerator frequentUpdates;

    // Use this for initialization
    void Start () {
        unitPosition = new Vector3();
        unitPosition.y = 0.5f;
	for(int i=0; i < unitCount; i++)
        {
            unitPosition.x = Mathf.Cos(i * Mathf.PI / 3) * ((i - i % 6) / 6) * radius;
            unitPosition.z = Mathf.Sin(i * Mathf.PI / 3) * ((i - i % 6) / 6) * radius;

            Transform unit = (Transform)Instantiate(unitPrefab, unitPosition, Quaternion.identity);
            unit.GetComponent<Unit>() = new Unit(i);
            unit.parent = transform;
        }
	}


	
	// Update is called once per frame
	void Update () {
	    
	}
}
