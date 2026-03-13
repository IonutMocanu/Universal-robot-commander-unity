using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosColor = RosMessageTypes.UnityRoboticsDemo.UnityColorMsg;
using RosMessageTypes.Sensor;
using UnityEngine.UI;

public class RosSubscriberCamera : MonoBehaviour
{

    [SerializeField]
    string topicName = "camera/camera/color/image_raw";

    [SerializeField]
    RawImage rawImage;

    private Texture2D cameraTexture;

    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<ImageMsg>(topicName, getImage);

        cameraTexture = new Texture2D(1, 1);
    }

    void getImage(ImageMsg imageMsg)
    {
        if (cameraTexture == null || cameraTexture.width != imageMsg.width || cameraTexture.height != imageMsg.height)
        {
            cameraTexture = new Texture2D((int)imageMsg.width, (int)imageMsg.height, TextureFormat.RGB24, false);
        }

        cameraTexture.LoadRawTextureData(imageMsg.data);
        cameraTexture.Apply();

        if (rawImage != null)
        {
            rawImage.texture = cameraTexture;
        }
    }
}
