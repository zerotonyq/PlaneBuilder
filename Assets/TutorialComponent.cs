using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialComponent : MonoBehaviour
{
    [SerializeField] private List<Sprite> tutorialSprites;
    [SerializeField] private List<TextMeshProUGUI> texts;
    [SerializeField] private Image image;

    [SerializeField] private int currentStep = 0;
    
    [ContextMenu("nextStep")]
    public void NextStep()
    {
        if (currentStep + 1 >= tutorialSprites.Count)
            return;
        
        
        texts[currentStep].gameObject.SetActive(false);
        currentStep++;
        image.sprite = tutorialSprites[currentStep];
        texts[currentStep].gameObject.SetActive(true);
    }

    [ContextMenu("previousStep")]
    public void PreviousStep()
    {
        if (currentStep - 1 < 0)
            return;

        texts[currentStep].gameObject.SetActive(false);
        currentStep--;
        image.sprite = tutorialSprites[currentStep];
        texts[currentStep].gameObject.SetActive(true);
    }
} 
