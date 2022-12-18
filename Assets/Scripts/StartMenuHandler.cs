using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameInputField;

    public void StartGame()
    {
        GameProgress.Instance.playerName = playerNameInputField.text;
        SceneManager.LoadScene(1);
    }
}
