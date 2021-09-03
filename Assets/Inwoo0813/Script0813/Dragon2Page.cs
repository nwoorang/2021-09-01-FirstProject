using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
public class Dragon2Page : MonoBehaviour
{
    public PlayableDirector playableDirector001;
    public PlayableDirector playableDirector002;
    public PlayableDirector playableDirector003;
    public PlayableDirector playableDirector004;
    public PlayableDirector playableDirector005;
    //플레이어블디렉터에 타임라인을 실행하는 방법은 두가지가 있다.
    //(플레이어블디렉터를 비디오플레이어 ,타임라인을 비디오라고 생각하면 쉽다.)
    //디렉터 안에 이미 타임라인이 들어가 있는 상태라면 
    //        playableDirector.Play ();
    //이렇게 실행해주면 된다.
    //없는경우
    //        playableDirector.Play (timeline);
    //이렇게 직접 지정해서 실행한다.

    bool endCheckTrack=true;
    Rito.WeightedRandomPicker<string> wrPicker = new Rito.WeightedRandomPicker<string>();//가중치 관련 스크립트

    public float WaitTime;
    //패턴 사이의 간격 조절

    public GameObject Dragon;
    public PlayableDirector StartCollider;
    public List<GameObject> hpbar;
    void Start()
    {
       
        // StartCoroutine("Pattern001");
        // GetComponent<VisualEffect>().Play();
        // GetComponent<playable>().


        //여기서 원하는 아이템과 가중치를 추가할수있음
        wrPicker.Add(

    ("PlayableDirector001", 332),
    ("PlayableDirector002", 332),
    ("PlayableDirector003", 332),
    ("PlayableDirector004", 332),
    ("PlayableDirector005", 1332)
                    );


    }

    IEnumerator PlayableDirector001()//브레스
        {
        yield return new WaitForSeconds(WaitTime);//다음 패턴과의 간격, 난이도로 직결됨
        playableDirector001.Play();
        yield return new WaitForSeconds(0.1f);
        
        }

        IEnumerator PlayableDirector002()//윙어택
        {
        yield return new WaitForSeconds(WaitTime);
        playableDirector002.Play();
            yield return new WaitForSeconds(0.1f);
        }

        IEnumerator PlayableDirector003()//상중하 돌진공격
        {
        yield return new WaitForSeconds(WaitTime);
        playableDirector003.Play();
            yield return new WaitForSeconds(0.1f);
        }

        IEnumerator PlayableDirector004()//2페이즈 시작
        {
        yield return new WaitForSeconds(WaitTime);
        playableDirector004.Play();
            yield return new WaitForSeconds(0.1f);
        }

        IEnumerator PlayableDirector005()//강림 
        {
        yield return new WaitForSeconds(WaitTime);
        playableDirector005.Play();
            yield return new WaitForSeconds(0.1f);
        }

    public void EndCheckTrack() //하나의 타임라인이 무사히 끝나면 끝부분에 시그널 이미터가 발생해서 이 함수를 호출
    {                           //Signal Emitter_2PagePattern
        string pick = wrPicker.GetRandomPick();
        StartCoroutine(pick);
    }

    public void Setactive()//Signal Emitter_StartCollider
    {
        Dragon.SetActive(true);
        EndCheckTrack();
        StartCollider.Pause();
    }

    public void Hpbar(int num)//HP02,03_Slider_onchangedvalue
    {
        if (num == 0)
        {
            if (hpbar[num].GetComponent<Slider>().value <= 0) { WaitTime = WaitTime / 2; Dragon.SetActive(false); }
        }
        else
        {
            if (hpbar[num].GetComponent<Slider>().value <= 0) Dragon.SetActive(false);
        }

    }
}
