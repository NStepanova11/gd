using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Level_1_Scene");
    }

	public void HelpButtonPressed()
	{
		SceneManager.LoadScene("Help_Scene");
	}
    public void ExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
