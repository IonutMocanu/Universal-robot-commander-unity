using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry; 
using RosMessageTypes.Std;
using RosMessageTypes.BuiltinInterfaces;
using UnityEngine.UI;

public class RosPublisherCMDVel : MonoBehaviour
{
    private ROSConnection ros;
    public string topicName = "cmd_vel";

    [SerializeField] private Slider _slider;

    private float _sliderValue;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<TwistStampedMsg>(topicName);
        _slider.onValueChanged.AddListener((v) => {
            _sliderValue = v;
        });
    }

    public void MoveForward()
    {
        Debug.Log("Inainte");
        PublishTwist(_sliderValue * new Vector3(1.0f,0f,0f), _sliderValue * new Vector3(0f,0f,0f));
    }
    public void MoveForwardRight()
    {
        Debug.Log("Inainte Dreapta");
        PublishTwist(_sliderValue * new Vector3(1.0f, 0f, 0f), _sliderValue * new Vector3(0, 0f, -1.5f));
    }

    public void MoveForwardLeft()
    {
        Debug.Log("Inainte Stanga");
        PublishTwist(_sliderValue * new Vector3(1.0f, 0f, 0f), _sliderValue * new Vector3(0, 0f, 1.5f));
    }

    public void MoveBack()
    {
        Debug.Log("Inapoi");
        PublishTwist(_sliderValue * new Vector3(-1.0f, 0f, 0f), _sliderValue * new Vector3(0f, 0f, 0f));
    }

    public void MoveBackRight()
    {
        Debug.Log("Inapoi dreapta");
        PublishTwist(_sliderValue * new Vector3(-1.0f, 0f, 0f), _sliderValue * new Vector3(0f, 0f, 1.5f));
    }

    public void MoveBackLeft()
    {
        Debug.Log("Inapoi stanga");
        PublishTwist(_sliderValue * new Vector3(-1.0f, 0f, 0f), _sliderValue * new Vector3(0f, 0f, -1.5f));
    }
    public void RightOnPlace()
    {
        Debug.Log("Inapoi stanga");
        PublishTwist(_sliderValue * new Vector3(0f, 0f, 0f), _sliderValue * new Vector3(0f, 0f, 1f));
    }

    public void LeftOnPlace()
    {
        Debug.Log("Inapoi stanga");
        PublishTwist(_sliderValue * new Vector3(0f, 0f, 0f), _sliderValue * new Vector3(0f, 0f, -1f));
    }

    public void Stop()
    {
        Debug.Log("Stop");
        PublishTwist( new Vector3(0.0f, 0f, 0f), new Vector3(0f, 0f, 0f));
    }

    public void PublishTwist(Vector3 linear, Vector3 angular)
    {
        TwistStampedMsg twistMessage = new TwistStampedMsg();

        long unixTimeSeconds = System.DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        long unixTimeMilliseconds = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        uint nanosec = (uint)((unixTimeMilliseconds % 1000) * 1e6);

        twistMessage.header = new HeaderMsg
        {
            frame_id = "base_link",
            stamp = new TimeMsg
            {
                sec = (int)unixTimeSeconds,
                nanosec = (uint)nanosec
            }
        };

        twistMessage.twist.linear.x = linear.x; 
        twistMessage.twist.linear.y = linear.y;
        twistMessage.twist.linear.z = linear.z;

        twistMessage.twist.angular.x = angular.x;
        twistMessage.twist.angular.y = angular.y;
        twistMessage.twist.angular.z = angular.z;

        ros.Publish(topicName, twistMessage);
    }
}