using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GearQuizManager : MonoBehaviour
{
    public GameObject quizPanel;
    public GameObject startQuizButton;

    public TMP_Text questionText;
    public TMP_Text feedbackText;
    public TMP_Text scoreText;

    public Button[] answerButtons;
    

    public Button submitButton;
    public Button nextButton;
    public Button restartButton;

    private string[] questions =
    {
        "What is the main function of a gear?",
        "Which gear receives motion from the power source?",
        "How do two connected external gears rotate?",
        "What is Gear 2 called in our demonstration?",
        "What happens when Gear 1 rotates?"
    };

    private string[,] answers =
    {
        { "Transfer motion", "Store energy", "Produce electricity" },
        { "Driven gear", "Driving gear", "Brake gear" },
        { "Same direction", "Opposite directions", "No rotation" },
        { "Driving gear", "Driven gear", "Clutch" },
        { "Gear 2 also rotates", "Nothing happens", "Both stop" }
    };

    private int[] correctAnswers = { 0, 1, 1, 1, 0 };

    private int currentQuestion = 0;
    private int selectedAnswer = -1;
    private int score = 0;
    private bool answered = false;

    void Start()
    {
        quizPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void OpenQuiz()
    {
        Debug.Log("QUIZ BUTTON CLICKED!");

        startQuizButton.SetActive(false);

        quizPanel.SetActive(true);
        currentQuestion = 0;
        score = 0;
        ShowQuestion();
    }

    void ShowQuestion()
    {
        selectedAnswer = -1;
        answered = false;

        questionText.text =
            "Question " + (currentQuestion + 1) +
            " of 5\n\n" + questions[currentQuestion];

        feedbackText.text = "";
        for (int i = 0; i < 3; i++)
{
    TMP_Text answerText = answerButtons[i].GetComponentInChildren<TMP_Text>();

    answerText.text = answers[currentQuestion, i];

    answerButtons[i].interactable = true;

    // Reset button colour for the new question
    answerButtons[i].image.color = Color.white;
}

        submitButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        scoreText.text = "Score: " + score;
    }

    public void SelectAnswer(int answerIndex)
    {
        if (answered) return;

        selectedAnswer = answerIndex;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
            answerButtons[i].image.color = Color.white;
        }

        answerButtons[answerIndex].image.color =
            new Color(0.4f, 0.8f, 1f);

        TMP_Text answerText =
            answerButtons[answerIndex].GetComponentInChildren<TMP_Text>();

        feedbackText.text = "Selected: " + answerText.text;
    }

    public void SubmitAnswer()
    {
        if (selectedAnswer == -1 || answered)
        {
            feedbackText.text = "Please select an answer!";
            return;
        }

        answered = true;

        if (selectedAnswer == correctAnswers[currentQuestion])
        {
            score++;
            feedbackText.text = "Correct answer! Well done!";
        }
        else
        {
            feedbackText.text =
                "Incorrect! Correct answer: " +
                answers[currentQuestion, correctAnswers[currentQuestion]];
        }

        for (int i = 0; i < 3; i++)
        {
            answerButtons[i].interactable = false;
        }

        submitButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);

        scoreText.text = "Score: " + score;
    }

    public void NextQuestion()
    {
        currentQuestion++;

        if (currentQuestion < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            ShowResult();
        }
    }

    void ShowResult()
    {
        questionText.text = "QUIZ COMPLETED!";

        feedbackText.text =
            "Your final score: " + score + " / 5";

        scoreText.text = "Final Result";

        nextButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartQuiz()
    {
        OpenQuiz();
    }
}