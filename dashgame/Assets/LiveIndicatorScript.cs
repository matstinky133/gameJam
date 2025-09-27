using UnityEngine;

public class LiveIndicatorScript : MonoBehaviour
{
    [SerializeField] GameObject _life1, _life2, _life3;
    TaggingLogicScript _taggingLogic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _taggingLogic = gameObject.GetComponentInParent<TaggingLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_taggingLogic.Lives == 3)
        {
            _life1.SetActive(true);
            _life2.SetActive(true);
            _life3.SetActive(true);
        }
        if(_taggingLogic.Lives == 2)
        {
            _life1.SetActive(true);
            _life2.SetActive(true);
            _life3.SetActive(false);
        }
        if (_taggingLogic.Lives == 1)
        {
            _life1.SetActive(true);
            _life2.SetActive(false);
            _life3.SetActive(false);
        }
        if (_taggingLogic.Lives == 0)
        {
            _life1.SetActive(false);
            _life2.SetActive(false);
            _life3.SetActive(false);
        }
    }
}
