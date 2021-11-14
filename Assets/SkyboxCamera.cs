using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxCamera : MonoBehaviour
{

    public RenderTexture SkyboxTexture;

    private float switchTime = 5f;
    private float timer = 5f;

    public Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        Material levelMat = Resources.Load("Skybox_A", typeof(Material)) as Material;
        RenderSettings.skybox = levelMat;
        SkyboxTexture = Resources.Load<RenderTexture>("SkyboxTexture");
        m_Camera = gameObject.GetComponent(typeof(Camera)) as Camera;
        //m_Camera.targetTexture = SkyboxTexture;
            
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            switchTexture();
        }
    }

    private void switchTexture()
    {
        Material levelMat = Resources.Load("Skybox_B", typeof(Material)) as Material;
        RenderSettings.skybox = levelMat;
        timer = switchTime;
    }
}
