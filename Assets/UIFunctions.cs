using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour {

    public string gameSceneName;

    private bool sceneIsLoading = false;



	public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        if(!sceneIsLoading)
        {
            sceneIsLoading = true;
            StartCoroutine(LoadGame());
        }
    }

    private IEnumerator LoadGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameSceneName);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
