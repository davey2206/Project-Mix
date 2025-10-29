using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Game_Menu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    bool pauze = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Menu != null)
        {
            if (!pauze)
            {
                ShowMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void ShowMenu()
    {
        pauze = true;
        Menu.SetActive(true);
    }
    public void CloseMenu()
    {
        pauze=false;
        Menu.SetActive(false);
    }

    public void CloseMenuButton()
    {
        pauze = false;
        StartCoroutine(CloseMenuButtonTimer());
    }

    IEnumerator CloseMenuButtonTimer()
    {
        yield return new WaitForSeconds(0.4f);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
        Menu.SetActive(false);
    }
}
