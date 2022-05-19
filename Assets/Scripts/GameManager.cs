using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Camera gameCamera;
    [SerializeField] private static AudioSource foregroundMusic;

    private UnityEvent addPointsToPlayer;
    private UnityEvent noMoreGoals;

    public StateMachine StateMachine { get; set; }

    public static GameManager instance = null;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPointsToPlayer(int priceOfCoin)
    {
        player.AddScore(priceOfCoin);
        StartCoroutine(AddPoints());
    }
    private IEnumerator AddPoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            addPointsToPlayer.Invoke();
        }
    }

    public void CheckLeftGoals()
    {
        GameObject[] leftGoals = GameObject.FindGameObjectsWithTag("Goal");

        if (leftGoals.Length == 0)
        {
            SetPlayerStatus(PlayerStatuses.PlayerWin);
        }
    }

    public void SetPlayerStatus(PlayerStatuses statusForAssign)
    {
        if (player.GetStatus() == PlayerStatuses.PlayerInGame)
        {
            player.SetStatus(statusForAssign);
        }
    }
}
