using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour {

    private static bool created = false;

    public static bool Playing = true;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void TogglePause(bool playing, bool midGame = false)
    {
        Playing = playing;

        if (midGame)
        {
            EventManager.TriggerEvent("PauseToggled");
        }
    }

    public static void EndGame()
    {
        Playing = false;
        EventManager.TriggerEvent("GameEnded");
    }

    public static void PauseGame()
    {
        Playing = false;
        EventManager.TriggerEvent("GamePaused");
    }

    public static void ResumeGame()
    {
        Playing = true;
        EventManager.TriggerEvent("GameResumed");
    }
}
