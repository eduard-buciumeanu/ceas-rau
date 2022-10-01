using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] RectTransform timerParticleHolder;
    [SerializeField] Image timerImage;
    [SerializeField] [Range(0,1)] float timerProgress = 1f;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }

    void Update()
    {
        timerImage.fillAmount = timerProgress;
        timerParticleHolder.rotation = Quaternion.Euler(new Vector3(0f, 0f, -timerProgress * 360));
    }

    public void SetTimerProgress(float value)
    {
        timerProgress = value;
    }
}
