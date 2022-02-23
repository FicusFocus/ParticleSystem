using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBangEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _accumulationOfStrength;
    [SerializeField] private ParticleSystem _explosion;

    private float _accumulationOfStrengthLanth;
    private float _playtime = 0;
    private bool _played;
    private float _targetRadius = 0.2f;

    private void Start()
    {
        _accumulationOfStrength.Play();
    }

    private void Update()
    {
        if (_played)
            return;

        _playtime += Time.deltaTime;

        var newradius = _accumulationOfStrength.shape.radius;

        newradius = Mathf.Lerp(_accumulationOfStrength.shape.radius, _targetRadius, _accumulationOfStrength.main.duration);

        if (_playtime >= _accumulationOfStrength.main.duration)
        {
            _explosion.Play();
            _played = true;
        }
    }
}
