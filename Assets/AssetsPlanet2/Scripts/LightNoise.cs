using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum LightState {
    IDLE,
    BLINK,
    UN_BLINK
}

public class LightNoise : MonoBehaviour
{
    private Light light;
    private float initialIntensity;
    private float intensityObjective;
    private float timer;
    private float nextEventTimer;
    private LightState lightState;
    private int blinkCounter;


    void Start()
    {
        light = GetComponent<Light>();
        initialIntensity = light.intensity;
        lightState = LightState.IDLE;
        nextEventTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        switch (lightState) {
            case LightState.IDLE:
                if(timer >= nextEventTimer) {
                    timer = 0;
                    light.intensity = 0;

                    lightState = LightState.UN_BLINK;
                    blinkCounter = Random.Range(1, 2);
                    nextEventTimer = GenerateBlinkingInterval();
                }

                break;

            
            case LightState.UN_BLINK:
                if(timer >= nextEventTimer) {
                    timer = 0;
                    blinkCounter--;
                    light.intensity = initialIntensity;

                    if (blinkCounter == 0) {
                        lightState = LightState.IDLE;
                        nextEventTimer = GenerateIdlingInterval();
                    }
                    else {
                        lightState = LightState.BLINK;
                        nextEventTimer = GenerateBlinkingInterval();
                    }
                }

                break;


            case LightState.BLINK:
                if(timer >= nextEventTimer) {
                    timer = 0;
                    nextEventTimer = GenerateBlinkingInterval();
                    lightState = LightState.UN_BLINK;
                }
            
                break;
        }
    }

    private float GenerateIdlingInterval() {
        return Random.Range(2f, 5f);
    }

    private float GenerateBlinkingInterval() {
        return Random.Range(.1f, .2f);
    }
}
