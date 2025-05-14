using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToWaitBeforeExit;

    public void OnPlayerDeath()
    {
        Invoke(nameof(EndGame), timeToWaitBeforeExit);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
