using UnityEngine;
using Valve.VR;

public class VRDebugDisplay : MonoBehaviour
{
    public HandGrab leftHandGrab;        // 左手のHandGrabスクリプト
    public HandGrab rightHandGrab;       // 右手のHandGrabスクリプト
    public Throwable throwable;          // ボールのThrowableスクリプト

    void OnGUI()
    {
        string heldInfo = throwable != null ? $"isHeld: {throwable.IsHeld}" : "isHeld: (null)";
        string leftCurrentInfo = leftHandGrab != null && leftHandGrab.CurrentThrowable != null
            ? $"currentThrowableL: {leftHandGrab.CurrentThrowable.name}"
            : "currentThrowableL: (null)";
        string rightCurrentInfo = rightHandGrab != null && rightHandGrab.CurrentThrowable != null
            ? $"currentThrowableR: {rightHandGrab.CurrentThrowable.name}"
            : "currentThrowableR: (null)";

        string velocityInfo = "";
        string angularVelocityInfo = "";

        // 掴んでる手のposeを判定し、速度と角速度を取得
        SteamVR_Behaviour_Pose pose = null;

        if (leftHandGrab != null && leftHandGrab.CurrentThrowable != null)
        {
            pose = leftHandGrab.GetComponent<SteamVR_Behaviour_Pose>();
        }
        else if (rightHandGrab != null && rightHandGrab.CurrentThrowable != null)
        {
            pose = rightHandGrab.GetComponent<SteamVR_Behaviour_Pose>();
        }

        if (pose != null)
        {
            Vector3 velocity = pose.GetVelocity();
            Vector3 angularVelocity = pose.GetAngularVelocity();
            velocityInfo = $"Velocity: {velocity}";
            angularVelocityInfo = $"AngularVelocity: {angularVelocity}";
        }
        else
        {
            velocityInfo = "Velocity: (null)";
            angularVelocityInfo = "AngularVelocity: (null)";
        }

        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(20, 20, 1000, 30), heldInfo, style);
        GUI.Label(new Rect(20, 60, 1000, 30), leftCurrentInfo, style);
        GUI.Label(new Rect(20, 100, 1000, 30), rightCurrentInfo, style);
        GUI.Label(new Rect(20, 140, 1000, 30), velocityInfo, style);
        GUI.Label(new Rect(20, 180, 1000, 30), angularVelocityInfo, style);
    }
}
