using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class ClickAnywhereCounter : MonoBehaviour
{
    public int score = 0; // Score counter
    public Text scoreText; // Drag your UI Text here
    public Text timerText; // Drag your UI Text here for timer (top right)
    public GameObject thingToActivate; // The thing you want to activate randomly

    public float checkInterval = 300f; // 5 minutes = 300 seconds
    private float timeUntilNextActivation; // Countdown timer

    void Start()
    {
        timeUntilNextActivation = checkInterval; // Initialize countdown
        StartCoroutine(RandomActivationRoutine());
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            score++;
            UpdateScoreUI();
        }

        UpdateTimerUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            // Countdown timer display
            int minutes = Mathf.FloorToInt(timeUntilNextActivation / 60f);
            int seconds = Mathf.FloorToInt(timeUntilNextActivation % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        // Decrease timer each frame
        if (timeUntilNextActivation > 0)
        {
            timeUntilNextActivation -= Time.deltaTime;
        }
    }

    IEnumerator RandomActivationRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);
            TryActivateRandomThing();
            timeUntilNextActivation = checkInterval; // Reset countdown after activation
        }
    }

    void TryActivateRandomThing()
    {
        int randomNumber = Random.Range(0, 10000);
        if (randomNumber < score)
        {
            print("YAY you got an event for being higher than " + randomNumber + "  GOOD JOB!!!!!!");
            if (thingToActivate != null)
            {
                thingToActivate.SetActive(true);
            }
        }
        else
        {
            print("sorry your number was lower than " + randomNumber + " so no event for you D:");
        }
    }
}
