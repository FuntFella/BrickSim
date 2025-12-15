using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class ClickAnywhereCounter : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text timerText;

    // List of scripts that can be activated
    public List<MonoBehaviour> scriptsToActivate;

    public float checkInterval = 300f;
    private float timeUntilNextActivation;

    void Start()
    {
        timeUntilNextActivation = checkInterval;
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
            scoreText.text = "Score: " + score;
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeUntilNextActivation / 60f);
            int seconds = Mathf.FloorToInt(timeUntilNextActivation % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }

        if (timeUntilNextActivation > 0)
            timeUntilNextActivation -= Time.deltaTime;
    }

    IEnumerator RandomActivationRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);
            TryActivateRandomScript();
            timeUntilNextActivation = checkInterval;
        }
    }

    void TryActivateRandomScript()
    {
        int randomNumber = Random.Range(0, 10);

        if (randomNumber < score)
        {
            print($"you beat {randomNumber}. fun things coming your way!");

            if (scriptsToActivate != null && scriptsToActivate.Count > 0)
            {
                // Pick a random script from the list
                int index = Random.Range(0, scriptsToActivate.Count);
                MonoBehaviour chosenScript = scriptsToActivate[index];

                if (chosenScript != null)
                    chosenScript.enabled = true;
            }
        }
        else
        {
            print($"YOU SUCK!!!!1 {randomNumber} <--- THIS NUMBER BEAT YOUR PUNY SCORE");
        }
    }
}
