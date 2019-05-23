using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDrawer_1 : MonoBehaviour
{
    [SerializeField]
    private Shape shape; 
    [SerializeField] private Sprite[] circleImages;
	[SerializeField] private Sprite[] rectImages;
	[SerializeField] private Sprite[] flowerImages;
    private Sprite[] images;


	public GameObject levelObject;
	private int shapeType;
	
	private int[] posIndexes = {0,0,0,0,0,1,1,1,1,2,2,2,2};
	int[,] pos = new int[,] { 
		{ 0, 0 }, { 0, 2 }, { -1, -1 }, { -1, 1 }, { 2, -2 }, 
		{ 0, -2 }, { 2, 0 }, { -2, 2 }, { -2, -2 },
		{ -2, 0 }, { 1, -1 }, { 1, 1 }, { 2, 2 } };
	
	void Start()
	{
		GetShapeType(); //выбирает тип фигуры для игры (круг квадрат или цветок)
		UpdateArrayOfImages(); //выбирает один из 3-х спрайтов как основной(перемещает его на 0 позицию)
		ShuffleCoords(); //перемешивает координаты расстановки фигур (фигуры заданы 0-1-2=спрайты)
		
		//
		for(int i=0; i<posIndexes.Length; i++)
		{
			if(posIndexes[i]==0)
			{
				Shape cloneShape;
				cloneShape = Instantiate(shape) as Shape;
				cloneShape.tag = "MainShape";
				cloneShape.SetShape(images[posIndexes[i]]);
				cloneShape.transform.SetParent(levelObject.transform, false);
				cloneShape.transform.position = new Vector3(pos[i,0], pos[i,1], 0);
			}
			else if (posIndexes[i]==1)
			{
				Shape cloneShape;
				cloneShape = Instantiate(shape) as Shape;
				cloneShape.tag = "SubShape";
				cloneShape.SetShape(images[posIndexes[i]]);
				cloneShape.transform.SetParent(levelObject.transform, false);
				cloneShape.transform.position = new Vector3(pos[i, 0], pos[i, 1], 0);
			}
			else if (posIndexes[i]==2)
			{
				Shape cloneShape;
				cloneShape = Instantiate(shape) as Shape;
				cloneShape.tag = "SubShape";
				cloneShape.SetShape(images[posIndexes[i]]);
				cloneShape.transform.SetParent(levelObject.transform, false);
				cloneShape.transform.position = new Vector3(pos[i, 0], pos[i, 1], 0);
			}
		}
	}
	
	public void GetShapeType()
	{
		shapeType = Random.Range(0, 3);	
		if(shapeType==0)
		{
			images = circleImages.Clone() as Sprite[];
		}
		else if (shapeType==1)
		{
			images = rectImages.Clone() as Sprite[];
		}
		else if (shapeType==2)
		{
			images = flowerImages.Clone() as Sprite[];
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
