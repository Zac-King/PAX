/*
    // Camera Setup //
    We use a pivot-based camera rig similar to the standard Unity camera rigs.
    The structure of this camera rig is:

    Base - follows the target
        Pivot - This transform controls the y-offset.
            Camera - The camera controls the x-offset, y-offset, and rotation

    // Camera Network //
    To set up a camera network that swaps cameras on triggers, you need to:
    1. Put a trigger in the scene
    2. Add a CameraBroadcast to the trigger
    3. Give the name of the message to broadcast. i.e. "CameraEvent"
    4. Add cameras to the scene
    5. For each camera:
        -In the CameraListener: 
        1. Set the "Listening For" field to the name of the message to 
            listen for. Using the example above, this would be "CameraEvent"
        2. If this camera is the camera that should be active on game start,
            check the "Start Cam" checkbox
        3. The Activator slots are the triggers that this camera is activated with. 
            -Currently supports two activators. 
            1) Drag the activator in the first empty slot. If an 
                activator slot(s) is not used, leave it empty.
*/

using UnityEngine;
using System.Collections;

public class CameraBase : MonoBehaviour
{
    
}
