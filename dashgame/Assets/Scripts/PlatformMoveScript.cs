using System.Threading;
using UnityEngine;

public class PlatformMoveScript : MonoBehaviour
{
    [SerializeField] float timeToReturn;
    private float _timer;
    [SerializeField] float _speed;
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > (2* Mathf.PI))
        {
            _timer = 0;
        }
        float sinus = timeToReturn * Mathf.Sin(_speed*(_timer));
       // Debug.Log(sinus);
        //Mathf.Sin()
        transform.position = _startPosition + new Vector3(sinus, 0, 0);
    }
}
