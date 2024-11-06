using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int levelUnlock;
    public Button[] button;

    void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("levels", 1);


        for (int i = 0; i < button.Length; i++) 
        { 
            button[i].interactable = false;
        }
        for (int i = 0; i < levelUnlock; i++)
        {
            button[i].interactable = true;
        }
    }

    public void loadLevels(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    
}
