using TMPro;
using UnityEngine;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private TextMeshProUGUI _countdownText;

    private void Start()
    {
        _waveSpawner.OnCountdownChanged += WaveSpawner_OnCountdownChanged;
    }

    private void WaveSpawner_OnCountdownChanged(object sender, WaveSpawner.OnProgressChangedEventsArgs e)
    {
        _countdownText.text = Mathf.Round(e.Countdown).ToString();
    }
}
