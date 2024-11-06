using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLVL : MonoBehaviour
{
    public void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
        SceneManager.LoadScene(0);
    }

    public void FailCurrentLvl()
    {
        SceneManager.LoadScene(0);
    }
}
