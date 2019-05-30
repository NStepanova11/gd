using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private static List<string> sceneNames = new List<string>();
    private static int sceneCount;
    private static int currentSceneNumber=0;

    void Start()
    {
        InitSceneNames();
    }

    public void InitSceneNames()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;     
        for( int i = 0; i < sceneCount; i++ )
        {
            sceneNames.Add(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex( i )));
        }

        sceneNames.Remove("MainMenuScene");
        sceneNames.Remove("WinScene");
        sceneNames.Remove("LoseScene");
    }

    public void LoadNewLevelScene()
    {
        SceneManager.LoadScene(sceneNames[currentSceneNumber]);
    }

    public void LoadCurrentLevelScene()
    {
        SceneManager.LoadScene(sceneNames[currentSceneNumber]);
    }

    public void LoadWinScene()
    {
        currentSceneNumber++;
        SceneManager.LoadScene("WinScene"); //mainMenuScene
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public int GetCurrentLevelNumber()
    {
        Debug.Log("levelId ->"+currentSceneNumber);
        return currentSceneNumber;
    }

    private float[, ] coords;

    public float[,] GetShapeCoords(int levelId)
    {
        switch (levelId)
        {
            case 0:
            {
                coords = new float[,]{
                    { 0f, 0f }, { 0f, 2f }, { -1f, -1f }, { -1f, 1f }, { 2f, -2f }, 
		            { 0f, -2f }, { 2f, 0f }, { -2f, 2f }, { -2f, -2f },{ -2f, 0f },
                    { 1f, -1f }, { 1f, 1f }, { 2f, 2f }
                };
                break;
            }   
            case 1:
            {
                coords = new float[,] { 
                    { -2f, 2f }, { -2f, 0.5f }, { -2f, -1f }, { -0.7f, 1f }, { -0.7f, -0.5f }, 
                    { -0.7f, -2f }, { 0.7f, 2f }, { 0.7f, 0.5f }, { 0.7f, -1f }, {2f, 1f },
                    { 2f, -0.5f }, { 2f, -2f } 
                };
                break;
            } 
        }
        return coords;
    } 

    private int[] shapeIndexes;
    public int[] GetPosIndexes(int levelId)
    {
        switch(levelId)
        {
            case 0:
            {
                shapeIndexes = new int[]{0,0,0,0,0,1,1,1,1,2,2,2,2};
                break;
            }
            case 1:
            {
                shapeIndexes = new int[]{0,0,1,1,1,2,2,2,2,3,3,3};
                break;
            }
            case 2:
            {
                shapeIndexes = new int[]{0,0,0,0,1,1,1,1,1,2,2,2};
                break;
            }
            case 3:
            {
                shapeIndexes = new int[]{0,0,0,1,1,1,1,2,2};
                break;
            }
            case 4:
            {
                shapeIndexes = new int[]{0,0,0,0,1,1,2,2,2,3,3,3};
                break;
            }
            case 5:
            {
                shapeIndexes = new int[]{0,0,1,1,1,2,2,2,2,3};
                break;
            }
            case 6:
            {
                shapeIndexes = new int[]{0,0,1,1,1,2,2,2,2,3};
                break;
            }
            case 7:
            {
                shapeIndexes = new int[]{0,0,1,1,1,2,2,2,2,3};
                break;
            }
            case 8:
            {
                shapeIndexes = new int[]{0,0,0,1,1,2,3,3,3,3};
                break;
            }
            case 9:
            {
                shapeIndexes = new int[]{0,0,0,1,1,2,3,3,3,3};
                break;
            }
        }
        return shapeIndexes;
    }

    private string purpose;
    public string GetLevelPurpose(int[] posIndexes)
    {
        int shapeCount=0;

        for(int i=0; i<posIndexes.Length; i++)
        {
            if(posIndexes[i]==0)
                shapeCount++;
        }

        return "Найти 1 из "+shapeCount+" фигур одного размера";
    }
}
