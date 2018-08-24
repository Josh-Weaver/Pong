using UnityEngine;
using System.Collections.Generic;

public class MenuButtons : MonoBehaviour {

    [SerializeField]
    GameObject[] EnableOnPause;

    [SerializeField]
    GameObject[] EnableOnEnd;

    [SerializeField]
    GameObject[] Menus;

    GameObject ActiveMenu;

    Stack<GameObject> MenuStack;

    void Start()
    {
        MenuStack = new Stack<GameObject>();

        if (Menus != null)
        {
            ActiveMenu = Menus[0];
            ActiveMenu.SetActive(true);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PreviousMenu();
        }
    }

    public void NavigateToMenu(int newMenuId)
    {
        //Check to see if the new menu is the main menu
        //If it is, we want to reset the MenuStack, and not increment
        bool resetStack = newMenuId == 0;

        UpdateMenuStack(!resetStack, resetStack);
        UpdateActiveMenu(Menus[newMenuId]);
    }

    public void PreviousMenu()
    {
        if (MenuStack.Count != 0)
        {
            UpdateMenuStack(false);
            UpdateActiveMenu(MenuStack.Pop());
        }
    }

    void UpdateMenuStack(bool incrementStack = true, bool resetStack = false)
    {
        if (incrementStack)
        {
            MenuStack.Push(ActiveMenu);
        }

        if (resetStack)
        {
            MenuStack.Clear();
        }
    }

    void UpdateActiveMenu(GameObject newActiveMenu)
    {
        ActiveMenu.SetActive(false);
        ActiveMenu = newActiveMenu;
        ActiveMenu.SetActive(true);
    }

    void OnEnable()
    {
        EventManager.StartListening("GamePaused", GamePaused);
        EventManager.StartListening("GameResumed", GameResumed);
        EventManager.StartListening("GameEnded", GameEnded);
    }

    void OnDisable()
    {
        EventManager.StopListening("GamePaused", GamePaused);
        EventManager.StopListening("GameResumed", GameResumed);
        EventManager.StopListening("GameEnded", GameEnded);
    }

    public void NavigateToMainMenu()
    {
        GlobalController.TogglePause(false);
        ChangeScene.ChangeSceneByIndex((int)Constants.Scenes.MainMenu);
    }

    public void Play()
    {
        GlobalController.TogglePause(true);
        ChangeScene.ChangeSceneByIndex((int)Constants.Scenes.Gameplay);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TogglePause(bool playing)
    {
        GlobalController.ResumeGame();
    }

    void GamePaused()
    {
        Debug.Log("GAME PAUSED");
        foreach (GameObject go in EnableOnPause)
        {
            go.SetActive(true);
        }
    }

    void GameResumed()
    {
        Debug.Log("GAME RESUMED");
        foreach (GameObject go in EnableOnPause)
        {
            go.SetActive(false);
        }
    }

    void GameEnded()
    {
        Debug.Log("GAME ENDED");
        foreach (GameObject go in EnableOnEnd)
        {
            go.SetActive(true);
        }
    }
}
