using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlideshowController : MonoBehaviour
{
    public Image[] slides; // Assign your slides in the Inspector
    public float displayTime = 8f; // Time each slide is displayed

    private int currentSlideIndex = 0;

    void Start()
    {
        StartCoroutine(ShowSlides());
    }

    IEnumerator ShowSlides()
    {
        while (currentSlideIndex < slides.Length)
        {
            for (int i = 0; i < slides.Length; i++)
            {
                slides[i].gameObject.SetActive(i == currentSlideIndex);
            }
            yield return new WaitForSeconds(displayTime);
            currentSlideIndex++;
        }


        SceneManager.LoadScene("MapScene");
    }
}
