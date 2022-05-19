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
    private readonly int startScoreValue = 0;
    [SerializeField] private int totalScore;
    [SerializeField] private PlayerStatuses currentStatus = PlayerStatuses.PlayerInGame;

    private UnityEvent changedPoints;
    private UnityEvent changedStatus;

    public static Player instance;

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

        if (changedPoints == null)
        {
            changedPoints = new UnityEvent();
            changedPoints.AddListener(UIManager.instance.UpdateScoreUI);
        }

        if (changedStatus == null)
        {
            changedStatus = new UnityEvent();
            changedStatus.AddListener(UIManager.instance.UpdateStatusUI);
            changedStatus.AddListener(GameManager.instance.UpdateState);
        }

        totalScore = startScoreValue;
        changedPoints.Invoke();
    }

    public void ResetScore()
    {
        totalScore = startScoreValue;
        changedPoints.Invoke();
    }

    public void AddScore(int points)
    {
        totalScore += points;
        changedPoints.Invoke();
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
