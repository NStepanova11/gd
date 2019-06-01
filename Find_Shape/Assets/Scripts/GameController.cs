using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static List<string> sceneNames = new List<string>();
    private static int sceneCount;
    private static int currentSceneNumber=0;
    private static int gameScore = 0;
    private static int recordScore = 0;
    private static int livesScore = 3;
	private int timeLimit=31; 
    private static int timeBall;
   // private static int chanceByLevel = 2;
    
    void Start()
    {
        //timeLimit = 31;
        InitSceneNames();
    }

    public void UpdateTimer()
    {
        timeLimit--;
        timeBall=timeLimit;
        if (timeLimit==0)
        {
            DeleteOneLife();
            if(livesScore>0)
            {
                LoadLoseScene();
            }
            else
            {
                LoadGameOverScene();    
            }
        }
    }

    public int GetTimeLimit()
    {
        return timeLimit;
    }

    public void UpdateGameScore()
    {
        gameScore+=100;
        gameScore+=timeBall;
        //Debug.Log("-----"+scoreForSeconds);
    }

    public int GetGameScore()
    {
        return gameScore;
    }

    public void UpdateRecord()
    {
        if (gameScore>recordScore);
        {
            recordScore = gameScore;
        }
    }

    public int GetLevel()
    {
        return currentSceneNumber+1;
    }

    public int GetLives()
    {
        return livesScore;
    }

    public int GetRecord()
    {
        return recordScore;
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
        sceneNames.Remove("HelpScene");
        sceneNames.Remove("GameOverScene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ExitButton()
    {
        Application.Quit();
		Debug.Log("Exit pressed!");
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
        //chanceByLevel=2;
        SceneManager.LoadScene("WinScene"); //mainMenuScene
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public void LoadHelpScene()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public int GetCurrentLevelNumber()
    {
        Debug.Log("levelId ->"+currentSceneNumber);
        return currentSceneNumber;
    }
/*
    public void UpdateChanceForLevel()
    {
        chanceByLevel--;
    }

    public int GetCountOfChances()
    {
        return chanceByLevel;
    }
*/
    public void LoadGameOverScene()
    {
        int lastScore = gameScore;

        currentSceneNumber=0;
        livesScore = 3;
        gameScore = 0;
        SceneManager.LoadScene("GameOverscene");
    }

    public void DeleteOneLife()
    {
        livesScore--;
    }

    private float[, ] coords;

    public float[,] GetShapeCoords()
    {
        switch (currentSceneNumber)
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
            case 2:
            {
                coords = new float[,] {
                    {-2f, 2f}, {-2f, 0.5f}, {-2f, -1f}, {-0.7f, 1f}, {-0.7f, -0.5f}, 
                    {-0.7f, -2f}, {0.7f, 1f}, {0.7f, -0.5f}, {0.7f, -2f},
                    {2f, 2f}, {2f, 0.5f}, {2f, -1f} 
                };
                break;
            }
            case 3:
            {
                coords = new float[,] {
                    { 0f, 0f }, { 0f, 1.5f }, { -1.5f, -0f }, { -2f, -2f }, { 2f, 2f }, 
                    { 1.5f, 0f }, { 0f, -1.5f }, { -2f, 2f }, { 2f, -2f }
                };
                break;
            }
            case 4:
            {
                coords = new float[,] {
                    { -2f, 2f }, { -2f, 0.5f }, { -2f, -1f }, { -0.7f, 1f }, { -0.7f, -0.5f }, 
                    { -0.5f, -2f }, { 0.5f, 2f }, { 0.7f, 0.5f }, { 0.7f, -1f },
                    { 2f, 1f }, { 2f, -0.5f }, { 2f, -2f }
                };
                break;
            }
            case 5:
            {
                coords = new float[,] {
                    { -2f, 2f }, { -2f, 0f }, { -2f, -2f }, { -0.7f, 1f }, { -0.7f, -1f }, 
                    { 0.7f, 1f }, { 0.7f, -1f },
                    { 2f, 2f }, { 2f, 0f }, { 2f, -2f }
                };
                break;
            }
            case 6:
            {
                coords = new float[,] {
                    { -2f, 2f }, { -2f, 0f }, { -2f, -2f }, { -0.7f, 1f }, { -0.7f, -1f }, 
                    { 0.7f, 1f }, { 0.7f, -1f },
                    { 2f, 2f }, { 2f, 0f }, { 2f, -2f }
                };
                break;
            }
            case 7:
            {
                coords = new float[,] {
                    { -2f, 2f }, { -2f, 0f }, { -2f, -2f }, { -0.7f, 1f }, { -0.7f, -1f }, 
                    { 0.7f, 1f }, { 0.7f, -1f },
                    { 2f, 2f }, { 2f, 0f }, { 2f, -2f } 
                };
                break;
            }
            case 8:
            {
                coords = new float[,] {
                    { -2f, 2f }, { -1f, 1f }, { 1f, 1f }, 
                    { 2f, 0f }, { 2f, 2f } ,{ -1f, -1f }, { -2f, -2f },
                    {-2f, 0f}, {1f, -1f}, {2f, -2f}
                };
                break;
            }
            case 9:
            {
                coords = new float[,] {
                    { -2f, 2f }, { -1f, 1f }, { 1f, 1f }, 
                    { 2f, 0f }, { 2f, 2f } ,{ -1f, -1f }, { -2f, -2f },
                    {-2f, 0f}, {1f, -1f}, {2f, -2f}
                };
                break;
            }
        }
        return coords;
    } 

    private int[] shapeIndexes;
    public int[] GetPosIndexes()
    {
        switch(currentSceneNumber)
        {
            case 0:
            {
                shapeIndexes = new int[]{0,0,0,0,0,1,1,1,1,2,2,2,2};
                break;
            }
            case 1:
            {
                shapeIndexes = new int[]{0,0,1,1,1,1,1,2,2,2,2,2};
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
