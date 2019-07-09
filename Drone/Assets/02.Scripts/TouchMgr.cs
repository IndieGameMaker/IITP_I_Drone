using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class TouchMgr : MonoBehaviour
{
    public GameObject drone;
    
    private bool isCreated = false;
    private TrackableHit hit;
    private TrackableHitFlags flags;

    void Start()
    {
        flags = TrackableHitFlags.FeaturePointWithSurfaceNormal | TrackableHitFlags.PlaneWithinPolygon;
    }

    void Update()
    {
        if (Input.touchCount == 0) return;
        
        //첫번째 터치의 정보를 저장
        Touch touch = Input.GetTouch(0);
        
        //터치했을 때 한번 발생하는 경우 //Input.GetMouseButtonDown(0) 와 같은 의미
        if (touch.phase == TouchPhase.Began && isCreated == false)
        {
            //스크린 x,y 좌푯값, 필터, 결괏값
            if (Frame.Raycast(touch.position.x, touch.position.y, flags, out hit))
            {
                //3차원 공간좌표를 기억하는 앵커를 생성
                Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);
                //드론 생성
                Instantiate(drone, hit.Pose.position, hit.Pose.rotation, anchor.transform);
                //드론의 생성여부
                isCreated = true;
            }
        }
    }
}
