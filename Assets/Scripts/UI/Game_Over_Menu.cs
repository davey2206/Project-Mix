using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Menu : MonoBehaviour
{
    public void RestartScene()
    {
        StartCoroutine(RestartSceneTimer());
    }
    public void Home()
    {
        Time.timeScale = 1;
        StartCoroutine(HomeTimer());
    }

    IEnumerator HomeTimer()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }

    IEnumerator RestartSceneTimer()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
