using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 게임종료. 전처리기를 이용해 에디터 아닐때 종료.
    /// </summary>
    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Play_Scene");
    }

    public void Deck()
    {
        SceneManager.LoadScene("1");
    }
}
