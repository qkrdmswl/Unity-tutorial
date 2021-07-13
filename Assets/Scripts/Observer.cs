using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // 캐릭터의 Transform 확인 , JohnLemon 위치 더 쉽게 엑세스하고 그에게 명확한 시야가 있는지 여부 판단
    public Transform player;
    public GameEnding gameEnding;
    bool m_IsPlayerInRange;

    // OnTriggerEnter 호출 될 때마다 JohnLemon 실제로 범위 내에 있는지 확인
    void OnTriggerEnter(Collider other)
    {
        // if문 추가해서 확인
        if(other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    // OnTriggerEnter의 반대인 특수 method
    void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray))
            {

            }
            if(raycastHit.collider.transform == player)
            {

            }
        }
    }
}
