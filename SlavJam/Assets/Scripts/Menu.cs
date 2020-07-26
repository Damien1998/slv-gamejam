﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        //Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        //Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Wypierdalam c:");
    }
}
