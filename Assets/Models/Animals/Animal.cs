using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animal : MonoBehaviour {


	[SerializeField] private float spawnRate = 0.10f;

 	Vector3 touchPosWorld;
    TouchPhase touchPhase = TouchPhase.Ended;

	private void Start() {
//		DontDestroyOnLoad(this);
	}

	private void Update() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase) {
             touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
 
             Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
             RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
 
             if (hitInformation.collider != null) {
                GameObject touchedObject = hitInformation.transform.gameObject;
				Debug.Log("Touched " + touchedObject.transform.name);
                touchedObject.SendMessage("OnMouseDown");

           }
             }

         }
	

	public float SpawnRate {
		get { return spawnRate; }
	}

	private void OnMouseDown() {
		GameSceneManager[] managers = FindObjectsOfType<GameSceneManager>();
		Debug.Log("onmousedown");
		Debug.Log(managers.Length);
		foreach (GameSceneManager gameSceneManager in managers) {
			if (gameSceneManager.gameObject.activeSelf) {
				gameSceneManager.animalTapped(this.gameObject);
			}
		}
	}

	private void OnCollisionEnter(Collision other) {
		GameSceneManager[] managers = FindObjectsOfType<GameSceneManager>();
		foreach (GameSceneManager gameSceneManager in managers) {
			if (gameSceneManager.gameObject.activeSelf) {
				gameSceneManager.animalCollision(this.gameObject, other);
			}
		}
	}
}
