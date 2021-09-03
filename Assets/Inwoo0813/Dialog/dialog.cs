using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class SerializationDialog<T>
{
    public SerializationDialog(List<T> _target) => target = _target;
    public List<T> target;
}
//강사도 자세히 모른다고 하니 하나의 공식이라고 생각하자
[System.Serializable]
public class DialogClass
{
    public DialogClass(string _Line)
    { Line = _Line;}

    public string Line;
}
//숫자같은것도 string으로 하는 이유는 json에서 제대로 되지 않기 때문에

public class dialog : MonoBehaviour
{
    public TextAsset DialogDatabase;
    public List<DialogClass> AllDialog;
    string FilePath;
    public List<TextMeshProUGUI> Text;
    int DialogNum=0;
    public PlayableDirector StartCollider;
    public List<GameObject> hpbar;
    public GameObject DialogImg;

    private void Start()
    {
        string[] line = DialogDatabase.text.Substring(0, DialogDatabase.text.Length).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {

            AllDialog.Add(new DialogClass(line[i]));
        }
        FilePath = Application.persistentDataPath + "/Dialog.txt";

    }
    public void CallText()
    {
        
        //AllDialog[3].Line=ㅡ2페이즈
        //AllDialog[8].Line=-부활
        //AllDialog[12].Line=ㅡ사망
        if (DialogNum < AllDialog.Count) DialogNum++;
        if (DialogNum == 3) { DialogImg.SetActive(false); StartCollider.Play(); Text[0].text = " "; Text[1].text = " "; return; }
        if (DialogNum == 6) { Text[1].text = AllDialog[DialogNum].Line; return; }
        if (DialogNum == 7) {Text[1].text = " ";}
        if (DialogNum  == 8) { DialogImg.SetActive(false); StartCollider.Play(); Text[0].text = " "; Text[1].text = " "; return; }
        if (DialogNum  == 12) { DialogImg.SetActive(false); StartCollider.Play(); Text[0].text = " "; Text[1].text = " "; return; }
        if (DialogNum == 14) { DialogImg.SetActive(false); StartCollider.Play(); Text[0].text = " "; Text[1].text = " "; return; }
        Text[0].text = AllDialog[DialogNum].Line;
    }

    public void DirectorPause()//Signal Emitter_StartCollider
    {
        DialogImg.SetActive(true);
        StartCollider.Pause();
        CallText();
    }

    public void Hpbar(int num)//HP01,02,03_Slider_onchangedvalue
    {
        if (hpbar[num].GetComponent<Slider>().value <= 0)
        {
            StartCollider.Play();
            hpbar[num].SetActive(false);
        }
    }


}
