using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextpage : MonoBehaviour
{
    public Button nextSceneButton;
    public Button previousSceneButton;

    void Start()
    {
        // 버튼에 클릭 이벤트 리스너 등록
        nextSceneButton.onClick.AddListener(LoadNextScene);
        previousSceneButton.onClick.AddListener(LoadPreviousScene);
    }

    void LoadNextScene()
    {
        // 현재 씬의 인덱스를 확인
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 다음 씬으로 넘어가기 (마지막 씬이라면 처음 씬으로 돌아감)
        SceneManager.LoadScene((currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
    void LoadPreviousScene()
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currentSceneIndex - 1 + SceneManager.sceneCountInBuildSettings) % SceneManager.sceneCountInBuildSettings);
    }
}