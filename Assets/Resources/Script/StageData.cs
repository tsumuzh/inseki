using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public struct stageData
{
    public Vector3 playerPos;
    public Vector3[] inPoss;
    public Vector3[] sekiPoss;
    public Vector3 goalPos;
    public Vector3 goalSize;
    public Vector3[] wallPoss;
    public Vector3[] wallSizes;
}

public class datas
{
    public static int currentStageNum;
    public stageData getStageData(int n)
    {
        stageData data = new stageData();

        switch (n)
        {
            case 0:
                data.playerPos = new Vector3(2, 0, 0);

                data.inPoss = new Vector3[3];
                data.inPoss[0] = new Vector3(-8, 0, 0);
                data.inPoss[1] = new Vector3(-8, 0, 4);
                data.inPoss[2] = new Vector3(-8, 0, -4);

                data.sekiPoss = new Vector3[1];
                data.sekiPoss[0] = new Vector3(8, 0, 0);

                data.goalPos = new Vector3(6, 0, 0);
                data.goalSize = new Vector3(2, 1, 4);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 1:
                data.playerPos = new Vector3(9, 0, -7);

                data.inPoss = new Vector3[17];
                for (int i = 0; i < 17; i++)
                {
                    data.inPoss[i] = new Vector3(-8, 0, i - 9);
                }

                data.sekiPoss = new Vector3[1];
                data.sekiPoss[0] = new Vector3(9, 0, -9);

                data.goalPos = new Vector3(-9, 0, 0);
                data.goalSize = new Vector3(1, 1, 19);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 2:
                data.playerPos = new Vector3(8, 0, 8);

                data.inPoss = new Vector3[1];
                data.inPoss[0] = new Vector3(2, 0, 0);

                data.sekiPoss = new Vector3[1];
                data.sekiPoss[0] = new Vector3(9, 0, 9);

                data.goalPos = new Vector3(0, 0, 8);
                data.goalSize = new Vector3(5, 1, 3);

                data.wallPoss = new Vector3[1];
                data.wallPoss[0] = new Vector3(5, 0, 6);

                data.wallSizes = new Vector3[1];
                data.wallSizes[0] = new Vector3(0.5f, 0.1f, 8);
                break;

            case 3:
                data.playerPos = new Vector3(-8, 0, -7);

                data.inPoss = new Vector3[2];
                data.inPoss[0] = new Vector3(-5, 0, 0);
                data.inPoss[1] = new Vector3(2, 0, 1);

                data.sekiPoss = new Vector3[2];
                data.sekiPoss[0] = new Vector3(-9, 0, -9);
                data.sekiPoss[1] = new Vector3(-5, 0, -9);

                data.goalPos = new Vector3(8, 0, 3);
                data.goalSize = new Vector3(3, 1, 3);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 4:
                data.playerPos = new Vector3(0, 0, 3);

                data.inPoss = new Vector3[2];
                data.inPoss[0] = new Vector3(0, 0, 8);
                data.inPoss[1] = new Vector3(-7, 0, -7);

                data.sekiPoss = new Vector3[2];
                data.sekiPoss[0] = new Vector3(6, 0, 4);
                data.sekiPoss[1] = new Vector3(-6, 0, 4);

                data.goalPos = new Vector3(7.5f, 0, -7.5f);
                data.goalSize = new Vector3(4, 1, 4);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 5:
                data.playerPos = new Vector3(0, 0, 8);

                data.inPoss = new Vector3[2];
                data.inPoss[0] = new Vector3(6, 0, 5);
                data.inPoss[1] = new Vector3(6, 0, -3);

                data.sekiPoss = new Vector3[2];
                data.sekiPoss[0] = new Vector3(-6, 0, 5);
                data.sekiPoss[1] = new Vector3(-6, 0, -3);

                data.goalPos = new Vector3(0, 0, -8);
                data.goalSize = new Vector3(19, 1, 3);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 6:
                data.playerPos = new Vector3(8, 0, 8);

                data.inPoss = new Vector3[2];
                data.inPoss[0] = new Vector3(2, 0, 5);
                data.inPoss[1] = new Vector3(6, 0, 0);

                data.sekiPoss = new Vector3[1];
                data.sekiPoss[0] = new Vector3(9, 0, 9);

                data.goalPos = new Vector3(6, 0, -4);
                data.goalSize = new Vector3(1, 1, 7);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 7:
                data.playerPos = new Vector3(8, 0, -1);

                data.inPoss = new Vector3[0];

                data.sekiPoss = new Vector3[26];
                data.sekiPoss[0] = new Vector3(2, 0, -9);
                data.sekiPoss[1] = new Vector3(3, 0, -8);
                data.sekiPoss[2] = new Vector3(4, 0, -7);
                data.sekiPoss[3] = new Vector3(5, 0, -6);
                data.sekiPoss[4] = new Vector3(6, 0, -5);
                data.sekiPoss[5] = new Vector3(7, 0, -4);
                data.sekiPoss[6] = new Vector3(8, 0, -3);
                data.sekiPoss[7] = new Vector3(9, 0, -2);
                data.sekiPoss[8] = new Vector3(-2, 0, 9);
                data.sekiPoss[9] = new Vector3(-3, 0, 8);
                data.sekiPoss[10] = new Vector3(-4, 0, 7);
                data.sekiPoss[11] = new Vector3(-5, 0, 6);
                data.sekiPoss[12] = new Vector3(-6, 0, 5);
                data.sekiPoss[13] = new Vector3(-7, 0, 4);
                data.sekiPoss[14] = new Vector3(-8, 0, 3);
                data.sekiPoss[15] = new Vector3(-9, 0, 2);
                data.sekiPoss[16] = new Vector3(-8, 0, 2);
                data.sekiPoss[17] = new Vector3(-7, 0, 2);
                data.sekiPoss[18] = new Vector3(-6, 0, 2);
                data.sekiPoss[19] = new Vector3(-5, 0, 2);
                data.sekiPoss[20] = new Vector3(-4, 0, 2);
                data.sekiPoss[21] = new Vector3(2, 0, -8);
                data.sekiPoss[22] = new Vector3(2, 0, -7);
                data.sekiPoss[23] = new Vector3(2, 0, -6);
                data.sekiPoss[24] = new Vector3(2, 0, -5);
                data.sekiPoss[25] = new Vector3(2, 0, -4);

                data.goalPos = new Vector3(-7, 0, -7);
                data.goalSize = new Vector3(5, 1, 5);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 8:
                data.playerPos = new Vector3(-8, 0, -8);

                data.inPoss = new Vector3[1];
                data.inPoss[0] = new Vector3(4, 0, 4);

                data.sekiPoss = new Vector3[2];
                data.sekiPoss[0] = new Vector3(-2, 0, -2);
                data.sekiPoss[1] = new Vector3(-1, 0, 1);

                data.goalPos = Vector3.zero;
                data.goalSize = new Vector3(1, 1, 1);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 9:
                data.playerPos = new Vector3(-8, 0, -8);

                data.inPoss = new Vector3[1];
                data.inPoss[0] = new Vector3(7, 0, -7);

                data.sekiPoss = new Vector3[1];
                data.sekiPoss[0] = new Vector3(7, 0, 7);

                data.goalPos = new Vector3(-8, 0, 8);
                data.goalSize = new Vector3(3, 1, 3);

                data.wallPoss = new Vector3[1];
                data.wallPoss[0] = new Vector3(-1, 0, 0);

                data.wallSizes = new Vector3[1];
                data.wallSizes[0] = new Vector3(17, 0.1f, 13);
                break;

            case 10:
                data.playerPos = new Vector3(-8, 0, -8);

                data.inPoss = new Vector3[1];
                data.inPoss[0] = new Vector3(6, 0, -6);

                data.sekiPoss = new Vector3[3];
                data.sekiPoss[0] = new Vector3(-6, 0, 6);
                data.sekiPoss[1] = new Vector3(-2, 0, -6);
                data.sekiPoss[2] = new Vector3(2, 0, 6);

                data.goalPos = new Vector3(8, 0, 8);
                data.goalSize = new Vector3(3, 1, 3);

                data.wallPoss = new Vector3[4];
                data.wallPoss[0] = new Vector3(-6, 0, -2);
                data.wallPoss[1] = new Vector3(-2, 0, 2);
                data.wallPoss[2] = new Vector3(2, 0, -2);
                data.wallPoss[3] = new Vector3(6, 0, 2);

                data.wallSizes = new Vector3[4];
                data.wallSizes[0] = new Vector3(1, 0.1f, 15);
                data.wallSizes[1] = new Vector3(1, 0.1f, 15);
                data.wallSizes[2] = new Vector3(1, 0.1f, 15);
                data.wallSizes[3] = new Vector3(1, 0.1f, 15);
                break;

            case 11:
                data.playerPos = new Vector3(-8, 0, 8);

                data.inPoss = new Vector3[11];
                data.inPoss[0] = new Vector3(-9, 0, 0);
                data.inPoss[1] = new Vector3(-8, 0, 0);
                data.inPoss[2] = new Vector3(-5, 0, 0);
                data.inPoss[3] = new Vector3(-4, 0, 0);
                data.inPoss[4] = new Vector3(9, 0, 9);
                data.inPoss[5] = new Vector3(9, 0, 6);
                data.inPoss[6] = new Vector3(9, 0, 3);
                data.inPoss[7] = new Vector3(9, 0, 0);
                data.inPoss[8] = new Vector3(9, 0, -3);
                data.inPoss[9] = new Vector3(9, 0, -6);
                data.inPoss[10] = new Vector3(9, 0, -9);

                data.sekiPoss = new Vector3[0];

                data.goalPos = new Vector3(-8, 0, -8);
                data.goalSize = new Vector3(3, 1, 3);

                data.wallPoss = new Vector3[1];
                data.wallPoss[0] = Vector3.zero;

                data.wallSizes = new Vector3[1];
                data.wallSizes[0] = new Vector3(7, 0.1f, 7);
                break;

            case 12:
                data.playerPos = new Vector3(8, 0, -8);

                data.inPoss = new Vector3[10];
                data.inPoss[0] = new Vector3(-4, 0, 6);
                data.inPoss[1] = new Vector3(-6, 0, 6);
                data.inPoss[2] = new Vector3(-8, 0, 6);
                data.inPoss[3] = new Vector3(-8, 0, 4);
                data.inPoss[4] = new Vector3(-8, 0, 2);
                data.inPoss[5] = new Vector3(-8, 0, 0);
                data.inPoss[6] = new Vector3(-8, 0, -2);
                data.inPoss[7] = new Vector3(-8, 0, -4);
                data.inPoss[8] = new Vector3(-4, 0, -8);
                data.inPoss[9] = new Vector3(3, 0, 2);

                data.sekiPoss = new Vector3[6];
                data.sekiPoss[0] = new Vector3(-8, 0, 8);
                data.sekiPoss[1] = new Vector3(-6, 0, 8);
                data.sekiPoss[2] = new Vector3(-4, 0, 8);
                data.sekiPoss[3] = new Vector3(-1, 0, 1);
                data.sekiPoss[4] = new Vector3(0, 0, -5);
                data.sekiPoss[5] = new Vector3(5, 0, -4);

                data.goalPos = new Vector3(-4, 0, 0);
                data.goalSize = new Vector3(3, 1, 3);

                data.wallPoss = new Vector3[2];
                data.wallPoss[0] = new Vector3(0, 0, 7);
                data.wallPoss[1] = new Vector3(6, 0, -7);

                data.wallSizes = new Vector3[2];
                data.wallSizes[0] = new Vector3(0.5f, 0.1f, 6);
                data.wallSizes[1] = new Vector3(0.5f, 0.1f, 6);
                break;

            case 13:
                data.playerPos = new Vector3(8, 0, 8);

                data.inPoss = new Vector3[5];
                data.inPoss[0] = new Vector3(0, 0, 8);
                data.inPoss[1] = new Vector3(0, 0, -8);
                data.inPoss[2] = new Vector3(8, 0, -8);
                data.inPoss[3] = new Vector3(-8, 0, -8);
                data.inPoss[4] = new Vector3(-8, 0, 0);

                data.sekiPoss = new Vector3[2];
                data.sekiPoss[0] = Vector3.zero;
                data.sekiPoss[1] = new Vector3(-8, 0, 8);

                data.goalPos = new Vector3(-4, 0, 0);
                data.goalSize = new Vector3(3, 1, 5);

                data.wallPoss = new Vector3[4];
                data.wallPoss[0] = new Vector3(4, 0, 4);
                data.wallPoss[1] = new Vector3(4, 0, -4);
                data.wallPoss[2] = new Vector3(-4, 0, -4);
                data.wallPoss[3] = new Vector3(-4, 0, 4);

                data.wallSizes = new Vector3[4];
                data.wallSizes[0] = new Vector3(3, 0.1f, 3);
                data.wallSizes[1] = new Vector3(3, 0.1f, 3);
                data.wallSizes[2] = new Vector3(3, 0.1f, 3);
                data.wallSizes[3] = new Vector3(3, 0.1f, 3);
                break;

            case 14:
                data.playerPos = new Vector3(0, 0, 9);

                data.inPoss = new Vector3[6];
                data.inPoss[0] = new Vector3(2, 0, 5);
                data.inPoss[1] = new Vector3(-4, 0, 5);
                data.inPoss[2] = new Vector3(4, 0, -1);
                data.inPoss[3] = new Vector3(-2, 0, -1);
                data.inPoss[4] = new Vector3(2, 0, -7);
                data.inPoss[5] = new Vector3(-2, 0, -7);

                data.sekiPoss = new Vector3[6];
                data.sekiPoss[0] = new Vector3(2, 0, 8);
                data.sekiPoss[1] = new Vector3(-2, 0, 8);
                data.sekiPoss[2] = new Vector3(4, 0, 2);
                data.sekiPoss[3] = new Vector3(-4, 0, 2);
                data.sekiPoss[4] = new Vector3(4, 0, -4);
                data.sekiPoss[5] = new Vector3(-4, 0, -4);

                data.goalPos = new Vector3(0, 0, -9);
                data.goalSize = new Vector3(19, 1, 1);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 15:
                data.playerPos = Vector3.zero;

                data.inPoss = new Vector3[7];
                data.inPoss[0] = new Vector3(9, 0, 9);
                data.inPoss[1] = new Vector3(-5, 0, 6);
                data.inPoss[2] = new Vector3(6, 0, 3);
                data.inPoss[3] = new Vector3(-3, 0, 0);
                data.inPoss[4] = new Vector3(-6, 0, -3);
                data.inPoss[5] = new Vector3(-1, 0, -6);
                data.inPoss[6] = new Vector3(4, 0, 9);

                data.sekiPoss = new Vector3[7];
                data.sekiPoss[0] = new Vector3(-7, 0, 9);
                data.sekiPoss[1] = new Vector3(-3, 0, 6);
                data.sekiPoss[2] = new Vector3(0, 0, 3);
                data.sekiPoss[3] = new Vector3(8, 0, 0);
                data.sekiPoss[4] = new Vector3(-1, 0, -3);
                data.sekiPoss[5] = new Vector3(-4, 0, -6);
                data.sekiPoss[6] = new Vector3(-7, 0, -9);

                data.goalPos = new Vector3(2, 0, 6);
                data.goalSize = new Vector3(1, 1, 1);

                data.wallPoss = new Vector3[0];
                data.wallSizes = new Vector3[0];
                break;

            case 16:
                data.playerPos = new Vector3(0, 0, 8.5f);

                data.inPoss = new Vector3[25];
                data.sekiPoss = new Vector3[25];
                for (int i = 0; i < 19; i++)
                {
                    data.inPoss[i] = new Vector3(9, 0, i - 9);
                    data.sekiPoss[i] = new Vector3(-9, 0, i - 9);
                }

                data.inPoss[19] = new Vector3(-4, 0, 4);
                data.inPoss[20] = new Vector3(4, 0, -4);
                data.inPoss[21] = new Vector3(4, 0, 0);
                data.inPoss[22] = new Vector3(-4, 0, 0);
                data.inPoss[23] = new Vector3(-4, 0, -8);
                data.inPoss[24] = new Vector3(0, 0, -4.5f);

                data.sekiPoss[19] = new Vector3(-4, 0, -4);
                data.sekiPoss[20] = new Vector3(4, 0, 4);
                data.sekiPoss[21] = new Vector3(2, 0, 0);
                data.sekiPoss[22] = new Vector3(-2, 0, 0);
                data.sekiPoss[23] = new Vector3(4, 0, -8);
                data.sekiPoss[24] = new Vector3(0, 0, -7.5f);

                data.goalPos = new Vector3(0, 0, -6);
                data.goalSize = new Vector3(1, 1, 1);

                data.wallPoss = new Vector3[2];
                data.wallPoss[0] = new Vector3(8.25f, 0, 0);
                data.wallPoss[1] = new Vector3(-8.25f, 0, 0);

                data.wallSizes = new Vector3[2];
                data.wallSizes[0] = new Vector3(0.5f, 0.1f, 19);
                data.wallSizes[1] = new Vector3(0.5f, 0.1f, 19);
                break;

            case 17:
                data.playerPos = new Vector3(-8, 0, 8);

                data.inPoss = new Vector3[6];
                data.inPoss[0] = new Vector3(-1, 0, 6.25f);
                data.inPoss[1] = new Vector3(7, 0, 7);
                data.inPoss[2] = new Vector3(-4, 0, 3.5f);
                data.inPoss[3] = new Vector3(6, 0, 2);
                data.inPoss[4] = new Vector3(-1, 0, -3);
                data.inPoss[5] = new Vector3(8, 0, -8);

                data.sekiPoss = new Vector3[4];
                data.sekiPoss[0] = new Vector3(2, 0, 4);
                data.sekiPoss[1] = new Vector3(-9, 0, 5.5f);
                data.sekiPoss[2] = new Vector3(-7.5f, 0, -4);
                data.sekiPoss[3] = new Vector3(5, 0, -6);

                data.goalPos = new Vector3(-8, 0, -8);
                data.goalSize = new Vector3(3, 1, 3);

                data.wallPoss = new Vector3[3];
                data.wallPoss[0] = new Vector3(-5.5f, 0, 6.25f);
                data.wallPoss[1] = new Vector3(-5.5f, 0, -6.25f);
                data.wallPoss[2] = new Vector3(2, 0, 0);

                data.wallSizes = new Vector3[3];
                data.wallSizes[0] = new Vector3(8, 0.1f, 0.5f);
                data.wallSizes[1] = new Vector3(8, 0.1f, 0.5f);
                data.wallSizes[2] = new Vector3(15, 0.1f, 0.5f);
                break;

            case 18:
                data.playerPos = new Vector3(-2, 0, 7.75f);

                data.inPoss = new Vector3[10];
                data.inPoss[0] = new Vector3(-9, 0, 9);
                data.inPoss[1] = new Vector3(-6, 0, 5);
                data.inPoss[2] = new Vector3(-7, 0, 1);
                data.inPoss[3] = new Vector3(-2, 0, 1);
                data.inPoss[4] = new Vector3(-4, 0, -3);
                data.inPoss[5] = new Vector3(-9, 0, -6);
                data.inPoss[6] = new Vector3(1, 0, -7);
                data.inPoss[7] = new Vector3(3, 0, -3);
                data.inPoss[8] = new Vector3(7, 0, -7);
                data.inPoss[9] = new Vector3(7, 0, -1);

                data.sekiPoss = new Vector3[8];
                data.sekiPoss[0] = new Vector3(-3, 0, 4);
                data.sekiPoss[1] = new Vector3(-7, 0, -1);
                data.sekiPoss[2] = new Vector3(-2, 0, -2);
                data.sekiPoss[3] = new Vector3(-2, 0, -6);
                data.sekiPoss[4] = new Vector3(-1, 0, -7);
                data.sekiPoss[5] = new Vector3(3, 0, -6);
                data.sekiPoss[6] = new Vector3(5, 0, -9);
                data.sekiPoss[7] = new Vector3(7, 0, 1);

                data.goalPos = new Vector3(2.25f, 0, 7.5f);
                data.goalSize = new Vector3(4, 1, 4);

                data.wallPoss = new Vector3[2];
                data.wallPoss[0] = new Vector3(0, 0, 1);
                data.wallPoss[1] = Vector3.zero;

                data.wallSizes = new Vector3[2];
                data.wallSizes[0] = new Vector3(0.5f, 0.1f, 17);
                data.wallSizes[1] = new Vector3(15, 0.1f, 0.5f);
                break;

            case 19:
                data.playerPos = new Vector3(0, 0, 8);

                data.inPoss = new Vector3[2];
                data.inPoss[0] = new Vector3(9, 0, 0);
                data.inPoss[1] = new Vector3(0, 0, -5);

                data.sekiPoss = new Vector3[1];
                data.sekiPoss[0] = new Vector3(-9, 0, 0);

                data.goalPos = Vector3.zero;
                data.goalSize = new Vector3(3, 1, 3);

                data.wallPoss = new Vector3[9];
                data.wallPoss[0] = new Vector3(0, 0, -2);
                data.wallPoss[1] = new Vector3(2, 0, 0);
                data.wallPoss[2] = new Vector3(-2, 0, 0);
                data.wallPoss[3] = new Vector3(0, 0, 6);
                data.wallPoss[4] = new Vector3(0, 0, -6);
                data.wallPoss[5] = new Vector3(6, 0, 4);
                data.wallPoss[6] = new Vector3(6, 0, -4);
                data.wallPoss[7] = new Vector3(-6, 0, 4);
                data.wallPoss[8] = new Vector3(-6, 0, -4);

                data.wallSizes = new Vector3[9];
                data.wallSizes[0] = new Vector3(3, 0.1f, 1);
                data.wallSizes[1] = new Vector3(1, 0.1f, 5);
                data.wallSizes[2] = new Vector3(1, 0.1f, 5);
                data.wallSizes[3] = new Vector3(11, 0.1f, 1);
                data.wallSizes[4] = new Vector3(11, 0.1f, 1);
                data.wallSizes[5] = new Vector3(1, 0.1f, 5);
                data.wallSizes[6] = new Vector3(1, 0.1f, 5);
                data.wallSizes[7] = new Vector3(1, 0.1f, 5);
                data.wallSizes[8] = new Vector3(1, 0.1f, 5);
                break;
        }
        return data;
    }

    public void goStage(int n)
    {
        currentStageNum = n;
        SceneManager.LoadScene("Main");
    }
}