using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceScript : MonoBehaviour
{	
	/*Levels and level interface*/
	[SerializeField] private GameObject interfaceCanvas;
	[SerializeField] private GameObject winPanelObject;
	[SerializeField] private GameObject losePanelObject;
	[SerializeField] private GameObject[] levelGameObject;
	
	private int level_id=0;
		
	void Start()
	{
		winPanelObject.SetActive(false);
		losePanelObject.SetActive(false);
		
		for(int i=0; i<levelGameObject.Length; i++)
		{
			levelGameObject[i].SetActive(false);
		}
	}
	
	//Кнопка назад на уровне и кнопка выход в панели результатов
    public void BackButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

	//если уровень пройден (тест)
    public void WinPressed()
    {
        levelGameObject[level_id].SetActive(false);
		interfaceCanvas.SetActive(false);
		
        winPanelObject.SetActive(true);
		Debug.Log("win pressed");
    }
	
	 public void LosePressed()
    {
        levelGameObject[level_id].SetActive(false);
		interfaceCanvas.SetActive(false);
		
        losePanelObject.SetActive(true);
		Debug.Log("lose pressed");
    }
	
	public void NextLevelPressed()
	{
		level_id++;
		levelGameObject[level_id].SetActive(true);
		interfaceCanvas.SetActive(true);
		winPanelObject.SetActive(false);

		Debug.Log("next level pressed");
	}
	
	public void RetryPressed()
	{
		levelGameObject[level_id].SetActive(true);
		interfaceCanvas.SetActive(true);
		losePanelObject.SetActive(false);

		Debug.Log("retry pressed");
	}
}
