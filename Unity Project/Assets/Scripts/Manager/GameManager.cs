using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { StartGame=0,GameOver=1,Pause=2}

public class GameManager : MonoBehaviour
{
    #region Static Params
    public static GameManager Instance;
    #endregion

    #region Public Params
    public Level CurrentLevel;
    public Transform MyPlanet, ObstacleParent,MyPlayer;

    public Obstacle MyObstacles;

    public GameState State;

    public float Count;

    public Animation PanelMainMenu,PanelGamePlay,PanelGameOver;

    public float Score;
    public Text ScoreTxt, higthScoreTxt,ScoreGame;

    #endregion

    #region MonoBehaviour
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        higthScoreTxt.text = Mathf.Round(PlayerPrefs.GetFloat("ScoreSave")).ToString();
    }
    void Update()
    {
        if (State == GameState.StartGame)
        {
            ObstacleManager();
            Score += Time.deltaTime;
            CurrentLevel.Progresse += Time.deltaTime ;
            ScoreTxt.text =Mathf.Round(Score).ToString();
        }
    }

    #endregion

    #region Public Methode

    public void ObstacleManager()
    {
        if (Count <= CurrentLevel.TimeInstantiate)
            Count += Time.deltaTime;
        else
        {
           for(int i=0;i<CurrentLevel.MultipleNbrObstacle;i++)
            CreateObstacle();
        }
    }

    public void CreateObstacle()
    {
        float min = MyPlayer.GetChild(1).position.x - CurrentLevel.Range;
        float max = MyPlayer.GetChild(1).position.x + CurrentLevel.Range;

        Vector3 _NewPos = new Vector3(Random.Range(min, max), MyPlayer.GetChild(1).position.y, MyPlayer.GetChild(1).position.z);
        Obstacle _obstacle1 = Instantiate(MyObstacles, _NewPos, Quaternion.identity);
        _obstacle1.TimeDestroyObstacle = CurrentLevel.TimeDestroy;
        _obstacle1.transform.SetParent(ObstacleParent);

        Obstacle _obstacle2 = Instantiate(MyObstacles, ObstacleParent.position, Quaternion.identity);
        _obstacle2.RandomPostion = true;
        _obstacle2.TimeDestroyObstacle = CurrentLevel.TimeDestroy;
        _obstacle2.transform.SetParent(ObstacleParent);
        Count = 0;
    }
    #endregion

    #region State Methode

    public void StartGame()
    {
        State = GameState.StartGame;
        PanelMainMenu.Play("Close");
        PanelGamePlay.Play("Open");
        Score = 0;
        ScoreTxt .text= "";
    }

    public void GameOver()
    {
        State = GameState.GameOver;
        PanelGameOver.Play("Open");
        PanelGamePlay.Play("Close");

        ScoreGame.text= Mathf.Round(Score).ToString();

        foreach (Transform t in ObstacleParent)
        {
            Destroy(t.gameObject);
        }

        UpdateHigthScore();
    }

    public void  UpdateHigthScore()
    {
        if (PlayerPrefs.GetFloat("ScoreSave") < Score)
        {
            PlayerPrefs.SetFloat("ScoreSave", Score);
            higthScoreTxt.text = Mathf.Round(Score).ToString();
        }    
    }

    public void Home()
    {
        PanelGameOver.Play("Close");
        PanelMainMenu.Play("Open");
        SceneManager.LoadScene(0);
    }
    #endregion
}
