using UnityEngine;

public class TaggingLogicScript : MonoBehaviour
{
    [SerializeField] public int Lives = 3;
    [SerializeField] public bool _isTagger = false;
    public bool _IFrames = false;
    public float _IframeTime = 3f;
    public float _IframeTimer = 0f;
    private Movement _movement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = _isTagger ? Color.red : Color.white;
        CheckIFrames();


    }

    private void CheckIFrames()
    {
        
        if (_IframeTimer <= _IframeTime) _IframeTimer += Time.deltaTime;
        if (_IframeTimer > _IframeTime) _IFrames = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _movement._direction = _movement._direction * -1;
            if (collision.gameObject.GetComponent<TaggingLogicScript>()._isTagger == false && _isTagger == true && collision.gameObject.GetComponent<TaggingLogicScript>()._IFrames == false)
            {
                _IFrames = true;
                _IframeTimer = 0f;
                collision.gameObject.GetComponent<TaggingLogicScript>()._isTagger = true;
                

                _isTagger = false;
                

            }
        }
    }
}
