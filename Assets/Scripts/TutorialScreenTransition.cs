using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScreenTransition : MonoBehaviour
{
    int thisSlide = 0;
    //public List<Slide> slides = new List<Slide>();
    public List<Sprite> slidesImages = new List<Sprite>();
    [SerializeField] Image screen;
    [SerializeField] GameObject buttonForward;
    [SerializeField] GameObject buttonBackward;
    [SerializeField] GameObject buttonSkip;

    private void Awake()
    {
        screen = GetComponent<Image>();
        if(slidesImages.Count == 0)
        {
            Debug.LogError("ъ осярни, днаюбэ б лемъ йюдпнб");
        }
        //screen.sprite = slides[thisSlide].slide;
        screen.sprite = slidesImages[0];
    }

    public void ChangeSlideForward()
    {
        thisSlide += 1;
        screen.sprite = slidesImages[thisSlide];
        CheckSlideIndex();
    }

    public void ChangeSlideBackward()
    {
        thisSlide -= 1;
        screen.sprite = slidesImages[thisSlide];
        CheckSlideIndex();
    }

    private void CheckSlideIndex()
    {
        if (thisSlide == 0)
        {
            buttonBackward.SetActive(false);
        }
        if (thisSlide == slidesImages.Count - 1)
        {
            buttonForward.SetActive(false);
        }
        if ((thisSlide < slidesImages.Count - 1) && (thisSlide > 0))
        {
            buttonForward.SetActive(true);
            buttonBackward.SetActive(true);
        }
    }

    public void SkipSlides()
    {
        SceneManager.LoadScene("0LV");
    }

}
