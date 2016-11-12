using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{

    public Transform player;
    public Rigidbody2D playerRB;
    
    public float velAdjustment;

    // Should check status of other portal
    public bool portalOpenLeft;
    public bool portalOpenRight;
    public bool portalOpenUp;
    public bool portalOpenDown;

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
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (charInThisPortal == true)
        {
            if (portalOpenUp)
            {
                Vector3 temp = othrPortal.position;
                temp.y = temp.y + 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);
                playerRB.velocity = playerRB.transform.up * playerRB.velocity.magnitude;
            }

            if (portalOpenDown)
            {
                Vector3 temp = othrPortal.position;
                temp.y = temp.y - 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);
                playerRB.velocity = playerRB.transform.up * playerRB.velocity.magnitude;
            }

            if (portalOpenLeft)
            {
                Vector3 temp = othrPortal.position;
                temp.x = temp.x - 1;
                temp.y = temp.y + 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);
                playerRB.AddForce(new Vector2(velAdjustment * playerRB.velocity.y, 0f));
            }

            if (portalOpenRight)
            {
                Vector3 temp = othrPortal.position;
                temp.x = temp.x + 1;
                temp.y = temp.y + 1;
                player.position = new Vector3(temp.x, temp.y, temp.z);
                playerRB.AddForce(new Vector2(velAdjustment * -playerRB.velocity.y, 0f));

            }
        }
    }

    void Update()
    {

    }
}
