using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    public TMP_Text scoreText;

    public ScoreManager scoreManager;

    private void Update()
    {
        // Access the score property directly
        scoreText.text = scoreManager.score.ToString();
    }
}
