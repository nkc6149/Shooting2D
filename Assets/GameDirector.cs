using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; //������\������UI-Text�I�u�W�F�N�g��ۑ�����ϐ�
    public Text shotLabel;
    public Image TimeGauge; //�^�C���Q�[�W��\������UI-Image

    public GameObject itemPre;         //�c�莞��

    public static float lastTime;
    public static int kyori;
    public int Kyori
    {
        set
        {
            kyori = value;
            kyori = Mathf.Clamp(kyori, 0, 999999);
        }
        get { return kyori; }
    }

    void Start()
    {
        kyori = 0;
        lastTime = 60f;   //�c��60�b
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //�c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime;
        TimeGauge.fillAmount = lastTime / 100f;

        if (lastTime < 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

        //�i�񂾋�����\��
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";
    }
}