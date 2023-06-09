using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject LoadingScren;
    public Image LoadingBarFill;

    public void LoadScreen(int sceneId)
    {
        StartCoroutine(LoadScemeAsync(sceneId));
    }

    IEnumerator LoadScemeAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Sıgınak");

        LoadingScren.SetActive(true);

        while(!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingBarFill.fillAmount = progressValue; 

            yield return null;


                

        }
    }
}
