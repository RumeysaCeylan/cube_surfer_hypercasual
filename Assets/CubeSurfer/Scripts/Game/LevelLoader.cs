using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void Start()
    {
        if (!LevelLoader.IsLevelUnlocked(1))
        {
            LevelLoader.UnlockLevel(1);
        }
    }
    // Bu metod, belirli bir levelin kilidini a�ar
    public static void UnlockLevel(int levelIndex)
    {

        if (PlayerPrefs.GetInt("Level" + levelIndex, 0) == 0)
        {
            PlayerPrefs.SetInt("Level" + levelIndex, 1); // Level kilidini a�
        }
    }

    // Bu metod, belirli bir levelin kilit durumunu kontrol eder
    public static bool IsLevelUnlocked(int levelIndex)
    {
        return PlayerPrefs.GetInt("Level" + levelIndex, 0) == 1; // Levelin kilidi a��ksa 'true' d�nd�r
    }

    // Bu metod, belirli bir leveli y�kler
    public void LoadLevel(int levelIndex)
    {
        if (IsLevelUnlocked(levelIndex))
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.Log("Level " + levelIndex + " hen�z kilidi a��lmam��!");
        }
    }

}
