using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 2; 
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField]
    private ShapeScript shape; 
    [SerializeField] private Sprite[] images;
    void Start()
    {
        int id = 0;
        int[,] main100pos = new int[,] { { 0, 0 }, { 0, 2 }, { -1, -1 }, { -1, 1 }, { 2, -2 } };
        
        for (int i=0; i<5; i++)
        {
            ShapeScript cloneShape;
            cloneShape = Instantiate(shape) as ShapeScript;
            cloneShape.tag = "MainShape";
            cloneShape.SetShape(images[id]);
            cloneShape.transform.position = new Vector3(main100pos[i,0], main100pos[i,1], 0);
        }
                
        id++;
        int[,] sub110Pos = new int[,] { { 0, -2 }, { 2, 0 }, { -2, 2 }, { -2, -2 } };
        for (int i = 0; i < 4; i++)
        {
            ShapeScript cloneShape;
            cloneShape = Instantiate(shape) as ShapeScript;
            cloneShape.tag = "SubShape";
            cloneShape.SetShape(images[id]);
            cloneShape.transform.position = new Vector3(sub110Pos[i, 0], sub110Pos[i, 1], 0);
        }

        id++;
        int[,] sub120Pos = new int[,] { { -2, 0 }, { 1, -1 }, { 1, 1 }, { 2, 2 } };
        for (int i = 0; i < 4; i++)
        {
            ShapeScript cloneShape;
            cloneShape = Instantiate(shape) as ShapeScript;
            cloneShape.tag = "SubShape";
            cloneShape.SetShape(images[id]);
            cloneShape.transform.position = new Vector3(sub120Pos[i, 0], sub120Pos[i, 1], 0);
        }
    }
}
