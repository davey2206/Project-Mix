using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject SettingsMenu;

    public void PlayClone()
    {
        StartCoroutine(PlayCloneTimer());
    }

    public void Exit()
    {
        StartCoroutine(ExitTimer());
    }
    public void Settings()
    {
        StartCoroutine(SettingsTimer());
    }

    IEnumerator ExitTimer()
    {
        yield return new WaitForSeconds(0.4f);
        Application.Quit();
    }

    IEnumerator PlayCloneTimer()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }

    IEnumerator SettingsTimer()
    {
        yield return new WaitForSeconds(0.4f);
        Menu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
}
