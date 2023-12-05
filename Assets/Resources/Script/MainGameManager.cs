using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainGameManager : MonoBehaviour
{
    [SerializeField] GameObject player, In, Seki, wall, goal, clearCanvasGroup, btn_nextStage, btn_retry, btn_resume, btn_setting, toggle_autoRetry;
    UniversalGravity ug;
    public bool autoRetry, isPausing;
    public static bool rta;
    public static int MAX_STAGE_NUM = 19;
    [SerializeField] Text Label, timeLabel, stageLabel, rtaResultLabel, challengeLabel;
    [SerializeField] string temp;
    datas dat;
    TrailRenderer tr;
    stageData sdata;
    float t;
    Vector3 playerVel;
    Rigidbody rb;
    SoundPlaySystem soundPlaySystem;
    float soundEffectVolume, backgroundSoundVolume;
    void Start()
    {
        dat = new datas();
        t = 0;
        isPausing = false;

        if (SceneManager.GetActiveScene().name == "Main")
        {
            generateStage();
            if (rta)
            {
                toggle_autoRetry.SetActive(false);
            }
            else
            {
                StreamReader sr = new StreamReader("Save/data.txt");
                string saveData = sr.ReadToEnd();
                sr.Close();

                int idx = saveData.IndexOf("AutoRetry") + 10; //インデックス+文字数+1
                int temp = Convert.ToInt32(saveData.Substring(idx, 1));
                autoRetry = Convert.ToBoolean(temp);

                toggle_autoRetry.GetComponent<Toggle>().isOn = autoRetry;
            }
        }

        ug = player.GetComponent<UniversalGravity>();
        tr = player.GetComponent<TrailRenderer>();
        rb = player.GetComponent<Rigidbody>();
        soundPlaySystem = GameObject.Find("Main Camera").GetComponent<SoundPlaySystem>();
    }

    void Update()
    {
        if (rta && !isPausing)
        {
            //t = Time.timeSinceLevelLoad;
            t += Time.deltaTime;
            timeLabel.text = "経過時間:" + t.ToString("f3") + "秒";
        }

        if (Input.GetKeyDown(KeyCode.Space)) loadSelf();

        if (EventSystem.current.IsPointerOverGameObject()) return; //uGUIのボタンを押したときに画面クリックを無視する

        if (Input.GetMouseButtonDown(0) && !isPausing)
        {
            soundPlaySystem.SetSoundData(Resources.Load<AudioClip>("Sounds/correct"));
            ug.changeMode();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) switchPause();
    }

    public void generateStage() //メインシーン読み込み時にステージを読み込む
    {
        stageLabel.text = "STAGE:" + (datas.currentStageNum + 1).ToString();
        sdata = dat.getStageData(datas.currentStageNum);

        if (GameObject.Find("Player(Clone)") == null)
        {
            player = Instantiate(player, sdata.playerPos, Quaternion.identity);
        }

        for (int i = 0; i < sdata.inPoss.Length; i++)
        {
            Instantiate(In, sdata.inPoss[i], Quaternion.identity);
        }

        for (int i = 0; i < sdata.sekiPoss.Length; i++)
        {
            Instantiate(Seki, sdata.sekiPoss[i], Quaternion.identity);
        }

        GameObject _goal = Instantiate(goal, sdata.goalPos, Quaternion.identity);
        _goal.transform.localScale = sdata.goalSize;

        GameObject _wall;
        for (int i = 0; i < sdata.wallPoss.Length; i++)
        {
            _wall = Instantiate(wall, sdata.wallPoss[i], Quaternion.identity);
            _wall.transform.localScale = sdata.wallSizes[i];
        }
    }

    public void goNextStage() //次のステージに移動
    {
        dat.goStage(datas.currentStageNum + 1);
    }

    public void goTitle() //タイトルに戻る
    {
        SceneManager.LoadScene("Title");
    }

    public void loadSelf()
    {
        if (rta)
        {
            datas.currentStageNum = 0;
            SceneManager.LoadScene("Main");
        }
        else
        {
            clearCanvasGroup.SetActive(false);
            player.GetComponent<PlayerManager>().loadStage(datas.currentStageNum);
            ug.forceMode = true;
            ug.changeMode();
            btn_nextStage.SetActive(true);
            btn_retry.SetActive(true);
            isPausing = false;
            rb.isKinematic = false;
        }
    }

    public void setCanvesActive(bool isCleared) //成功又は失敗時の処理
    {
        if (rta) //RTAモードでこの関数が呼ばれるとき、必ず最終ステージをクリアしている
        {
            float score = t;
            rtaResultLabel.text = "時間:" + score.ToString("f3") + "秒";
            Label.text = "成功";
            btn_resume.SetActive(false);
            btn_nextStage.SetActive(false);
            clearCanvasGroup.SetActive(true);

            StreamReader sr = new StreamReader("Save/data.txt");
            string saveData = sr.ReadToEnd();
            sr.Close();

            int idx = saveData.IndexOf(":"); //最初のコロンの位置(AutoRetryの後)
            idx = saveData.IndexOf(":", idx + 1); //2番目のコロンの位置(ReachedStageの後)
            idx = saveData.IndexOf(":", idx + 1); //3番目のコロンの位置(RTAの後)
            idx++; //コロンが含まれてしまうため
            int subidx = saveData.IndexOf(";"); //最初のセミコロンの位置（AutoRetryの後）
            subidx = saveData.IndexOf(";", subidx + 1); //2番目のセミコロンの位置（ReachedStageの後）
            subidx = saveData.IndexOf(";", subidx + 1); //3番目のセミコロンの位置（RTAの後）
            StringBuilder sb = new StringBuilder(saveData);
            if (saveData.Substring(idx, subidx - idx).Equals("N/A") || score <= float.Parse(saveData.Substring(idx, subidx - idx)))
            {
                sb.Remove(idx, subidx - idx);
                sb.Insert(idx, score.ToString("f3"));
                saveData = sb.ToString();
                StreamWriter sw = new StreamWriter("Save/data.txt", false, Encoding.UTF8);
                sw.Write(saveData);
                sw.Close();
            }
        }
        else if (isCleared)
        {
            Label.text = "成功";
            if (datas.currentStageNum == MAX_STAGE_NUM)
            {
                btn_nextStage.SetActive(false);
            }
            //  btn_retry.SetActive(false);
            // toggle_autoRetry.SetActive(false);
            btn_setting.SetActive(false);
            StreamReader sr = new StreamReader("Save/data.txt");
            string saveData = sr.ReadToEnd();
            sr.Close();

            int idx = saveData.IndexOf(":"); //最初のコロンの位置(AutoRetryの後)
            idx = saveData.IndexOf(":", idx + 1); //2番目のコロンの位置(ReachedStageの後)
            idx++; //コロンが含まれてしまうため
            int subidx = saveData.IndexOf(";"); //最初のセミコロンの位置（AutoRetryの後）
            subidx = saveData.IndexOf(";", subidx + 1); //2番目のセミコロンの位置（ReachedStageの後）
            StringBuilder sb = new StringBuilder(saveData);
            if (datas.currentStageNum >= Convert.ToInt32(saveData.Substring(idx, subidx - idx)) && datas.currentStageNum <= MAX_STAGE_NUM)
            {
                sb.Remove(idx, subidx - idx);
                sb.Insert(idx, (datas.currentStageNum + 1).ToString());
                saveData = sb.ToString();
                StreamWriter sw = new StreamWriter("Save/data.txt", false, Encoding.UTF8);
                sw.Write(saveData);
                sw.Close();
            }
            clearCanvasGroup.SetActive(true);
        }
        else
        {
            if (autoRetry)
            {
                Invoke("loadSelf", 0.26f);
                //  SceneManager.LoadScene("Main");
            }
            else
            {
                Label.text = "失敗";
                btn_resume.SetActive(false);
                toggle_autoRetry.SetActive(true);
                btn_nextStage.SetActive(false);
                btn_setting.SetActive(false);
                clearCanvasGroup.SetActive(true);
            }
        }
    }

    public void switchAutoRetry() //自動やり直しを入れ替える
    {
        autoRetry = toggle_autoRetry.GetComponent<Toggle>().isOn;

        StreamReader sr = new StreamReader("Save/data.txt");
        string saveData = sr.ReadToEnd();
        sr.Close();

        int idx = saveData.IndexOf("AutoRetry") + 10;
        StringBuilder sb = new StringBuilder(saveData);
        sb.Remove(idx, 1);
        sb.Insert(idx, Convert.ToInt32(autoRetry).ToString());
        saveData = sb.ToString();

        StreamWriter sw = new StreamWriter("Save/data.txt", false, Encoding.UTF8);
        sw.Write(saveData);
        sw.Close();
    }

    public void switchPause() //一時停止
    {
        btn_nextStage.SetActive(isPausing);
        //  btn_retry.SetActive(isPausing);
        isPausing = !isPausing;
        Label.text = "停止中";
        btn_resume.SetActive(isPausing);
        btn_setting.SetActive(isPausing);
        clearCanvasGroup.SetActive(isPausing);

        if (isPausing)
        {
            playerVel = rb.velocity;
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
            rb.velocity = playerVel;
        }

    }
}