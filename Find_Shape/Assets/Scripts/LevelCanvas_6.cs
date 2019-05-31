using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCanvas_6 : MonoBehaviour
{
    public Shape shape; 
    public Sprite[] shapeType_1;
    private Sprite[] images;

    public GameObject levelObject;
	private int shapeType;
	public Text purposeText;
	
	private string levelPurpose = "Найти 1  из 2 фигур одного размера";
		public GameController gameController;

	private int[] posIndexes;// = {0,0,1,1,1,2,2,2,2,3};
	float[,] pos ;/* = new float[,]{ 
		{ -2f, 2f }, { -2f, 0f }, { -2f, -2f }, { -0.7f, 1f }, { -0.7f, -1f }, 
		{ 0.7f, 1f }, { 0.7f, -1f },
		{ 2f, 2f }, { 2f, 0f }, { 2f, -2f } };
		*/
	
	private int[] rotateAngles = {45, 90, 135, 180};

		
	void Start()
	{
		posIndexes = gameController.GetPosIndexes();
		pos = gameController.GetShapeCoords();
		GetShapeType(); //выбирает тип фигуры для игры (круг квадрат или цветок)
		UpdateArrayOfImages(); //выбирает один из 3-х спрайтов как основной(перемещает его на 0 позицию)
		ShuffleCoords(); //перемешивает координаты расстановки фигур (фигуры заданы 0-1-2=спрайты)
		purposeText.text = levelPurpose;
		
		for(int i=0; i<posIndexes.Length; i++)
		{
            Shape cloneShape = Instantiate(shape) as Shape;
            cloneShape.SetShape(images[posIndexes[i]]);
            cloneShape.transform.SetParent(levelObject.transform, false);
            cloneShape.transform.position = new Vector3(pos[i,0], pos[i,1], 0);
            cloneShape.transform.Rotate(0, 0, getAngle());

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
	
	private int getAngle()
	{
		int r = Random.Range(0, rotateAngles.Length);
		return rotateAngles[r];
	}
}
