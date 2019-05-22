using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private Renderer renderrer;
    private GameObject[] goodShapes, badShapes;
		
	//скрипт обрабатывает событие нажатия на фигуру
	
	//при нажатии на фигуру
	public bool OnMousePressed()
    {
		bool status = false;
        renderrer = GetComponent<SpriteRenderer>();
        Debug.Log("go tag = " + renderrer.tag);
		
        if (renderrer.tag=="MainShape")
        {
            for (int i = 0; i < goodShapes.Length; i++)
            {
                Renderer rend = goodShapes[i].GetComponent<SpriteRenderer>();
                rend.material.color = Color.green;
				status = true;
            }
        }
        else
        {
            for (int i = 0; i < goodShapes.Length; i++)
            {
                Renderer rend = goodShapes[i].GetComponent<SpriteRenderer>();
                rend.material.color = Color.red;
            }
            for (int i = 0; i < badShapes.Length; i++)
            {
                Renderer rend = badShapes[i].GetComponent<SpriteRenderer>();
                rend.material.color = Color.red;
            }
            Debug.Log("you lose");
        }
			return status;
    }

    public void SetShape(Sprite image)
    {
        GetComponent<SpriteRenderer>().sprite = image;
    }

    void Start()
    {
        goodShapes = GameObject.FindGameObjectsWithTag("MainShape");
        badShapes = GameObject.FindGameObjectsWithTag("SubShape");
    }
}
