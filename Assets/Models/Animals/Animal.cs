using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animal : MonoBehaviour {


	[SerializeField] private float spawnRate = 0.10f;
	[SerializeField] private float catchRate = 0.10f;
	[SerializeField] private int attack = 0;
	[SerializeField] private int defense = 0;
	[SerializeField] private int hp = 10;


	private void Start() {
//		DontDestroyOnLoad(this);
	}

	public float SpawnRate {
		get { return spawnRate; }
	}

	public float CatchRate {
		get { return catchRate; }
	}

	public int Attack {
		get { return attack; }
	}

	public int Defense {
		get { return defense; }
	}

	public int Hp {
		get { return hp; }
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
