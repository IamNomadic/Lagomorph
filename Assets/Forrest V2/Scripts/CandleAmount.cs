using System.Collections.Generic;
using UnityEngine;

public class CandleAmount : MonoBehaviour
{
    [SerializeField] int randCandleAmount;
    [SerializeField] List<GameObject> _candles = new();
    private void Start()
    {
        foreach(GameObject _candles in _candles)
        {
            _candles.SetActive(false);
        }

        randCandleAmount = UnityEngine.Random.Range(1,4);
        _candles[Random.Range(0, _candles.Count)].SetActive(true);
        if (randCandleAmount >= 2)
        {
            _candles[Random.Range(0, _candles.Count)].SetActive(true);

        }
        if (randCandleAmount >= 3)
        {
            _candles[Random.Range(0, _candles.Count)].SetActive(true);

        }
    }
}
