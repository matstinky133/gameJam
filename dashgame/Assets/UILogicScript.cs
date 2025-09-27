
using TMPro;
using UnityEngine;

public class UILogicScript : MonoBehaviour
{
    [SerializeField] TaggingLogicScript _player1, _player2;
    [SerializeField] TextMeshProUGUI _winnerText;
    [SerializeField] TextMeshProUGUI _timerText;
    [SerializeField] private float _time;
    [SerializeField] private float _timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer > 0)
        {
            _timer = _timer - Time.deltaTime;
            UpdateText();
        }
        if (_timer <= 0)
        {
            CheckPlayers();
            //
            //
            //ChangeTimer();
            AssignRandomTagger();

        }
    }

    private void UpdateText()
    {
        _timerText.text = "00;" + (int)_timer;
    }

    private void AssignRandomTagger()
    {
        int _rnd = Random.Range(0, 1);
        if(_rnd == 1)
        {
            _player1._isTagger = true;
            _player2._isTagger = false;
        }
        if( _rnd == 2)
        {
            _player2._isTagger = true;
            _player1._isTagger = false;
        }
    }

    private void ChangeTimer()
    {
        _time -= 5;
    }

    private void CheckPlayers()
    {
        if (_player1._isTagger)
        {
            _player1.Lives -= 1;
            _timer = _time;
        }
        if (_player2._isTagger)
        {
            _player2.Lives -= 1;
            _timer = _time;
        }

        if (_player1.Lives == 0)
        {
            _winnerText.gameObject.SetActive(true);
            _winnerText.text = "Winner is player 2!";
        }
        if (_player2.Lives == 0)
        {
            _winnerText.gameObject.SetActive(true);
            _winnerText.text = "Winner is player 1!";
        }

    }
}
