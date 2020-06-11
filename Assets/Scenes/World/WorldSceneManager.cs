using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : GameSceneManager {
	private GameObject animal;
	private AsyncOperation loadScene;
	

	public override void playerTapped(GameObject player) {
		
	}

	public override void animalTapped(GameObject animal) {
		List<GameObject> objects = new List<GameObject>();
		print(objects);
		objects.Add(animal);
		print(objects);
		SceneTransitionManager.Instance.
			GoToScene(GameConstants.SCENE_INTERACTION, objects);
	}
}
