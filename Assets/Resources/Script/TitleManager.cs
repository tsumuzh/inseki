using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    MainGameManager mainGameManager;
    datas dat;
    [SerializeField] GameObject[] canvasGroup = new GameObject[2];
    [SerializeField] GameObject creditGroup, bgm;
    bool canvasStatus, isCredit;
    [SerializeField] Text rtaBestScoreLabel, challengeLabel, completeLabel;
    string[] challenges = new string[20];
    [SerializeField] GameObject obj_ChallengeToggle;
    int completeRate;
    UniversalGravity ug;
    SoundPlaySystem soundPlaySystem;

    void Awake()
    {
        checkData();
    }
    void Start()
    {
        mainGameManager = GetComponent<MainGameManager>();
        ug = GameObject.Find("Player").GetComponent<UniversalGravity>();
        soundPlaySystem = GameObject.Find("Main Camera").GetComponent<SoundPlaySystem>();

        StreamReader sr = new StreamReader("Save/data.txt");
        string saveData = sr.ReadToEnd();
        sr.Close();

        int idx = saveData.IndexOf(":"); //最初のコロンの位置(AutoRetryの後)
        idx = saveData.IndexOf(":", idx + 1); //最初のコロンの位置(ReachedStageの後)
        idx++; //コロンが含まれてしまうため
        int subidx = saveData.IndexOf(";"); //2番目のセミコロンの位置（AutoRetryの後）
        subidx = saveData.IndexOf(";", subidx + 1); //2番目のセミコロンの位置（ReachedStageの後）
        StringBuilder sb = new StringBuilder(saveData);
        int reachedStageNum = Convert.ToInt32(saveData.Substring(idx, subidx - idx));

        idx = saveData.IndexOf(":", idx); //3番目のコロンの位置（RTAの後）
        idx++; //コロンが含まれてしまうため
        subidx = saveData.IndexOf(";", subidx + 1); //3番目のセミコロンの位置（RTAの後）

        completeRate = reachedStageNum;

        for (int i = 0; i <= reachedStageNum; i++)
        {
            if (i != MainGameManager.MAX_STAGE_NUM + 1) GameObject.Find("Stage_" + (i + 1).ToString()).GetComponent<Button>().interactable = true;
        }

        rtaBestScoreLabel.text = "スピードラン最速記録:" + saveData.Substring(idx, subidx - idx) + "秒";

        for (int i = 0; i <= MainGameManager.MAX_STAGE_NUM; i++)
        {
            idx = saveData.IndexOf(":", idx + 1);
            idx++;
            subidx = saveData.IndexOf(";", subidx + 1);
            completeRate += Convert.ToInt32(saveData.Substring(idx, subidx - idx));
        }

        completeLabel.text = "達成率:" + completeRate.ToString() + "/40";


        dat = new datas();


        canvasStatus = false;
        canvasGroup[0].SetActive(true);
        canvasGroup[1].SetActive(false);

        isCredit = false;
        creditGroup.SetActive(false);

        MainGameManager.rta = false;

        challenges[0] = "最大速さ8以上を出して成功する";
        challenges[1] = "2回以上の操作で成功する";
        challenges[2] = "開始1秒以内に1回以上操作して成功する";
        challenges[3] = "1回の操作で成功する";
        challenges[4] = "1回の操作で成功する";
        challenges[5] = "2回の操作で成功する";
        challenges[6] = "5秒以内に成功する";
        challenges[7] = "壁に当たらずに成功する";
        challenges[8] = "3回の操作で成功する";
        challenges[9] = "ゴールまで近づき、失敗する";
        challenges[10] = "30秒以内に成功する";
        challenges[11] = "左側の狭い道を通り、成功する";
        challenges[12] = "2回の操作で成功する";
        challenges[13] = "左上の球の傍を通り、成功する";
        challenges[14] = "左側に出て、その後成功する";
        challenges[15] = "右下の端で一時停止し、成功する";
        challenges[16] = "1回の操作で成功する";
        challenges[17] = "16秒以内に成功する";
        challenges[18] = "右上の部分で失敗する";
        challenges[19] = "ゴールの下を通り、成功する";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            soundPlaySystem.SetSoundData(Resources.Load<AudioClip>("Sounds/correct"));
            ug.changeMode();
        }
    }

    public void onStageSelected(int n) //ステージ選択（タイトルから）
    {
        dat.goStage(n);
    }

    public void checkData() //セーブファイルが存在するか確認
    {
        if (!Directory.Exists("Save")) Directory.CreateDirectory("Save");

        if (!System.IO.File.Exists("Save/data.txt"))
        {
            File.WriteAllText("Save/data.txt", "AutoRetry:0;\nReachedStage:0;\nRTA:N/A;");
            StreamWriter sw = new StreamWriter("Save/data.txt", true, Encoding.UTF8);
            sw.WriteLine("");
            for (int i = 0; i <= MainGameManager.MAX_STAGE_NUM; i++)
            {
                sw.WriteLine(i.ToString() + ":0;");
            }
            sw.Close();
        }

        if (!System.IO.File.Exists("Save/soundsetting.txt")) File.WriteAllText("Save/soundsetting.txt", "0.5:0.2");

    }

    public void setRTA() //RTAモード開始
    {
        dat.goStage(0);
        MainGameManager.rta = true;
    }
    public void switchCanvas() //タイトルキャンバス入れ替え
    {
        canvasGroup[Convert.ToInt32(canvasStatus)].SetActive(false);
        canvasGroup[Convert.ToInt32(!canvasStatus)].SetActive(true);
        canvasStatus = !canvasStatus;
    }
    public void setChallengeLabel(int i) //ボタンマウスオーバー時に挑戦を表示する
    {
        StreamReader sr = new StreamReader("Save/data.txt");
        string saveData = sr.ReadToEnd();
        sr.Close();

        int idx = 0;
        for (int j = 0; j < 4 + i; j++)
        {
            idx = saveData.IndexOf(":", idx + 1);
        }
        idx++; //コロンが含まれてしまうため
        obj_ChallengeToggle.GetComponent<Toggle>().isOn = Convert.ToBoolean(Convert.ToInt32(saveData.Substring(idx, 1)));
        obj_ChallengeToggle.SetActive(true);
        challengeLabel.text = challenges[i];
    }
    public void clearChallengeLabel()
    {
        challengeLabel.text = "";
        obj_ChallengeToggle.SetActive(false);
    }

    public void switchCredit()
    {
        isCredit = !isCredit;
        creditGroup.SetActive(isCredit);
    }
}
