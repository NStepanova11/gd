using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
	/*Main menu*/
	public void PlayButtonPressed()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void HelpButtonPressed()
    {
        SceneManager.LoadScene("HelpScene");
    }
	
    public void ExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
