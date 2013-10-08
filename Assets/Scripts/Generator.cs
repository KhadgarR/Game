using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject[] objectPrefabs;
	
	
	protected ArrayList objects = new ArrayList();
	protected float cameraNeededDeltaX = 200.0f;
	float cameraOldX;	

	// Use this for initialization
	void Start () {
		Init();
	}
	
	public void Init() {
		cameraOldX = Camera.mainCamera.transform.position.x;;
		//Camera.mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 0.8f, 0.0f, 0.0f)).x;
		for(int i = 0; i < objects.Count;) {			
			Destroy((GameObject)objects[i]);
			objects.RemoveAt(i);			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 currentCameraPox = Camera.mainCamera.transform.position;
		if( currentCameraPox.x - cameraOldX > cameraNeededDeltaX) {
			GenerateObject(Camera.mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x);
			cameraOldX = currentCameraPox.x;
		}
		
		ClearObjects();
	}
	
	protected virtual void GenerateObject(float x) {
		Vector3 objectPos = new Vector3(x, Random.Range(-250, 10), 20);
		GameObject obj =(GameObject)Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length)], objectPos, Quaternion.identity);
		objects.Add(obj);
	}
	
	void ClearObjects() {		
		for(int i = 0; i < objects.Count;) {
			if(Camera.mainCamera.WorldToScreenPoint(((GameObject)objects[i]).transform.position).x < -0.2 * Screen.width) {
				Destroy((GameObject)objects[i]);
				objects.RemoveAt(i);
			} else {
				i++;
			}
		}
	}
	
	public void RemoveObject(GameObject obj) {
		objects.Remove(obj);
		Destroy(obj);
	}
}
