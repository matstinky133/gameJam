using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{


    [Header("timers")]
    [SerializeField] private float _timerPersonal = 0;
    [SerializeField] private float _timenotTagged = 0;

    [Header("Max time")]
    [SerializeField] private float _timeToExplode = 5f;
    [SerializeField] private float _baseTimeToExplode = 5f;
    [SerializeField] private float _reverseSpeedToReduceTimer = 10f;

    [SerializeField] private float _totalTime = 60f;

    [Header("props")]
    [SerializeField] private Image _visualTimer;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _positionUpValue;
    //[SerializeField] private TextMeshProUGUI _digitalClock;
    void Start()
    {
        _visualTimer = GetComponent<Image>();
        _timerPersonal = _timeToExplode;    
        _timenotTagged = _totalTime;
    }

    // Update is called once per frame
    void Update()
    {

        _timeToExplode =   _baseTimeToExplode / (_timenotTagged/ _reverseSpeedToReduceTimer);

        _timenotTagged += Time.deltaTime;
        //PersonalTimer
        transform.position = Camera.main.WorldToScreenPoint(_player.transform.position+ _positionUpValue *Vector3.up);
        _timerPersonal -= Time.deltaTime;
        if(_timerPersonal < 0)
        {
            _timerPersonal = _timeToExplode;
        }
        _visualTimer.fillAmount = _timerPersonal/_timeToExplode;

        //digitalTimer;
        
        

        //_digitalClock.text = $"{_timenotTagged}";


    }
}
