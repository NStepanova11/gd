using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDrawer_4 : MonoBehaviour
{
    [SerializeField]
    private Shape shape; 
    [SerializeField] private Sprite[] cleverImages;
    [SerializeField] private Sprite[] starImages;

	
    private Sprite[] images;


	public GameObject levelObject;
	private int shapeType;
	
	private string levelPurpose = "Найти 1  из 3 фигур одного размера";
	
	private int[] posIndexes = {0,0,0,1,1,1,1,2,2};
	float[,] pos = new float[,] { 
		{ 0f, 0f }, { 0f, 1.5f }, { -1.5f, -0f }, { -2f, -2f }, { 2f, 2f }, 
		{ 1.5f, 0f }, { 0f, -1.5f }, { -2f, 2f }, { 2f, -2f }};
	
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
		shapeType = Random.Range(0, 2);	
		if(shapeType==0)
		{
			images = cleverImages.Clone() as Sprite[];
		}
		else if (shapeType==1)
		{
			images = starImages.Clone() as Sprite[];
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
