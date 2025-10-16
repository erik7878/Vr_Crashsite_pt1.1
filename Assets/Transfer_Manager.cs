using UnityEngine;

public class Transfer_Manager : MonoBehaviour
{
    public GameObject cameraModel;
    public GameObject flashlightModel;
    public Transform rightHandTransform;

    private Vector3 cameraStartPos;
    private Quaternion cameraStartRot;
    private Vector3 flashlightStartPos;
    private Quaternion flashlightStartRot;

    private GameObject currentTool;

    void Start()
    {
        cameraStartPos = cameraModel.transform.position;
        cameraStartRot = cameraModel.transform.rotation;
        flashlightStartPos = flashlightModel.transform.position;
        flashlightStartRot = flashlightModel.transform.rotation;
    }

    public void EquipCamera()
    {
        ResetTool();
        currentTool = cameraModel;
        AttachToHand(cameraModel);
    }

    public void EquipFlashlight()
    {
        ResetTool();
        currentTool = flashlightModel;
        AttachToHand(flashlightModel);
    }

    public void ResetTool()
    {
        if (currentTool == cameraModel)
        {
            cameraModel.transform.SetParent(null);
            cameraModel.transform.position = cameraStartPos;
            cameraModel.transform.rotation = cameraStartRot;
        }
        else if (currentTool == flashlightModel)
        {
            flashlightModel.transform.SetParent(null);
            flashlightModel.transform.position = flashlightStartPos;
            flashlightModel.transform.rotation = flashlightStartRot;
        }

        currentTool = null;
    }

    private void AttachToHand(GameObject tool)
    {
        tool.transform.SetParent(rightHandTransform);
        tool.transform.localPosition = Vector3.zero;
        tool.transform.localRotation = Quaternion.identity;
    }
}
