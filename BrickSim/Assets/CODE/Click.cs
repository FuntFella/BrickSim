using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ClickAnywhereCounter : MonoBehaviour
{
    public int score = 0; // Score counter
    public Text scoreText; // Drag your UI Text here

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            score++;
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
