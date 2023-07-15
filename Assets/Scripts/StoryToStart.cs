using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StoryToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadScenceStart());
    }

    private IEnumerator loadScenceStart()
    {
        yield return new WaitForSeconds(39f);
        SceneManager.LoadSceneAsync("Start Screen");
    }
}
