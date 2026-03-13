using TMPro;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("Just for debugging")] string ipAddress;
    [SerializeField] int port;

    private ROSConnection ros; // ros connection

    private void Awake()
    {
        ros = ROSConnection.GetOrCreateInstance();
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(ros.gameObject);

        if (!string.IsNullOrEmpty(ipAddress) && port != 0)
        {
            Debug.Log($"Conectare automată din Inspector la: {ipAddress}:{port}");
            ros.Connect(ipAddress, port);
        }
    }

    public void NextScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        Debug.Log($"Incercare de conectare din UI la: {ipAddress}:{port}");
        ros.Connect(ipAddress, port);

        SceneManager.LoadScene(i + 1);
    }

    public void PreviousScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i - 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReadIPField(string s)
    {
        ipAddress = s;
        Debug.Log($"IP citit: {ipAddress}");
        if (ROSConnection.IPFormatIsCorrect(ipAddress))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void ReadPortField(string s)
    {
        if (int.TryParse(s, out int parsedPort))
        {
            port = parsedPort;
            Debug.Log($"Port citit: {port}");
        }
        else
        {
            Debug.LogWarning("Format port invalid!");
        }
    }
}