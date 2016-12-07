using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour
{

    public Portal bluePortal;
    public Portal orangePortal;

    public Collider2D bluePortalColl;
    public Collider2D orangePortalColl;

    public BoxCollider2D vertColl;
    public BoxCollider2D horiColl;

    // Used to select game objects that can have a portal placed on them
    public LayerMask toHit;

    private Transform gunPoint;

    void Shoot(int portalColor) // 0 shoots a blue portal. 1 shoots an orange portal
    {
        // Gets mouse x and y coords
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                       Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        // Gets starting point of portal guns x and y coords
        Vector2 gunPointPos = new Vector2(gunPoint.position.x, gunPoint.position.y);

        Vector2 aimDirection = mousePos - gunPointPos;

        RaycastHit2D hit = Physics2D.Raycast(gunPointPos, aimDirection, 100, toHit);

        if (portalColor == 0)   // If shooting blue portal
        {
            Debug.DrawLine(gunPointPos, aimDirection * 100, Color.blue);
            if (hit.collider != null)
            {
                GameObject.Find("Orange Portal").GetComponent<Collider2D>().isTrigger = true;
                if (hit.collider.gameObject.layer == 9) // Check if surface is considered horizontal
                {
                    bluePortal.thisPortal.position = new Vector3(hit.point.x - 0.8f, hit.point.y, 0);
                    bluePortal.thisPortal.localEulerAngles = new Vector3(0f, 0f, 0f);
                    // set booleans
                    if (aimDirection.y < 0)
                    {
                        bluePortal.portalOpenRight = false;
                        bluePortal.portalOpenDown = false;
                        bluePortal.portalOpenUp = true;
                        bluePortal.portalOpenLeft = false;
                    }
                    else if (aimDirection.y > 0)
                    {
                        bluePortal.portalOpenRight = false;
                        bluePortal.portalOpenDown = true;
                        bluePortal.portalOpenUp = false;
                        bluePortal.portalOpenLeft = false;
                    }
                }
                if (hit.collider.gameObject.layer == 10)    // Check if surface is consdered vertical
                {
                    bluePortal.thisPortal.position = new Vector3(hit.point.x, hit.point.y - 0.8f, 0);    // Vertical portal, offset transform so center of portal is where player aimed at
                    bluePortal.thisPortal.localEulerAngles = new Vector3(0f, 0f, 90f);
                    // Check portal orientation. Is this portal facing left or right?
                    if (aimDirection.x < 0)
                    {
                        bluePortal.portalOpenRight = true;
                        bluePortal.portalOpenDown = false;
                        bluePortal.portalOpenUp = false;
                        bluePortal.portalOpenLeft = false;
                    }
                    else if (aimDirection.x > 0)
                    {
                        bluePortal.portalOpenRight = false;
                        bluePortal.portalOpenDown = false;
                        bluePortal.portalOpenUp = false;
                        bluePortal.portalOpenLeft = true;
                    }
                }

            }
        }

        else if (portalColor == 1)  // If shooting orange portal
        {
            Debug.DrawLine(gunPointPos, aimDirection * 100, Color.yellow);
            if (hit.collider != null)
            {
                GameObject.Find("Blue Portal").GetComponent<Collider2D>().isTrigger = true;
                if (hit.collider.gameObject.layer == 9) // Check if surface is considered horizontal
                {
                    orangePortal.thisPortal.position = new Vector3(hit.point.x - 0.8f, hit.point.y, 0);
                    orangePortal.thisPortal.localEulerAngles = new Vector3(0f, 0f, 0f);
                    // set booleans
                    if (aimDirection.y < 0)
                    {
                        orangePortal.portalOpenRight = false;
                        orangePortal.portalOpenDown = false;
                        orangePortal.portalOpenUp = true;
                        orangePortal.portalOpenLeft = false;
                    }
                    else if (aimDirection.y > 0)
                    {
                        orangePortal.portalOpenRight = false;
                        orangePortal.portalOpenDown = true;
                        orangePortal.portalOpenUp = false;
                        orangePortal.portalOpenLeft = false;
                    }
                }
                if (hit.collider.gameObject.layer == 10)    // Check if surface is considered vertical
                {
                    orangePortal.thisPortal.position = new Vector3(hit.point.x, hit.point.y - 0.8f, 0);    // Vertical portal, offset transform so center of portal is where player aimed at
                    orangePortal.thisPortal.localEulerAngles = new Vector3(0f, 0f, 90f);
                    // Check portal orientation. Is this portal facing left or right?
                    if (aimDirection.x < 0)
                    {
                        orangePortal.portalOpenRight = true;
                        orangePortal.portalOpenDown = false;
                        orangePortal.portalOpenUp = false;
                        orangePortal.portalOpenLeft = false;
                    }
                    else if (aimDirection.x > 0)
                    {
                        orangePortal.portalOpenRight = false;
                        orangePortal.portalOpenDown = false;
                        orangePortal.portalOpenUp = false;
                        orangePortal.portalOpenLeft = true;
                    }
                }
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
    void Start()
    {
        GameObject.Find("Blue Portal").GetComponent<Collider2D>().isTrigger = false;
        GameObject.Find("Orange Portal").GetComponent<Collider2D>().isTrigger = false;
    }

    void Awake()
    {
        gunPoint = transform.FindChild("GunPoint");
    }

    // Update is called once per frame
    void Update()
    {
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

    void FixedUpdate()
    {
        bluePortal.teleport(orangePortal);
        orangePortal.teleport(bluePortal);
    }
}
