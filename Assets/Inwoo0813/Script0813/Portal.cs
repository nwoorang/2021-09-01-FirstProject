using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject AnotherPortal;
    private bool SceneChangeCheck;
    private void Start()
    {
        SceneChangeCheck = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("포탈안에 들어왔습니다.");
        if (SceneChangeCheck == false) //화면 전환이 이루어 지고 있지 않다면
        {
            if (JoyStick.DownCheck == true)//조이스틱을 내리면
            {
                collision.transform.position = AnotherPortal.transform.position;//플레이어 위치를 다음 포탈로
                Debug.Log("연결된 포탈로 이동합니다.");
                StartCoroutine("testmethod");//다음 포탈을 제어할 코루틴 실행
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)//콜라이더 안에 들어온 뒤 1프레임마다 호출
    {
        JoyStick.DownCheck = false;
    }

    public IEnumerator testmethod()
    {
        AnotherPortal.GetComponent<Portal>().SetFalse();//화면 전환중에는 포탈 사용 금지
        yield return new WaitForSeconds(3f);//화면 전환중
        AnotherPortal.GetComponent<Portal>().SetTrue();//포탈 사용 가능
    }

    private void SetTrue()
    {
        SceneChangeCheck = false;
    }

    private void SetFalse()
    {
        SceneChangeCheck = true;
    }


}

