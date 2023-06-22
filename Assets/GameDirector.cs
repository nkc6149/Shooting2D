using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; //距離を表示するUI-Textオブジェクトを保存する変数
    public Text shotLabel;
    public Image TimeGauge; //タイムゲージを表示するUI-Image

    public GameObject itemPre;         //残り時間

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
        lastTime = 60f;   //残り60秒
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //残り時間を減らす処理
        lastTime -= Time.deltaTime;
        TimeGauge.fillAmount = lastTime / 100f;

        if (lastTime < 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

        //進んだ距離を表示
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";
    }
}