using UnityEngine;
using System.Collections;

public class P0rtal : MonoBehaviour {

    private bool openUp;
    private bool openDown;
    private bool openLeft;
    private bool openRight;

    public int getPortalDir()
    {
        if (openUp) return 0;
        else if (openDown) return 1;
        else if (openLeft) return 2;
        else if (openRight) return 3;
        return -1;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
