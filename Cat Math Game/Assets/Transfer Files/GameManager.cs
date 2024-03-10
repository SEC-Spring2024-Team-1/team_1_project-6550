using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text additionProblemText;
    public Button[] answerButtons;
    public GameObject pauseMenu; // Reference to the pause menu GameObject
    public UIManager uiManager; // Reference to the UIManager

    private int operand1;
    private int operand2;
    private int correctAnswer;

    public static bool IsPaused = false;

    void Start()
    {
        GenerateAdditionProblem();
        if (pauseMenu != null)
            pauseMenu.SetActive(false); // Ensure the pause menu is hidden on game start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void GenerateAdditionProblem()
    {
        if (IsPaused) return; // Skip generating new problems if the game is paused

        operand1 = UnityEngine.Random.Range(1, 10);
        operand2 = UnityEngine.Random.Range(1, 10);
        correctAnswer = operand1 + operand2;

        additionProblemText.text = operand1 + " + " + operand2 + " = ?";

        // Shuffle the answers
        int[] answers = { correctAnswer, correctAnswer + 1, correctAnswer - 1 };
        Shuffle(answers);

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = answers[i].ToString();
        }
    }

    void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }

    public void CheckAnswer(Button button)
    {
        if (IsPaused) return; // Prevent checking answers if the game is paused

        int selectedAnswer = int.Parse(button.GetComponentInChildren<Text>().text);
        if (selectedAnswer == correctAnswer)
        {
            scoreManager.AddScore();
            Debug.Log("Correct answer! Score incremented.");
            uiManager.ShowAnswerNotification(true); // Call UIManager to show correct notification
        }
        else
        {
            Debug.Log("Incorrect answer.");
            uiManager.ShowAnswerNotification(false); // Call UIManager to show incorrect notification
        }

        GenerateAdditionProblem();
    }

    public void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f; // Stops/resumes game time

        if (pauseMenu != null)
            pauseMenu.SetActive(IsPaused); // Toggle the visibility of the pause menu
    }
}
