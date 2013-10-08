using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float m_EnemySpeed;
	public string m_EnemyType;
		
	public void Falling(){
		Vector3 fallingPosition = gameObject.transform.position;
		fallingPosition.y = 0;
		gameObject.transform.position = fallingPosition;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}	
}
