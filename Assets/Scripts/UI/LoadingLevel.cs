using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{
    #region Variables
    public GameObject loadingScreen;
    public Image progressBar;
    public Text progressText;
    #endregion
    //This IEnumerator creates a coroutine that makes the load possible
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        //while the loading hos not finished
        while (!operation.isDone)
        {
            //slowly increase the progress % of the loading bar
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.fillAmount = progress;
            progressText.text = progress * 100 + "%";
            yield return null;
        }
    }
    //This function starts the load coroutine when called
    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
}