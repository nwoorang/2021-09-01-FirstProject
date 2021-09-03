using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform Rect_BackGround;
    [SerializeField] private RectTransform Rect_Joystick;

    private float radius;

    [SerializeField] private GameObject Go_Player;
    [SerializeField] private float MoveSpeed;

    private bool IsTouch = false; //드래그를 했나 안했나
    private Vector3 MovePosition; //속도 저장할 벡터


    [SerializeField] private SpriteRenderer sp; //게임 캐릭터 좌우 판정
    [SerializeField] private Animator pAnimator; //애니메이터

    public float YAxis;//조이스틱의 y좌표 테스트
    public static bool DownCheck;//조이스틱의 y좌표 테스트
    void Start()
    {
        radius = Rect_BackGround.rect.width * 0.5f;//조이스틱구간의 지름에 0.5를 곱해서 반지름 계산
        DownCheck = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (IsTouch)//플레이어 이동
            Go_Player.transform.position += MovePosition;
    }

    public void OnDrag(PointerEventData eventData) //드래그를 할때마다 호출
    {
        IsTouch = true; //플레이어가 움직일수 있게 허락
        Vector2 value = eventData.position - (Vector2)Rect_BackGround.position; //조이스틱구간의 원점에서 손가락을 누른 지점까지의 벡터값

        value = Vector2.ClampMagnitude(value, radius); //조이스틱구간의 반지름을 벗어나지 못하게 제한
        Rect_Joystick.localPosition = value;//조이스틱의 손잡이 부분의 위치 조정

        value = value.normalized; //노멀라이즈 시켜서 방향만 뽑아낸다.
        MovePosition = new Vector3(value.x * MoveSpeed * Time.deltaTime,0f, 0f);//좌우로 움직이기
        Dash.DashDir = value.x; //대쉬 스크립트에 조이스틱의 좌우방향 전달
        if (value.y<YAxis)//y좌표 테스트
        {
            Debug.Log("조이스틱의 y좌표가 0이하 입니다"+ DownCheck);
            DownCheck = true;
        }

        if (value.x < 0)        //스프라이트 좌우 판정 체크
        {
            sp.flipX = true;
            pAnimator.SetBool("Run", true);
        }
        else if (value.x > 0)
        {
            sp.flipX = false;
            pAnimator.SetBool("Run", true);
        }


    }
    public void OnPointerDown(PointerEventData eventData)//버튼을 클릭했다면 
    {
        IsTouch = false;//플레이어가 못 움직이게 제어
        Rect_Joystick.localPosition = eventData.position - (Vector2)Rect_BackGround.position; //조이스틱의 손잡이 부분의 위치 조정
        //실질적으로 움직임을 주지는 않고 조이스틱만 움직임
    }

    public void OnPointerUp(PointerEventData eventData)//버튼에서 손을 떼었다면
    {
        IsTouch = false;//플레이어가 못 움직이게 제어
        Rect_Joystick.localPosition = Vector3.zero;//조이스틱의 손잡이 부분의 위치 조정
        pAnimator.SetBool("Run", false);
    }
}
