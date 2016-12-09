using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {


	/**
	 * A bool type
	 */
    public bool isKilled;

	/**
	 * A float type
	 */
	public float walkSpeed = 2.0f;

	/**
	 * A float type
	 */
	public float wallLeft = 22.0f;

	/**
	 * A float type
	 */
	public float wallRight = 48.0f;

	/**
	 * A float type
	 */
	float walkingDirection = 1.0f;

	/**
	 * A Vector3 type
	 */
	Vector3 walkAmount;

	/**
	 * Method to start the enemy movement
	 */
	void Start () {
		Update();
	}
	
	/**
	 * Method called once per frame, and updates the enemy movement
	 */
	void Update () {

		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if (walkingDirection > 0.0f && transform.position.x >= wallRight){
			walkingDirection = -1.0f;
		}else if (walkingDirection < 0.0f && transform.position.x <= wallLeft){
			walkingDirection = 1.0f;
		}
			
		transform.Translate(walkAmount);
	
	}

	/**
     * Method to check if Mario hits an enemy and kills the enemy if coming from above
     * @param colisor The collision box of the block
     */
	void OnCollisionEnter2D(Collision2D colisor){
		if(colisor.gameObject.name.Equals("Mario") && colisor.gameObject.transform.position.y > 6.5){
			Die();
		}else{
			colisor.gameObject.SetActive(false);
		}
	}

	/**
	 * Method to set the object to false, therefore being killed.
	 */ 
	void Die(){
		gameObject.SetActive(false);
	}
}
