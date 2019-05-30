using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCanvas_1 : MonoBehaviour
{
    public Shape shape; 
    public Sprite[] shapeType_1;
	public Sprite[] shapeType_2;
	public Sprite[] shapeType_3;
    private Sprite[] images;

	public GameObject levelObject;
	private int shapeType;
	
	private string levelPurpose = "Найти 1  из 5 фигур одного размера";
	
	private int[] posIndexes = {0,0,0,0,0,1,1,1,1,2,2,2,2};
	private int[,] pos = new int[,] { 
		{ 0, 0 }, { 0, 2 }, { -1, -1 }, { -1, 1 }, { 2, -2 }, 
		{ 0, -2 }, { 2, 0 }, { -2, 2 }, { -2, -2 },
		{ -2, 0 }, { 1, -1 }, { 1, 1 }, { 2, 2 } };
	
	void Start()
	{
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
			
            if(posIndexes[i]==0)
			{
				cloneShape.tag = "MainShape";
			}
			else if (posIndexes[i]==1)
			{
				cloneShape.tag = "SubShape";
			}
			else if (posIndexes[i]==2)
			{
				cloneShape.tag = "SubShape";
			}
		}
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
}
