using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // we need day and night loop
    // we need to update the sun position, color and intensity
    // let's make days longer than nights
    public Light sun;
    public float secondsInFullDay = 120f;
    [Range(0,1)]
    public float currentTimeOfDay = 0;
    [Range(0,1)]
    public float timeMultiplier = 1f;
    public Color blue = new Color(0,0,1);
    public Color yellow = new Color(1,1,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sun = GetComponent<Light>();
        currentTimeOfDay = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSun();
        UpdateSunPosition();
        UpdateSunColor();
        UpdateSunIntensity();
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        if(currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
        if(currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            timeMultiplier = 0.2f;
        }
        else
        {
            timeMultiplier = 1f;
        }
    }

    void UpdateSunPosition()
    {
        sun.transform.position = new Vector3(sun.transform.position.x, sun.transform.position.y, sun.transform.position.z);
    }

    void UpdateSunColor()
    {
        sun.color = Color.Lerp(blue, yellow, currentTimeOfDay);
    }

    void UpdateSunIntensity()
    {
        sun.intensity = Mathf.Lerp(0, 1, currentTimeOfDay);
    }
    
}
