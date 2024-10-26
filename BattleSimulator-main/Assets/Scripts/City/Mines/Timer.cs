using System;
using System.Collections;
using UnityEngine;

namespace BS.City.Mines
{
    public class Timer : MonoBehaviour
    {
        private float _currentTime;
        private Coroutine _working;

        public event Action TimeOver;

        public float CurrentTime => _currentTime;

        public void StartWork(float startTime)
        {
            if (_working != null)
                StopCoroutine(_working);

            _working = StartCoroutine(Work(startTime));
        }

        private IEnumerator Work(float startTime)
        {
            _currentTime = startTime;

            while (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
                yield return null;
            }

            TimeOver?.Invoke();
        }
    }
}