using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static int wave;
    public static int stage;



    void NextWave()
    {

    }

    void CheckStage()
    {
        if (wave == 10 || wave == 30 || wave == 70 || wave == 150)
        {
            stage++;
            CameraController.instance.UpdateCameraBorders(stage);
        }
    }
}
