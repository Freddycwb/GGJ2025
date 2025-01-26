using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool _isGameStarted;
    private bool _isGameOver;
    [SerializeField] private InvokeAfterTimer countdown;

    void Update()
    {
        if (!_isGameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            _isGameStarted = true;
            countdown.StartTimer();
        }
        if (_isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            _isGameOver = false;
            SceneManager.LoadScene("Game");
        }
    }

    public void SetIsGameOver(bool value)
    {
        _isGameOver = value;
    }
}
