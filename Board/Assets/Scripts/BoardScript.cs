using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour {

    public int spaceSize = 20;
    public int tileCount = 64;

    public int seed = 10000;
    public Transform[] tilePrefabs;

    int[,] boardSpace;


	// Use this for initialization
	void Start () {
        boardSpace = new int[spaceSize, spaceSize];
        int filterSeed = seed % (spaceSize * spaceSize);
        int startZ = filterSeed % spaceSize;
        int startX = (filterSeed - startZ) / spaceSize;
        print(startX + "/" + startZ);
        boardSpace[startX, startZ] = 1;
        tileCount--;
        int curX = startX; int curZ = startZ;
        while(tileCount > 0)
        {
            int newTile = 3 - boardSpace[curX, curZ];
            switch(tileCount % 3)
            {
                case 0:
                    curX = Mathf.Min(spaceSize - 1, curX + seed % 2);
                    break;
                case 2:
                    curZ = Mathf.Min(spaceSize - 1, curZ + seed % 2);
                    break;
                case 1:
                    curX = Mathf.Max(0, curX - seed % 2);
                    break;
            }
            if(boardSpace[curX, curZ] == 0)
            {
                boardSpace[curX, curZ] = newTile;
            }
            tileCount--;
        }

        for(int i=0; i < spaceSize; i++)
        {
            for(int j=0; j < spaceSize; j++)
            {
                if(boardSpace[i,j] > 0)
                {
                    Transform boardTile = (Transform)Instantiate(tilePrefabs[boardSpace[i, j] - 1], new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
