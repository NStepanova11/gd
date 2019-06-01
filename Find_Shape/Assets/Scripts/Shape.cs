using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private Renderer renderrer;
    public GameController gameController;
    private GameObject[] goodShapes, badShapes;

    public void OnMouseDown()
    {
        renderrer = GetComponent<SpriteRenderer>();
        renderrer.material.color = Color.yellow;

        if (renderrer.tag=="MainShape")
        {
            
            for (int i = 0; i < goodShapes.Length; i++)
            {
                Renderer rend = goodShapes[i].GetComponent<SpriteRenderer>();
                rend.material.color = Color.green;
            }
            gameController.UpdateGameScore();
            gameController.UpdateRecord();
            gameController.LoadWinScene();
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
            //gameController.UpdateChanceForLevel();
            gameController.DeleteOneLife();
            if (gameController.GetLives()>0)
                gameController.LoadLoseScene();
            else
                gameController.LoadGameOverScene();
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
