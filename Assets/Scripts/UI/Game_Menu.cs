using System.Collections;
using UnityEngine;

public class Game_Menu : MonoBehaviour
{
    [SerializeField] GameObject Menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Menu != null)
        {
            if (Time.timeScale == 1)
            {
                ShowMenu();
                Time.timeScale = 0;
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
    }
    public void CloseMenu()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
    }

    public void CloseMenuButton()
    {
        Time.timeScale = 1;
        StartCoroutine(CloseMenuButtonTimer());
    }

    IEnumerator CloseMenuButtonTimer()
    {
        yield return new WaitForSeconds(0.4f);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
        Menu.SetActive(false);
    }
}
