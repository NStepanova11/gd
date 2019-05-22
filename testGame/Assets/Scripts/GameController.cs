using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField] private GameObject interfaceCanvas; //канвас интерфейса
	[SerializeField] private GameObject winPanelCanvas; //канвас панели победы
	[SerializeField] private GameObject losePanelCanvas; //канвас панели проигрыша
	[SerializeField] private GameObject mainMenuCanvas; // канвас меню
	[SerializeField] private GameObject helpCanvas; // канвас справки
	
	[SerializeField] private GameObject[] levelCanvas; // массив канвасов уровней
	
	[SerializeField] private Shape shape;

	private int level_id;
	private bool levelUp = false;
	
    void Start()
    {
		level_id = 0;
		
		mainMenuCanvas.SetActive(true);
		interfaceCanvas.SetActive(false);
		winPanelCanvas.SetActive(false);
		losePanelCanvas.SetActive(false);
		
		for(int i=0; i<levelCanvas.Length; i++)
		{
			levelCanvas[i].SetActive(false);
		}
    }
	
	public void PlayButtonPressed()
	{
		mainMenuCanvas.SetActive(false);
		
		interfaceCanvas.SetActive(true);
		levelCanvas[level_id].SetActive(true);
	}
	
	public void OnMouseUp()
	{
		levelUp = shape.OnMousePressed();
		Debug.Log("level: "+levelUp);
		if(levelUp)
		{
			WinPressed();
		}
	}
	
	//если уровень пройден (тест)
    public void WinPressed()
    {
		Debug.Log("level id = "+level_id);
        levelCanvas[level_id].SetActive(false);
		interfaceCanvas.SetActive(false);
        winPanelCanvas.SetActive(true);
		Debug.Log("win pressed");
    }
	
	public void HelpButtonPressed()
	{
		mainMenuCanvas.SetActive(false);
		interfaceCanvas.SetActive(false);
		helpCanvas.SetActive(true);
	}
	
	public void ExitButtonPressed()
	{
		Application.Quit();
		Debug.Log("Exit pressed!");
	}

	public void BackToMenuButtonPressed()
	{
		levelCanvas[level_id].SetActive(false);
		interfaceCanvas.SetActive(false);
		mainMenuCanvas.SetActive(true);
	}
}
