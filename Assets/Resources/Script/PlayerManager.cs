using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Text;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    bool isCleared, isFailed;
    [SerializeField] GameObject Manager;
    MainGameManager mgManager;
    Rigidbody rb;
    TrailRenderer tr;
    stageData sdata;
    datas dat;
    UniversalGravity ug;
    Text debugLabel;
    Sinus sinus;
    GameObject[] forceSpheres;
    SoundPlaySystem soundPlaySystem;

    //以下、挑戦管理用
    bool hitClear, hitFail, hitWall, challengeFlag1;
    int clickCount;
    float t;
    Vector3 pos;
    void Start()
    {
        Manager = GameObject.Find("Manager");
        isCleared = false;
        isFailed = false;

        mgManager = Manager.GetComponent<MainGameManager>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<TrailRenderer>();
        ug = GetComponent<UniversalGravity>();
        dat = new datas();

        resetChallengeFlags();

        sinus = GameObject.Find("Main Camera").GetComponent<Sinus>();

        forceSpheres = GameObject.FindGameObjectsWithTag("ForceSphere");

        soundPlaySystem = GameObject.Find("Main Camera").GetComponent<SoundPlaySystem>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !mgManager.isPausing) clickCount++;
        challengeManager(datas.currentStageNum);

        pos = transform.position;

        if (!mgManager.isPausing) t += Time.deltaTime;

        //音の管理
        int closeSphereCount = 0; //範囲内にある球の数
        float closestDistance = 100; //最も近い球との最短距離
        foreach (GameObject obj in forceSpheres)
        {
            float dist = Vector3.Distance(obj.transform.position, transform.position);
            if (dist < 6) closeSphereCount++;
            if (dist < closestDistance) closestDistance = dist;
        }

        if (closeSphereCount == 0) sinus.overtonesRange = 1;
        else sinus.overtonesRange = closeSphereCount;

        if (rb.velocity.magnitude < 0.01f) sinus.frequency = 0;
        else sinus.frequency = rb.velocity.magnitude * 200 + 20;

       /* if (closestDistance > 5) sinus.freqRandRange = 0;
        else sinus.freqRandRange = -closestDistance * (float)sinus.frequency / 2 / 5 + (float)sinus.frequency / 2;*/



        /*  if (Input.GetKeyDown(KeyCode.Space) && isCleared && SceneManager.GetActiveScene().name == "Main")
          {
              SceneManager.LoadScene("Main");
          }*/
        /*   if (MainGameManager.rta)
           {
               t = Time.timeSinceLevelLoad;
           }*/
    }
    void OnCollisionEnter(Collision collisionInfo) //壁か球に当たった時
    {
        if (collisionInfo.gameObject.tag == "ForceSphere" && !isCleared)
        {
            soundPlaySystem.SetSoundData(Resources.Load<AudioClip>("Sounds/incorrect"));

            hitFail = true;
            challengeManager(datas.currentStageNum);


            if (MainGameManager.rta || mgManager.autoRetry)
            {
                ug.forceMode = true;
                ug.changeMode();
                loadStage(datas.currentStageNum);
                return;
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "StageTest")
                {
                    SceneManager.LoadScene("StageTest");
                }
                else if (SceneManager.GetActiveScene().name == "Main")
                {
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    Manager.GetComponent<MainGameManager>().setCanvesActive(false);
                }
            }

            isFailed = true;
        }
        if ((collisionInfo.gameObject.tag == "Wall" || collisionInfo.gameObject.tag == "BorderWall") && !isCleared) hitWall = true;
    }

    void OnTriggerEnter(Collider other) //ゴールに当たった時
    {
        if (other.gameObject.tag == "Goal" && !isCleared && !isFailed)
        {
            if (MainGameManager.rta)
            {
                loadStage(datas.currentStageNum + 1);
                //   mgManager.goNextStage();
            }
            else
            {
                Manager.GetComponent<MainGameManager>().setCanvesActive(true);
                isCleared = true;
            }
            hitClear = true;
        }
    }

    void LoadMainScene() //メインシーンロード（未使用？）
    {
        SceneManager.LoadScene("Main");
    }

    public void loadStage(int i) //ステージロード
    {
        isFailed = false;
        isCleared = false;
        resetChallengeFlags();
        if (i <= MainGameManager.MAX_STAGE_NUM)
        {
            rb.velocity = Vector3.zero;
            sdata = dat.getStageData(i);
            transform.position = sdata.playerPos;
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            if (i != datas.currentStageNum)
            {
                datas.currentStageNum++;
                GameObject[] fieldObj1 = GameObject.FindGameObjectsWithTag("ForceSphere");
                GameObject[] fieldObj2 = GameObject.FindGameObjectsWithTag("Wall");
                foreach (GameObject obj in fieldObj1)
                {
                    obj.SetActive(false);
                }
                foreach (GameObject obj in fieldObj2)
                {
                    Destroy(obj);
                }
                Destroy(GameObject.Find("Goal(Clone)"));
                mgManager.generateStage();
                ug.GetAstroObjs();
            }
            tr.Clear();
        }
        else
        {
            isCleared = true;
            mgManager.setCanvesActive(true);
        }
    }
    void challengeManager(int i)
    {
        switch (i)
        {
            case 0:
                if (rb.velocity.magnitude >= 8) challengeFlag1 = true;
                if (challengeFlag1 && hitClear) savechallenge(i);
                break;

            case 1:
                if (clickCount >= 2 && hitClear) savechallenge(i);
                break;

            case 2:
                if (t <= 1 && clickCount >= 1) challengeFlag1 = true;
                if (challengeFlag1 && hitClear) savechallenge(i);
                break;

            case 3:
                if (clickCount == 1 && hitClear) savechallenge(i);
                break;

            case 4:
                if (clickCount == 1 && hitClear) savechallenge(i);
                break;

            case 5:
                if (clickCount == 2 && hitClear) savechallenge(i);
                break;

            case 6:
                if (t <= 5 && hitClear) savechallenge(i);
                break;

            case 7:
                if (!hitWall && hitClear) savechallenge(i);
                break;

            case 8:
                if (clickCount == 3 && hitClear) savechallenge(i);
                break;

            case 9:
                if (pos.x <= -3 && pos.z >= 6 && pos.z <= 10) challengeFlag1 = true;
                if (challengeFlag1 && hitFail) savechallenge(i);
                break;

            case 10:
                if (t <= 30 && hitClear) savechallenge(i);
                break;

            case 11:
                if (pos.x >= -7 && pos.x <= -6 && Mathf.Abs(pos.z) <= 0.5f) challengeFlag1 = true;
                if (challengeFlag1 && hitClear) savechallenge(i);
                break;

            case 12:
                if (clickCount == 2 && hitClear) savechallenge(i);
                break;

            case 13:
                if (pos.x <= -6 && pos.z >= 6) challengeFlag1 = true;
                if (challengeFlag1 && hitClear) savechallenge(i);
                break;

            case 14:
                if (pos.x <= -4) challengeFlag1 = true;
                if (challengeFlag1 && hitClear) savechallenge(i);
                break;

            case 15:
                if (Mathf.RoundToInt(pos.x) == 9 && Mathf.RoundToInt(pos.z) == -9 && rb.velocity == Vector3.zero) challengeFlag1 = true;
                if (challengeFlag1 && hitClear) savechallenge(i);
                break;

            case 16:
                if (clickCount == 1 && hitClear) savechallenge(i);
                break;

            case 17:
                if (t <= 16 && hitClear) savechallenge(i);
                break;

            case 18:
                if (pos.x >= 0 && pos.z >= 0 && hitFail) savechallenge(i);
                break;

            case 19:
                if (Mathf.Abs(pos.x) <= 1 && pos.z <= -2 && pos.z >= -6) challengeFlag1 = true;
                if (challengeFlag1 && hitClear) savechallenge(i);
                break;

            default:
                Debug.Log("Challenge Error!");
                break;
        }
    }
    void savechallenge(int i)
    {
        StreamReader sr = new StreamReader("Save/data.txt");
        string saveData = sr.ReadToEnd();
        sr.Close();

        int idx = 0;
        int subidx = 0;
        for (int j = 0; j < 4 + i; j++)
        {
            idx = saveData.IndexOf(":", idx + 1);
            subidx = saveData.IndexOf(";", subidx + 1);
        }
        idx++; //コロンが含まれてしまうため
        StringBuilder sb = new StringBuilder(saveData);
        sb.Remove(idx, subidx - idx);
        sb.Insert(idx, "1");
        saveData = sb.ToString();
        StreamWriter sw = new StreamWriter("Save/data.txt", false, Encoding.UTF8);
        sw.Write(saveData);
        sw.Close();
    }

    void resetChallengeFlags()
    {
        hitClear = false;
        hitFail = false;
        hitWall = false;
        challengeFlag1 = false;
        clickCount = 0;
        t = 0;
    }
}
