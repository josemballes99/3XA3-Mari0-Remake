using UnityEngine;
using System.Collections;

public class QuestionBlock : MonoBehaviour {

	private SpriteRenderer spriteRenderer;

	public Sprite emptyBlock;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D colisor){
		if(colisor.gameObject.name.Equals("Mario") && colisor.gameObject.transform.position.y < gameObject.transform.position.y){
			spriteRenderer.sprite = emptyBlock;
		}
	}
}
