using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCanvas_9 : MonoBehaviour
{
    public Shape shape; 
    public Sprite[] shapeType_1;
    private Sprite[] images;
    
    public GameObject levelObject;
	private int shapeType;
	
	private string levelPurpose = "Найти 1  из 2 фигур одного размера";
	
	private int[] posIndexes = {0,0,0,1,1,2,3,3,3,3};
	float[,] pos = new float[,] { 
		{ -2f, 2f }, { -1f, 1f }, { 1f, 1f }, 
		{ 2f, 0f }, { 2f, 2f } ,{ -1f, -1f }, { -2f, -2f },
		{-2f, 0f}, {1f, -1f}, {2f, -2f}};
	
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
            Renderer rend = cloneShape.GetComponent<SpriteRenderer>();
            rend.material.color = GetColor();

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
			else if (posIndexes[i]==3)
			{
				cloneShape.tag = "SubShape";
			}
		}
	}
	
	public void GetShapeType()
	{
		/*shapeType = Random.Range(0, 3);	
		if(shapeType==0)
		{
			images = circleImages.Clone() as Sprite[];
		}
		else if (shapeType==1)
		{
			images = butterflyImages.Clone() as Sprite[];
		}
		else if (shapeType==2)
		{
			images = flowerImages.Clone() as Sprite[];
		}
		*/
		
		images = shapeType_1.Clone() as Sprite[];
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
		//выбор главной фигуры
		int mainShape = Random.Range(0, images.Length);	
		Sprite subShape = images[0];
		images[0] = images[mainShape];
		images[mainShape] = subShape;
		
	}
	
	public Color GetColor()
	{
		int colorType = Random.Range(0, 2);	
		if (colorType==1)
		{
			return( new Color(0.9f, 0.5f, 0.7f, 1f));
		}
		else
		{
			return( new Color(0.7f, 0.5f, 0.9f, 1f));
		}
	}
}
