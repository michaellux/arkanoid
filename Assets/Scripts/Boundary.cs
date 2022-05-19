using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boundary : MonoBehaviour
{
    private static Boundary instance = null;

    private void Awake()
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
        #endregion
    }

    void OnTriggerExit2D()
    {
        GameManager.instance.SetPlayerStatus(PlayerStatuses.PlayerLose);
    }
}
