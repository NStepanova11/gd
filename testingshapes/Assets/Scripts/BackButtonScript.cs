﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    public void BackToMainMenuButtonPressed()
    {
        SceneManager.LoadScene("Main_Menu_Scene");
    }
}
