using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float _timer = 0;
    [SerializeField] private float TimeToExplode = 5f;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _positionUpValue;

    void Start()
    {
        _image = GetComponent<Image>();
        _timer = TimeToExplode;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(_player.transform.position+ _positionUpValue *Vector3.up);
        _timer -= Time.deltaTime;
        if(_timer < 0)
        {
            _timer = 0;
        }


        _image.fillAmount = _timer/TimeToExplode;

       


    }
}
