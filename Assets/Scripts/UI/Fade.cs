using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fade : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private TextMeshProUGUI hopeText;
    private bool isTyping = false;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;

        hopeText = GetComponentInChildren<TextMeshProUGUI>();

        HealthController playerHealth = GameObject.FindWithTag("Player").GetComponent<HealthController>();
        playerHealth.OnDied.AddListener(PlayerDied);
    }

    public void PlayerDied()
    {
        if (!isTyping)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        float duration = 2f; // Duration of the fade in seconds
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / duration);
            yield return null;
        }

        canvasGroup.alpha = 1f; // Ensure the image is fully visible at the end

        //StartCoroutine(TypeWriterEffect("you are dead..."));
    }

    /*
    IEnumerator TypeWriterEffect(string message)
    {
        foreach (char letter in message)
        {
            hopeText.text += letter;
            yield return new WaitForSeconds(1f);
        }
    }
    */
}