﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCanvas_1 : MonoBehaviour
{
    public Shape shape; 
    public Sprite[] shapeType_1;
	public Sprite[] shapeType_2;
	public Sprite[] shapeType_3;
    private Sprite[] images;
	private int shapeType;

	public GameController gameController;
	public GameObject levelObject;
	private string levelPurpose;// = "Найти 1  из 5 фигур одного размера";
	private int[] posIndexes;
	private float[,] pos;

	public Text purposeText;
	public Text scoreText;
	public Text recText;
	public Text levelTitle;
	public Text livesText;
	public Text timerText;

	public bool isChangeAngle;
	public bool isChangeColor;
	private int[] rotateAngles = {45, 90, 135, 180};

	void Start()
	{
		posIndexes = gameController.GetPosIndexes();
		pos = gameController.GetShapeCoords();
		levelPurpose = gameController.GetLevelPurpose(posIndexes);
		purposeText.text = levelPurpose;
		
		InvokeRepeating("RunTimer", 1, 1);

		GetShapeType(); //выбирает тип фигуры для игры (круг квадрат или цветок)
		UpdateArrayOfImages(); //выбирает один из 3-х спрайтов как основной(перемещает его на 0 позицию)
		ShuffleCoords(); //перемешивает координаты расстановки фигур (фигуры заданы 0-1-2=спрайты)

		for(int i=0; i<posIndexes.Length; i++)
		{
            Shape cloneShape = Instantiate(shape) as Shape;
            cloneShape.SetShape(images[posIndexes[i]]);
            cloneShape.transform.SetParent(levelObject.transform, false);
            cloneShape.transform.position = new Vector3(pos[i,0], pos[i,1], 0);
            cloneShape.transform.localScale = new Vector3(40, 40, 0);
			if (isChangeAngle)
			{
				cloneShape.transform.Rotate(0, 0, getAngle());
			}
			if (isChangeColor)
			{
				Renderer rend = cloneShape.GetComponent<SpriteRenderer>();
            	rend.material.color = GetColor();
			}
			
            if(posIndexes[i]==0)
			{
				cloneShape.tag = "MainShape";
			}
			else
			{
				cloneShape.tag = "SubShape";
			}
		}
	}
	
	void RunTimer() 
	{
		gameController.UpdateTimer();
		timerText.text = gameController.GetTimeLimit().ToString();
	}

	void Update()
	{
		scoreText.text = "Счет: "+gameController.GetGameScore();
		recText.text = "Рекорд: "+gameController.GetRecord();
		levelTitle.text = "#"+gameController.GetLevel();
		livesText.text = gameController.GetLives().ToString();
	}

	public void GetShapeType()
	{
		shapeType = Random.Range(0, 3);	
		if(shapeType==0)
		{
			images = shapeType_1.Clone() as Sprite[];
		}
		else if (shapeType==1)
		{
			images = shapeType_2.Clone() as Sprite[];
		}
		else if (shapeType==2)
		{
			images = shapeType_3.Clone() as Sprite[];
		}
	}
		
	public void ShuffleCoords()
	{
		for (int i = 0; i < posIndexes.Length; i++ ) 
		{
			int tmp = posIndexes[i];
			int r = Random.Range(i, posIndexes.Length);
			posIndexes[i] = posIndexes[r];
			posIndexes[r] = tmp;
		}
	}
	
	public void UpdateArrayOfImages()
	{
		Sprite subShape = images[0];
		images[0] = images[shapeType];
		images[shapeType] = subShape;	
	}

	public Color GetColor()
	{
		int colorType = Random.Range(0, 2);	
		if (colorType==1)
		{
			return( new Color(0.7f, 0.3f, 0.8f, 1f));
		}
		else
		{
			return( new Color(0f, 0.6f, 0.9f, 1));
		}
	}

	private int getAngle()
	{
		int r = Random.Range(0, rotateAngles.Length);
		return rotateAngles[r];
	}
}
