using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI winText;

    public void ShowWinner(string winner)
    {
        winPanel.SetActive(true);
        winText.SetText("Player " + winner + " Win!");
        FindObjectOfType<BallController>().gameObject.SetActive(false);
    }

    public void RematchButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
