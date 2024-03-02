using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject correctAnswerNotification; // Assign in the Inspector
    public GameObject wrongAnswerNotification; // Assign in the Inspector

    // Optionally, reference for initial UI element to focus on in the current scene
    public GameObject initialUIElement; // Assign in the Inspector if needed

    // Start is called before the first frame update
    void Start()
    {
        // Ensure notifications are not visible at the start
        correctAnswerNotification.SetActive(false);
        wrongAnswerNotification.SetActive(false);

        // Optionally, set the initial focus on a UI element if specified
        if (initialUIElement != null)
        {
            // Ensure this runs after all UI setup is complete
            StartCoroutine(SetInitialFocus());
        }
    }

    private IEnumerator SetInitialFocus()
    {
        // Wait for end of frame to ensure all UI elements are properly initialized
        yield return new WaitForEndOfFrame();
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(initialUIElement);
    }

    // Public method to show notification based on answer correctness
    public void ShowAnswerNotification(bool isCorrect)
    {
        if (isCorrect)
        {
            StartCoroutine(ShowNotification(correctAnswerNotification));
        }
        else
        {
            StartCoroutine(ShowNotification(wrongAnswerNotification));
        }
    }

    // Coroutine to handle showing a notification and automatically hiding it after a delay
    private IEnumerator ShowNotification(GameObject notification)
    {
        notification.SetActive(true);
        yield return new WaitForSeconds(1); // Adjust delay as needed
        notification.SetActive(false);
    }
}
