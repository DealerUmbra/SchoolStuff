using UnityEngine;
using System.Collections;

public struct BoxData {

    int x;
    int y;
    int z;

	// Use this for initialization
	public BoxData(int x, int z)
    {
        this.x = x;
        this.y = 0;
        this.z = z;
    }

    public void setHeight(int y)
    {
        this.y = y;
    }

    public int X { get { return x; } }

    public int Y { get { return y; } }

    public int Z { get { return z; } }
}
