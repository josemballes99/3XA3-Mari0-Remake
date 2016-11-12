using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour {

    public Transform bluePortal;
    public Transform orangePortal;

    public Collider2D bluePortalColl;
    public Collider2D orangePortalColl;

    // Used to select game objects that can have a portal placed on them
    public LayerMask toHit;

    private Transform gunPoint;

    // Keep track of portal position


    void Shoot(int portalColor) // 0 shoots a blue portal. 1 shoots an orange portal
    {
        // Gets mouse x and y coords
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                       Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        // Gets starting point of portal guns x and y coords
        Vector2 gunPointPos = new Vector2(gunPoint.position.x, gunPoint.position.y);

        Vector2 aimDirection = mousePos - gunPointPos;

        RaycastHit2D hit = Physics2D.Raycast(gunPointPos, aimDirection, 100, toHit);

        Debug.Log("aim dir is: " + mousePos.ToString());

        if (portalColor == 0)
        {
            Debug.DrawLine(gunPointPos, aimDirection * 100, Color.blue);
            if (hit.collider != null)
            {
                bluePortalColl.enabled = true;
                bluePortal.position = new Vector3(hit.point.x, hit.point.y, 0);
            }
        }

        else if (portalColor == 1)
        {
            Debug.DrawLine(gunPointPos, aimDirection * 100, Color.yellow);
            if (hit.collider != null)
            {
                orangePortalColl.enabled = true;
                orangePortal.position = new Vector3(hit.point.x, hit.point.y, 0);
            }
        }

        // Gives player a line to allow the player to see what they are aiming at
        if (hit.collider == null)
            Debug.DrawLine(gunPointPos, aimDirection * 100, Color.white);
        if (hit.collider != null)
        {
            Debug.DrawLine(gunPointPos, hit.point, Color.white);
        }

    }



	// Use this for initialization
	void Start () {
        bluePortalColl.enabled = false;
        orangePortalColl.enabled = false;
	}

    void Awake()
    {
        gunPoint = transform.FindChild("GunPoint");
    }

	// Update is called once per frame
	void Update () {
        Shoot(3);   // Calls the shoot function repeatedly to give player a line to help them aim
        if (Input.GetMouseButtonDown(0))    // Check if LMB is pressed. Will shoot blue portal
        {
            Shoot(0);
        }
        if (Input.GetMouseButtonDown(1))    // Check if RMB is pressed. Will shoot orange portal
        {
            Shoot(1);
        }
	}
}
