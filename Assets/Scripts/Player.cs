using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerStatuses
{
    PlayerInGame,
    PlayerWin,
    PlayerLose
}

public class Player : MonoBehaviour
{
    [SerializeField] private int totalScore = 0;
    [SerializeField] private PlayerStatuses currentStatus = PlayerStatuses.PlayerInGame;

    private UnityEvent addedPoints;
    private UnityEvent changedStatus;

    public static Player instance = null;
    // Start is called before the first frame update
    void Start()
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

        if (addedPoints == null)
        {
            addedPoints = new UnityEvent();
            addedPoints.AddListener(UIManager.instance.UpdateScoreUI);
        }

        if (changedStatus == null)
        {
            changedStatus = new UnityEvent();
            changedStatus.AddListener(UIManager.instance.UpdateStatus);
            changedStatus.AddListener(UIManager.instance.ShowFinishPanel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int points)
    {
        totalScore += points;
        addedPoints.Invoke();
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public void SetStatus(PlayerStatuses assignedStatus)
    {
        currentStatus = assignedStatus;
        changedStatus.Invoke();
    }

    public PlayerStatuses GetStatus()
    {
        return currentStatus;
    }
}
