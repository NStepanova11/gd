using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_1 : MonoBehaviour
{
   [SerializeField]
    private Shape shape; 
    [SerializeField] private Sprite[] images;
	public GameObject levelObject;
	
	
	//клонирует заднный префаб на указанные координаты
	void Start()
	{
		int id = 0;
		int[,] main100pos = new int[,] { { 0, 0 }, { 0, 2 }, { -1, -1 }, { -1, 1 }, { 2, -2 } };
		
		for (int i=0; i<5; i++)
		{
			Shape cloneShape;
			cloneShape = Instantiate(shape) as Shape;
			cloneShape.tag = "MainShape";
			cloneShape.SetShape(images[id]);
			cloneShape.transform.SetParent(levelObject.transform, false);
			cloneShape.transform.position = new Vector3(main100pos[i,0], main100pos[i,1], 0);
		}
				
		id++;
		int[,] sub110Pos = new int[,] { { 0, -2 }, { 2, 0 }, { -2, 2 }, { -2, -2 } };
		for (int i = 0; i < 4; i++)
		{
			Shape cloneShape;
			cloneShape = Instantiate(shape) as Shape;
			cloneShape.tag = "SubShape";
			cloneShape.SetShape(images[id]);
			cloneShape.transform.SetParent(levelObject.transform, false);
			cloneShape.transform.position = new Vector3(sub110Pos[i, 0], sub110Pos[i, 1], 0);
		}

		id++;
		int[,] sub120Pos = new int[,] { { -2, 0 }, { 1, -1 }, { 1, 1 }, { 2, 2 } };
		for (int i = 0; i < 4; i++)
		{
			Shape cloneShape;
			cloneShape = Instantiate(shape) as Shape;
			cloneShape.tag = "SubShape";
			cloneShape.SetShape(images[id]);
			cloneShape.transform.SetParent(levelObject.transform, false);
			cloneShape.transform.position = new Vector3(sub120Pos[i, 0], sub120Pos[i, 1], 0);
		}
	}
}
