using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class UniversalGravity : MonoBehaviour
{
    public float G = 150f;
    public GameObject[] AstroObjs;
    Rigidbody[] rbs;
    Rigidbody rb;
    int count;
    Vector3 F = Vector3.zero;
    public bool forceMode;
    Color In, Seki;


    void Start()
    {
        GetAstroObjs();
        G = 30f;

        In = new Color32(255, 40, 0, 255);
        Seki = new Color32(0, 255, 0, 255);

        forceMode = true;
        changeMode();
    }

    void FixedUpdate()
    {
        F = Vector3.zero;
        for (int i = 0; i < count; i++)
        {
            Vector3 rVec = AstroObjs[i].transform.position - transform.position;
            float r = rVec.magnitude;

            if (!forceMode)
            {
                if (AstroObjs[i].name.Contains("In"))
                {
                    F += rVec.normalized * G * (rbs[i].mass * rb.mass) / (r * r);
                }
                else if (AstroObjs[i].name.Contains("Seki"))
                {
                    F -= rVec.normalized * G * (rbs[i].mass * rb.mass) / (r * r);
                }
            }
            else if (forceMode)
            {
                if (AstroObjs[i].name.Contains("In"))
                {
                    F -= rVec.normalized * G * (rbs[i].mass * rb.mass) / (r * r);
                }
                else if (AstroObjs[i].name.Contains("Seki"))
                {
                    F += rVec.normalized * G * (rbs[i].mass * rb.mass) / (r * r);
                }
            }
        }
        rb.AddForce(F);
    }

    public void GetAstroObjs()
    {
        if (forceMode)
        {
            changeMode();
        }
        AstroObjs = GameObject.FindGameObjectsWithTag("ForceSphere");
        count = AstroObjs.Length;
        Array.Resize(ref rbs, count);
        rb = GetComponent<Rigidbody>();
        for (int i = 0; i < count; i++)
        {
            rbs[i] = AstroObjs[i].GetComponent<Rigidbody>();
        }
    }

    public void changeMode()
    {
        forceMode = !forceMode;
        for (int i = 0; i < count; i++)
        {
            if (!forceMode)
            {
                if (AstroObjs[i].name.Contains("In"))
                {
                    AstroObjs[i].GetComponent<Renderer>().material.color = In;
                }
                else if (AstroObjs[i].name.Contains("Seki"))
                {
                    AstroObjs[i].GetComponent<Renderer>().material.color = Seki;
                }
            }
            else if (forceMode)
            {
                if (AstroObjs[i].name.Contains("In"))
                {
                    AstroObjs[i].GetComponent<Renderer>().material.color = Seki;
                }
                else if (AstroObjs[i].name.Contains("Seki"))
                {
                    AstroObjs[i].GetComponent<Renderer>().material.color = In;
                }
            }

        }
    }
}
