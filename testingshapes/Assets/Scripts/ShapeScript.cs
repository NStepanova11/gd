using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeScript : MonoBehaviour
{
    private Renderer renderrer;
    [SerializeField]
    private SceneController controller;
   
    private bool mainShapeIsFind = false;
    private GameObject[] goodShapes, badShapes, allShapes;

    public void OnMouseDown()
    {
        renderrer = GetComponent<SpriteRenderer>();
        Debug.Log("go tag = " + renderrer.tag);
        if (renderrer.tag=="MainShape")
        {
            for (int i = 0; i < goodShapes.Length; i++)
            {
                Renderer rend = goodShapes[i].GetComponent<SpriteRenderer>();
                rend.material.color = Color.green;
            }
            Debug.Log("you win");
            mainShapeIsFind = true;
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
