using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    #region Public Params
    public Text CurrentLevelTxt, NextLevelTxt;
    public Transform BarLevel;
    public float currentScore;
    public List<Level> Levels;
    public int MaxLevel;

    #endregion

    #region MonoBehaviour
    void Start()
    {
        UpdateLevel(0);
    }

    void Update()
    {     
        BarLevel.localScale = new Vector3(GameManager.Instance.CurrentLevel.Progresse / GameManager.Instance.CurrentLevel.ScoreLevel, 1, 1);
        if (GameManager.Instance.CurrentLevel.Progresse >= GameManager.Instance.CurrentLevel.ScoreLevel)
        {
            NextLevel();
        }
    }
    #endregion

    #region Public Methode
    public void UpdateLevel(int index)
    {
        GameManager.Instance.CurrentLevel = Levels[index];
        Camera.main.backgroundColor= Levels[index].ColorSkybox;
        CurrentLevelTxt.text = (index+1).ToString();
        NextLevelTxt.text = (index+ 2).ToString();
        BarLevel.localScale = new Vector3(0, 1, 1);
    }

    public void NextLevel()
    {
        UpdateLevel(GameManager.Instance.CurrentLevel.NumLevel + 1);
    }


    #endregion
}

[System.Serializable]
public class Level
{
    public int NumLevel;
    public float ScoreLevel,Progresse;
    public float TimeInstantiate;
    public float TimeDestroy;
    public float SpeedPlayer;
    public Color ColorSkybox;
    public float Range;
    public int MultipleNbrObstacle;
}
