using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCtrl : MonoBehaviour
{
    public Transform[] wings;

    [Header("Wing Speed")]
    public float maxWingSpeed = 3000.0f;
    public float currWingSpeed = 0.0f;

    [Header("Move Speed")]
    public float updownSpeed = 10.0f;

    private Joystick leftJoyStick; //UP,DOWN : 상승,하강
    private Joystick rightJoyStick;//UP,DOWN : 전진,후진 /LEFT, RIGHT : 왼쪽이동, 오른쪽이동

    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();

        //동적으로 생성된 드론의 조이스틱 연결
        leftJoyStick = GameObject.Find("Fixed Joystick - Left").GetComponent<Joystick>();
        rightJoyStick = GameObject.Find("Fixed Joystick - Right").GetComponent<Joystick>();

        //코루틴 함수 호출
        StartCoroutine(this.ReadyDrone());
    }

    //코루틴 함수 - 러터 회전속도를 증가
    IEnumerator ReadyDrone()
    {
        while (currWingSpeed <= maxWingSpeed)
        {
            //현재 회전속도를 증가
            currWingSpeed += Time.deltaTime * 1000.0f;

            //다음 프레임까지 기다린다.
            yield return null;
        }
    }

    void Update()
    {
        float throttle = leftJoyStick.Vertical; //-1.0f ~ +1.0f

        RotateWings();
        UpDownMove(throttle);
    }

    void RotateWings()
    {
        for(int i=0; i<wings.Length; i++)
        {
            wings[i].Rotate(Vector3.up * Time.deltaTime * currWingSpeed);
        }
    }

    void UpDownMove(float damping)
    {
        tr.Translate(Vector3.up * Time.deltaTime * updownSpeed * damping);
    }
}
