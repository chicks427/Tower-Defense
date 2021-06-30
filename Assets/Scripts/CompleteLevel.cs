using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string mainMenuName = "MainMenu";
    public string nextLevel = "Level02";
	public int levelToUnlock = 2;

    public SceneFader sceneFader;

    void OnEnable()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
    
    public void Continue()
    {
		sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(mainMenuName);
    }
}
