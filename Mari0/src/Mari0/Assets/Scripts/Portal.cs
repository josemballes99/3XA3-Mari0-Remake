using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{

    public Transform player;
    public Rigidbody2D playerRB;

    // Checks current status of portal orientation
    public bool portalOpenLeft;
    public bool portalOpenRight;
    public bool portalOpenUp;
    public bool portalOpenDown;

    public Transform thisPortal;
    public Transform othrPortal;

    public bool isInPortal;

    void OnTriggerEnter2D(Collider2D other)
    {
        isInPortal = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isInPortal = false;
    }

    public void teleport(Portal other)
    {
        if (this.isInPortal == true)
        {
            if (other.portalOpenUp)
            {
                Vector3 temp = other.thisPortal.position;
                temp.y = temp.y + 1;
                player.position = new Vector3(temp.x + 0.9f, temp.y, temp.z);
                playerRB.velocity = playerRB.transform.up * playerRB.velocity.magnitude;
            }

            if (other.portalOpenDown)
            {
                Vector3 temp = othrPortal.position;
                temp.y = temp.y - 1;
                player.position = new Vector3(temp.x + 0.9f, temp.y, temp.z);
                playerRB.velocity = -1 * playerRB.transform.up * playerRB.velocity.magnitude;
            }

            if (other.portalOpenLeft)
            {
                Vector3 temp = othrPortal.position;
                temp.x = temp.x - 1;
                temp.y = temp.y + 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);

                if (this.portalOpenUp || this.portalOpenDown)
                {
                    playerRB.velocity = -10 * playerRB.transform.right * Mathf.Abs(playerRB.velocity.y);
                }
                else
                {
                    playerRB.velocity = -3.5f * playerRB.transform.right * Mathf.Abs(playerRB.velocity.x);
                }
            }

            if (other.portalOpenRight)
            {
                Vector3 temp = othrPortal.position;
                temp.x = temp.x + 1;
                temp.y = temp.y + 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);

                if (this.portalOpenUp || this.portalOpenDown)
                {
                    playerRB.velocity = 10 * playerRB.transform.right * Mathf.Abs(playerRB.velocity.y);
                }
                else
                {
                    playerRB.velocity = 3.5f * playerRB.transform.right * Mathf.Abs(playerRB.velocity.x);
                }

            }
        }
    }
}
