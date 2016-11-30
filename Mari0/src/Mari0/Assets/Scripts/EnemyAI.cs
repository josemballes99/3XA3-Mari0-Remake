using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float walkSpeed = 2.0f;
	public float wallLeft = 22.0f;
	public float wallRight = 48.0f;
	float walkingDirection = 1.0f;
	Vector3 walkAmount;

	// Use this for initialization
	void Start () {
		Update();
	}
	
	// Update is called once per frame
	void Update () {

		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if (walkingDirection > 0.0f && transform.position.x >= wallRight){
			walkingDirection = -1.0f;
		}else if (walkingDirection < 0.0f && transform.position.x <= wallLeft){
			walkingDirection = 1.0f;
		}
			
		transform.Translate(walkAmount);
	
	}

	void OnCollisionEnter2D(Collision2D colisor){
		if(colisor.gameObject.name.Equals("Mario") && colisor.gameObject.transform.position.y > 6.5){
			Die();
		}else{
			colisor.gameObject.SetActive(false);
		}
	}

	void Die(){
		gameObject.SetActive(false);
	}
}
