using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //public float monsterSpeed = 1;
    //public float monsterAtk = 3;
    //public float monsterMaxHP = 35;
    //public float monsterCurrentHp = 35;


    Rigidbody2D rigid;
    //행동지표를 결정할 변수
    public int nextMove;

    public int s;

    // Start is called before the first frame update
    //변수 초기화
    //시작시 한번만 실행
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think(); //행동지표(nextMove)를 바꿔줄 함수 아래에 void

        Invoke("Think", 5);     //invoke 주어진 시간이 지난 뒤, 지정된 함수를 실행하는 함수/ 5초뒤에 ""함수 실행
    
    }

    // Update is called once per frame

    //물리기반 1초에 5~60번 실행
    void FixedUpdate()
    {
        //move
        rigid.velocity = new Vector2(nextMove*s, rigid.velocity.y); // -1 왼쪽이동, rigid~ 현재 가지고있는 y축의 속도 0은 안됨
    
        //platform check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*1.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); //에디터상 레이저
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1,LayerMask.GetMask("platform"));
        if (rayHit.collider == null)
        {
            Debug.Log(rayHit.collider);
            //rigid.velocity = new Vector2(nextMove * -1, rigid.velocity.y);
            nextMove = nextMove * -1; //방향을 반대로 바꿔줌
           // rigid.velocity = new Vector2(nextMove *s, rigid.velocity.y);
            //nextMove *= -1; //도 같음
            CancelInvoke(); // 인보크를 캔슬시킴
            Invoke("Think", 5);

        }

    }

    //행동지표(nextMove)를 바꿔줄 함수
    //재귀 함수: 자신을 스스로 호출하는 함수
    void Think()
    {
        //Range():최소 ~ 최대 범위의 랜덤 수 생성(최대 제외 즉 2를 넣으면 1까지만 포함됨 인트가 아닐경우 1.9999??)
        nextMove = Random.Range(-1, 2); // -1일때 왼쪽으로 이동, 0일 대 idle ,오른쪽일때 1

        //float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", 5); //void awake와 해당부분에 에 invoke 로 딜레이를 주지 않으면 엄청난 속도로 중첩실행됨
    
    }
}
