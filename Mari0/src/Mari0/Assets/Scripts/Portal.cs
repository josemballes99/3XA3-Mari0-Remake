using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{

    public Transform player;
    public Rigidbody2D playerRB;

    GameObject[] portable;

    public float velAdjustment;

    // Should check status of other portal
    public bool portalOpenLeft;
    public bool portalOpenRight;
    public bool portalOpenUp;
    public bool portalOpenDown;

    public Transform thisPortal;
    public Transform othrPortal;

    public bool isInPortal;

    void OnTriggerEnter2D(Collider2D other)
    {
      //  if (other.GetComponent<Collider>().gameObject.tag == "Portable")
      //  {
            isInPortal = true;
       // }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isInPortal = false;
    }

    // Use this for initialization
    void Start()
    {
        // Finds all objects in game that can enter and exit a portal

        portable = GameObject.FindGameObjectsWithTag("Portable");
    }

    public void teleport(Portal other)
    {
        if (this.isInPortal == true)
        {
            if (other.portalOpenUp)
            {
                //Vector3 temp = othrPortal.position;
                Vector3 temp = other.thisPortal.position;
                temp.y = temp.y + 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);
                playerRB.velocity = playerRB.transform.up * playerRB.velocity.magnitude;
            }

            if (other.portalOpenDown)
            {
                //Vector3 temp = othrPortal.position;
                Vector3 temp = othrPortal.position;
                temp.y = temp.y - 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);
                playerRB.velocity = playerRB.transform.up * playerRB.velocity.magnitude;
            }

            if (other.portalOpenLeft)
            {
                //Vector3 temp = othrPortal.position;
                Vector3 temp = othrPortal.position;
                temp.x = temp.x - 1;
                temp.y = temp.y + 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);
                if (this.portalOpenDown)
                {
                    playerRB.AddForce(new Vector2(velAdjustment * playerRB.velocity.y, 300f));
                }
                if (this.portalOpenLeft)
                {
                    //playerRB.AddForce(new Vector2(velAdjustment * playerRB.velocity.x, 700f));
                    playerRB.velocity = -10 * playerRB.transform.right * playerRB.velocity.x;
                }
            }

            if (other.portalOpenRight)
            {
                //Vector3 temp = othrPortal.position;
                Vector3 temp = othrPortal.position;
                temp.x = temp.x + 1;
                temp.y = temp.y + 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);
                if (this.portalOpenDown)
                {
                    playerRB.AddForce(new Vector2(velAdjustment * playerRB.velocity.y, 300f));
                }
                if (this.portalOpenRight)
                {
                    //playerRB.AddForce(new Vector2(velAdjustment * playerRB.velocity.x, 700f));
                    playerRB.velocity = -10 * playerRB.transform.right * playerRB.velocity.x;

                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void Update()
    {

    }
}
