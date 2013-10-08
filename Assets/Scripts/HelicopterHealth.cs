using UnityEngine;
using System.Collections;

public class HelicopterHealth : MonoBehaviour {
	
	public float m_Health = 100;

	private void ReduceHealth(float amount)	{
		m_Health -= amount;
		if (m_Health <= 0)
		{
			Death();
		}
	}
	
	private void Death()
	{
		Application.LoadLevel("GameOver");
	}
	
	void OnCollisionEnter(Collision collision)
	{
		Environment env = collision.gameObject.GetComponent<Environment>();
		Enemy enemy = collision.gameObject.GetComponent<Enemy>();
		if (env != null)
		{			
			ReduceHealth(collision.relativeVelocity.magnitude);
			//ReduceHealth(m_Health);
		}
		
		if (enemy != null)
		{
			ReduceHealth(20);
			enemy.Falling();
		}
		
		Victory vic = collision.gameObject.GetComponent<Victory>();
		if (null != vic)
		{
			Application.LoadLevel("Victory");
		}
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(30, 30, 400, 200));
		
		if (m_Health > 0)
			GUILayout.Label("Health: " + m_Health);
		else
			GUILayout.Label("DEAD!!!");
		GUILayout.EndArea();
	}
}
