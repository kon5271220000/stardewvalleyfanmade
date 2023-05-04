using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class DayTimeController : MonoBehaviour
{
    private const float _SecondsInday = 86400f;
    [SerializeField] Color _nightLightingColor;
    [SerializeField] Color _dayLightingColor = Color.white;
    [SerializeField] AnimationCurve _nightTimeCurve;
    private float _time;
    [SerializeField] float _timeScale = 120f;
    private int _days;

    [SerializeField] Text _text;
    [SerializeField] Light2D _globalLight;


    private void Update()
    {
        _time += Time.deltaTime * _timeScale;
        int _hh = (int)Hour;
        int _mm = (int)Minute;
        _text.text = _hh.ToString("00") + ":" + _mm.ToString("00");

        float v = _nightTimeCurve.Evaluate(Hour);
        Color c = Color.Lerp(_dayLightingColor, _nightLightingColor, v);
        _globalLight.color = c;

        if(_time > _SecondsInday)
        {
            NextDay();
        }
    }

    float Hour
    {
        get { return _time / 3600; }
    }

    float Minute
    {
        get { return _time % 3600 / 60; }
    }

    private void NextDay()
    {
        _time = 0;
        _days += 1;
    }
}
