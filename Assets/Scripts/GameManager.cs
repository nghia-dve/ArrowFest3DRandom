using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public float coin;
    [SerializeField]
    Text textCoin;
    [SerializeField]
    public GameObject btRestart;
    [SerializeField]
    public GameObject btWin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textCoin.text = "coin: " + coin;
    }
    public void RestartGame()
    {
        btRestart.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Win()
    {
        btWin.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 != null)
        {
            StartCoroutine(Loading(SceneManager.GetActiveScene().buildIndex + 1));
        }

    }
    IEnumerator Loading(int sceneIndex)
    {

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            yield return null;
        }
    }
}
