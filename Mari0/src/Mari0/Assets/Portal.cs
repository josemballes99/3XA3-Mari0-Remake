using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public Transform player;
    public Transform thisPortal;
    public Transform othrPortal;

    public bool charInThisPortal;

    void OnTriggerEnter2D(Collider2D other)
    {
        charInThisPortal = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        charInThisPortal = false;
    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (charInThisPortal == true)
        {

            player.position = othrPortal.position;
        }
	}
}
