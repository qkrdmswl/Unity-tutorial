using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;  // fadeout 시간 조절 
    public float displayImageDuration = 1f;  // 플레이어가 잠시 동안 이미지 볼 수 있도록 조절
    public GameObject player;   // 게임 오브젝트 변수 선언
    
    // Inspector에서 할당 할 수 있는 Canvas Group 구성요소에 대한 공용 변수 선언
    public CanvasGroup exitBackgroundImageCanvasGroup; 
    public CanvasGroup caughtBackgroundImageCanvasGroup; 

    bool m_IsPlayerAtExit;  // fade 시작 시기를 알기 위해 bool 타입 변수 선언
    bool m_IsPlayerCaught;
    float m_Timer;

    // 플레이어가 제어하는 GameObject 감지하기
    void OnTriggerEnter (Collider other)
    {
        // JohnLemon이 Box Collider를 칠 때만 엔딩이 트리거 되도록 if문 추가
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        // 만약 m_IsPlayerAtExit == true면
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
            gameEnding.CaughtPlayer ();
        }
    }

    void EndLevel()
    {

        void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart)

        // 타이머 설정
        m_Timer += Time.deltaTime;

        // Canvas Group의 알파 설정
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if(doRestart) // 타이머가 지속 시간보다 길면 페이드 완료
            {
                SceneManager.LoadScene(0);  
            }
            else 
            {
                Application.Quit();
            }
        }
    }
}
