/*! 
 *  \brief     Portal Gun class
 *  \details   This class is used to determine the vectors of the portal gun
 *  \author    Ninetendo
 */

using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour
{
    /**
    * A Portal type to represent the blue portal
    */ 
    public Portal bluePortal;

    /**
    * A Portal type to represent the orange portal
    */ 
    public Portal orangePortal;

    /**
    * A Collider2D type to represent the blue portal's collider
    */ 
    public Collider2D bluePortalColl;

    /**
    * A Collider2D type to represent the orange portal's collider
    */ 
    public Collider2D orangePortalColl;

    /**
    * A BoxCollider2D type to represent the vertical surfaces
    */ 
    public BoxCollider2D vertColl;

    /**
    * A BoxCollider2D type to represent the horizontal surfaces
    */ 
    public BoxCollider2D horiColl;

    /**
    * A LayerMask type to designate game objects that can have a portal placed on them
    */ 
    public LayerMask toHit;

    /**
    * A Transform type to represent the firing point of the portal gun
    */ 
    private Transform gunPoint;

    /**
     * Calculates the line between the gun point and the cursor and fires a portal at
     * the point of collision as long as its valid
     * @param portalColor Determines which color portal is being fired
     */ 
    void Shoot(int portalColor) // 0 shoots a blue portal. 1 shoots an orange portal
    {
        // Gets mouse x and y coords
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                       Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        // Gets starting point of portal guns x and y coords
        Vector2 gunPointPos = new Vector2(gunPoint.position.x, gunPoint.position.y);

        // The vector between the gun point and the mouse point
        Vector2 aimDirection = mousePos - gunPointPos;

        // The point where the line between the mouse point and gun point hits a surface
        RaycastHit2D hit = Physics2D.Raycast(gunPointPos, aimDirection, 100, toHit);

        if (portalColor == 0)   // If shooting blue portal
        {
            Debug.DrawLine(gunPointPos, aimDirection * 100, Color.blue);
            if (hit.collider != null)   // Checks if there is a surface being hit
            {
                GameObject.Find("Orange Portal").GetComponent<Collider2D>().isTrigger = true;
                if (hit.collider.gameObject.layer == 9) // Check if surface is considered horizontal
                {
                    // Positions the portal according to the line between gun point and surface
                    bluePortal.thisPortal.position = new Vector3(hit.point.x - 0.8f, hit.point.y, 0);
                    bluePortal.thisPortal.localEulerAngles = new Vector3(0f, 0f, 0f);

                    // set booleans
                    if (aimDirection.y < 0) // Check if the portal should be facing upwards
                    {
                        bluePortal.portalOpenRight = false;
                        bluePortal.portalOpenDown = false;
                        bluePortal.portalOpenUp = true;
                        bluePortal.portalOpenLeft = false;
                    }
                    else if (aimDirection.y > 0)    // Check if the portal should be facing downwards
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
                    
                    if (aimDirection.x < 0) // Check if the portal is facing right
                    {
                        bluePortal.portalOpenRight = true;
                        bluePortal.portalOpenDown = false;
                        bluePortal.portalOpenUp = false;
                        bluePortal.portalOpenLeft = false;
                    }
                    else if (aimDirection.x > 0) // Check if the portal is facing left
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
            if (hit.collider != null)   // Checks if there is a surface to be hit
            {
                GameObject.Find("Blue Portal").GetComponent<Collider2D>().isTrigger = true;
                if (hit.collider.gameObject.layer == 9) // Check if surface is considered horizontal
                {
                    // Positions and orients the portal correctly
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

    /**
    * Method to initalize the portals as unactivted
    */ 
    void Start()
    {
        GameObject.Find("Blue Portal").GetComponent<Collider2D>().isTrigger = false;
        GameObject.Find("Orange Portal").GetComponent<Collider2D>().isTrigger = false;
    }

    /**
    * Method to set the gun point coordinates appropriately
    */ 
    void Awake()
    {
        gunPoint = transform.FindChild("GunPoint");
    }

    /*
     * Method that calls once per frame
     * Constantly checking the vector between the gun point and mouse cursor
     * and waiting for mouse inputs to fire portals
     */
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

    /**
     * Method that calls less frequently than once per frame
     * Checks the positions and orientations of the portals and whether
     * or not Mario is in a portal or not
     */
    void FixedUpdate()
    {
        bluePortal.teleport(orangePortal);
        orangePortal.teleport(bluePortal);
    }
}
