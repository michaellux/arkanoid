using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Camera gameCamera;
    [SerializeField] private static AudioSource foregroundMusic;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject bubbleFieldPrefab;
    private GameObject ballOnScene;
    private GameObject platformOnScene;
    private GameObject bubbleFieldOnScene;

    private UnityEvent addPointsToPlayer;
    private UnityEvent noMoreGoals;

    public StateMachine StateMachine { get; set; }

    public static GameManager instance;
    
    void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion

        StateMachine = new StateMachine();

        foregroundMusic = gameCamera.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (noMoreGoals == null)
        {
            noMoreGoals = new UnityEvent();
            noMoreGoals.AddListener(UIManager.instance.ShowFinishPanel);
        }
        if (addPointsToPlayer == null)
        {
            addPointsToPlayer = new UnityEvent();
            addPointsToPlayer.AddListener(CheckLeftGoals);
        }
    }

    public void InitPlayer()
    {
        SetPlayerStatus(PlayerStatuses.PlayerInGame);
    }

    public void InitPlayField()
    {
        SetBubbleFieldOnScene();
        SetBallOnPlayField();
        SetPlatformOnPlayField();
    }

    public void SetBubbleFieldOnScene()
    {
        bubbleFieldOnScene = Instantiate(bubbleFieldPrefab);
    }
    public void SetBallOnPlayField()
    {
        ballOnScene = Instantiate(ballPrefab, playerTransform);
    }

    public void SetPlatformOnPlayField()
    {
        platformOnScene = Instantiate(platformPrefab, playerTransform);
    }

    public void AddPointsToPlayer(int priceOfCoin)
    {
        player.AddScore(priceOfCoin);
        StartCoroutine(AddPoints());
    }
    private IEnumerator AddPoints()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("AddPoints");
        addPointsToPlayer.Invoke();
    }

    public void CheckLeftGoals()
    {
        if (player.GetStatus() == PlayerStatuses.PlayerInGame)
        {
            GameObject[] leftGoals = GameObject.FindGameObjectsWithTag("Goal");

            if (leftGoals.Length == 0)
            {
                SetPlayerStatus(PlayerStatuses.PlayerWin);
            }
        }
    }

    public void SetPlayerStatus(PlayerStatuses statusForAssign)
    {
        player.SetStatus(statusForAssign);
    }

    public void UpdateState()
    {
        StateMachine.FindOut(player.GetStatus());
    }

    public void RestartGame()
    {
        SetPlayerStatus(PlayerStatuses.PlayerInGame);
    }

    public void ResetAll()
    {
        ClearField();
        ResetPlayerScore();
    }

    public void ClearField()
    {
        Destroy(ballOnScene);
        Destroy(platformOnScene);
        Destroy(bubbleFieldOnScene);
    }

    public void ResetPlayerScore()
    {
        player.ResetScore();
    }
}
