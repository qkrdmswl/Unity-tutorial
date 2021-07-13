using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;  // Animator 구성요소에 엑세스 하기 위해 필요
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation =  Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();  // Animator 구성요소에 대한 참조 설정
         m_Rigidbody = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");  // 수평 변수 생성
        float vertical = Input.GetAxis("Vertical");      // 수직 변수 생성

        m_Movement.Set(horizontal, 0f, vertical);  // 변수 값 설정
        m_Movement.Normalize ();


        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);  // 플레이어 입력이 있는지 확인
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);   // 마찬가지로 플레이어 입력이 있는지 확인
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);   //  IsWalking 매개 변수 설정

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}
