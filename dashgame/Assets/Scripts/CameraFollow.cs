using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player1, Player2;
    [SerializeField] Vector2[] border;
    [SerializeField] float _zoomvalue;
    [SerializeField] float _variable;
    [SerializeField] float _minZoomValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = ;
        Vector2 sumPosition =  Player1.transform.position + Player2.transform.position;
        Vector2 avaragePos = sumPosition / 2;
        Vector3 camPos = new Vector3(avaragePos.x, avaragePos.y, -10);

        if(camPos.x > border[0].x && camPos.x < border[1].x)
        {
            transform.position = new Vector3(camPos.x, transform.position.y, -10);
        }
        if (camPos.y < border[0].y && camPos.y > border[1].y)
        {
            transform.position = new Vector3(transform.position.x ,camPos.y, -10);
        }
         _zoomvalue =     _variable *  Mathf.Abs( Vector3.Distance(Player1.transform.position, Player2.transform.position));

        if(_zoomvalue >= _minZoomValue)
        {
            Camera.main.orthographicSize = _zoomvalue;
        }
       

    }
}
