using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameButton : MonoBehaviour
{
    public AudioSource playButton;

    // Adjust this delay time according to the length of your audio clip
    public float delayBeforeLoad = 0.25f;

    public void LoadGameScene()
    {
        // Play the audio
        playButton.Play();

        // Delay the scene transition
        Invoke("LoadSceneWithDelay", delayBeforeLoad);
    }

    private void LoadSceneWithDelay()
    {
        // Load the "game" scene after the specified delay
        SceneManager.LoadScene("game");
    }
}