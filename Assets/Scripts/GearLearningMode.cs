using UnityEngine;
using TMPro;

public class GearLearningMode : MonoBehaviour
{
    public TMP_Text learningText;

    public GameObject startButton;
    public GameObject previousButton;
    public GameObject nextButton;
    public GearMotionDemo motionDemo;

    private int currentStep = 0;

    public GearHighlight gear1;
    public GearHighlight gear2;

    private string[] learningSteps =
    {
        "STEP 1: INTRODUCTION\n\n" +
        "A gear is a rotating mechanical component " +
        "used to transfer motion and force.",

        "STEP 2: DRIVING GEAR\n\n" +
        "Gear 1 is the driving gear. " +
        "It receives rotational motion from a power source.",

        "STEP 3: DRIVEN GEAR\n\n" +
        "Gear 2 is the driven gear. " +
        "It receives motion from Gear 1.",

        "STEP 4: GEAR MOVEMENT\n\n" +
        "When Gear 1 rotates, it makes Gear 2 rotate " +
        "in the opposite direction.",

        "STEP 5: SUMMARY\n\n" +
        "Two connected gears transfer rotational motion. " +
        "The driving gear moves the driven gear."
    };

    void Start()
    {
        previousButton.SetActive(false);
        nextButton.SetActive(false);
    }

    public void StartLearning()
    {
        currentStep = 0;

        startButton.SetActive(false);
        previousButton.SetActive(true);
        nextButton.SetActive(true);

        ShowStep();
    }

    public void NextStep()
    {
        if (currentStep < learningSteps.Length - 1)
        {
            currentStep++;
            ShowStep();
        }
    }

    public void PreviousStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            ShowStep();
        }
    }

    void ShowStep()
    {
        learningText.text = learningSteps[currentStep];

        // Remove previous highlights
        gear1.HighlightGear(false);
        gear2.HighlightGear(false);

        // Highlight gears according to the learning step
        if (currentStep == 1)
        {
            gear1.HighlightGear(true);
        }
        else if (currentStep == 2)
        {
            gear2.HighlightGear(true);
        }
        else if (currentStep == 3)
        {
            gear1.HighlightGear(true);
            gear2.HighlightGear(true);
        }

        previousButton.SetActive(currentStep > 0);

        nextButton.SetActive(
            currentStep < learningSteps.Length - 1
        );

        if (currentStep == learningSteps.Length - 1)
        {
            learningText.text += "\n\nYou have completed the lesson!";
        }
        // Start gear demonstration at Step 4
        if (currentStep == 3)
        {
            motionDemo.StartDemonstration();
        }
        else
        {
            motionDemo.StopDemonstration();
        }
    }
}