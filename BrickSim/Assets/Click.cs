using UnityEngine;
using UnityEngine.InputSystem;  // <- new system

public class ClickAnywhereCounter : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    private int score = 0;

    void Start()
    {
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
