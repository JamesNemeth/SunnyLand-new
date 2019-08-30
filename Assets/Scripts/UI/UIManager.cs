using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Text scoreText;

    public void UpdateScore(int score)
    {
        // Change the score Text to updates value
        scoreText.text = "Score: " + score.ToString();
    }
}
