using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_load : MonoBehaviour
{
    public Image loadingBar;
    public UI_manage ui_manage_cs;

    void Start()
    {
        loadingBar.fillAmount = 0;
        StartCoroutine(LoadAsyncScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void LoadScence(string sceneName)
    {
        SceneManager.LoadScene("loading2");
    }

    IEnumerator LoadAsyncScene()
    {
        yield return null;
        AsyncOperation asyncScene = SceneManager.LoadSceneAsync("main_scene");
        asyncScene.allowSceneActivation = false;
        float timeC = 0;

        while (!asyncScene.isDone)
        {
            yield return null;
            timeC += Time.deltaTime;
            if (asyncScene.progress >= 0.9f)
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1, timeC);
                if (loadingBar.fillAmount == 1.0f)
                {

                    asyncScene.allowSceneActivation = true;

                }
            }
            else
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, asyncScene.progress, timeC);
                if (loadingBar.fillAmount >= asyncScene.progress)
                {
                    timeC = 0f;
                }
            }
        }

    }


    public void start_button()
    {
        SceneManager.LoadScene("main_scene");

    }
}
