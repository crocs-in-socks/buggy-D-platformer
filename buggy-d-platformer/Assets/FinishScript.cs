using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameObject finishmenu;
    void Start()
    {
        finishmenu.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        finishmenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        StartCoroutine("Restartgame");
    }
    IEnumerator Restartgame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("One");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
