using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위한 네임스페이스 추가

public class MainMenuManager : MonoBehaviour
{
    [Header("Menu Items")]
    public GameObject continueButton;
    public List<MenuItemController> menuItems = new List<MenuItemController>();
    
    [Header("Scene Names")]
    public string settingsSceneName = "Settings"; // 설정 씬 이름
    
    // Start is called before the first frame update
    void Start()
    {
        // 게임 저장 데이터 확인
        bool hasSaveData = CheckForSaveData();
        
        // Continue 버튼 표시 여부 설정
        if (continueButton != null)
        {
            continueButton.SetActive(hasSaveData);
        }
    }

    // 저장된 게임 데이터가 있는지 확인
    private bool CheckForSaveData()
    {
        // PlayerPrefs를 사용한 간단한 저장 데이터 확인 예제
        // 실제 구현시 더 복잡한 저장 시스템을 사용할 수 있음
        return PlayerPrefs.HasKey("GameSaved") && PlayerPrefs.GetInt("GameSaved") == 1;
    }

    // 메뉴 항목 클릭 처리
    public void OnContinueClicked()
    {
        Debug.Log("Continue game");
        // 저장된 게임 불러오기 구현
    }

    public void OnNewGameClicked()
    {
        Debug.Log("New game");
        // 새 게임 시작 구현
    }

    public void OnLoadGameClicked()
    {
        Debug.Log("Load game");
        // 게임 불러오기 화면으로 전환
    }

    public void OnSettingsClicked()
    {
        Debug.Log("Settings 버튼 클릭됨");
        
        // 씬 존재 여부 확인 및 로드
        try {
            if (Application.CanStreamedLevelBeLoaded(settingsSceneName))
            {
                Debug.Log($"'{settingsSceneName}' 씬을 로드합니다.");
                SceneManager.LoadScene(settingsSceneName);
            }
            else
            {
                Debug.LogError($"'{settingsSceneName}' 씬이 빌드 설정에 포함되어 있지 않습니다!");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"씬 로드 중 오류 발생: {e.Message}");
        }
    }

    public void OnCreditsClicked()
    {
        Debug.Log("Credits");
        // 크레딧 화면으로 전환
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}