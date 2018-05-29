using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene: MonoBehaviour
{
	public string scene;

	public void NextScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene);
	}
}
