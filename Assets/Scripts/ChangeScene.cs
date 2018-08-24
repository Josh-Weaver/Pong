using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ChangeScene {

	public static void ChangeSceneByIndex(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
