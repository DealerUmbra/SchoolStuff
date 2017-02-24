using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

    public Box boxPrefab;
    public int size;
    public int seed;
    public int maxHeight;
    public int flattenValue;
    int[,] gridHeights;


    public enum Direction { Up, Same, Down };

    Direction[] travel;
    Direction travelFirst;

    // Use this for initialization
    void Start() {
        gridHeights = new int[size, size];
        travelFirst = Direction.Up;
        travel = new Direction[size];
        int flattenZ = seed % size;
        int flattenX = (seed - flattenZ) / size;
        gridHeights[0, 0] = 1;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i == 0) {
                    if (travelFirst == Direction.Up)
                    {
                        gridHeights[i, j] = gridHeights[i, Mathf.Max(j - 1, 0)] + 1;
                    }
                    else
                        gridHeights[i, j] = gridHeights[i, Mathf.Max(j - 1, 0)] - 1;

                    if (gridHeights[i, j] == maxHeight) {
                        for(int k = 0; k < flattenValue; k++)
                        {
                            gridHeights[i, j + k] = gridHeights[i, j - 1];
                            travel[j + k] = Direction.Same;
                        }
                        j += flattenValue;
                        travelFirst = Direction.Down;
                        travel[j] = Direction.Down; }
                    else if (gridHeights[i, j] == 0) { travelFirst = Direction.Up; travel[j] = Direction.Up; }
                }
                else
                {
                    if (travel[j] == Direction.Up)
                    {
                        gridHeights[i, j] = gridHeights[i - 1, j] + 1;
                    }
                    else
                        gridHeights[i, j] = gridHeights[i - 1, j] - 1;

                    if (gridHeights[i, j] == maxHeight) travel[j] = Direction.Down;
                    else if (gridHeights[i, j] == 0) travel[j] = Direction.Up;
                }
            }
        }

        //Draw the whole valley
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Box box = (Box)Instantiate(boxPrefab, new Vector3(i, gridHeights[i, j], j), Quaternion.identity);
                box.setBoxData(i, gridHeights[i, j], j);
            }
        }


    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
