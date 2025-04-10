using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";
	public string tutorialToLoad = "TutorialLevel";

	public SceneFader sceneFader;

	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
	}

	public void Tutorial()
    {
		sceneFader.FadeTo(tutorialToLoad);
    }

	public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

}
