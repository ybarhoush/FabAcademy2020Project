/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.InputSystem;

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class MessageListener : MonoBehaviour
{
    // Invoked when a line of data is received from the serial device.
    public void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);

        // this works with CustomDevice.cs it actually feeds input for the device. Notice
        // that we already have the IInputUpdateCallbackReceiver interface on CustomDevice class.
        // What this does is to add an OnMessageArrived method that will automatically be called
        // by the input system whenever it updates!
        // Here >> feed input to our devices.
        //
        // NOTE: InputSystem.QueueEvent can be called from anywhere, including from threads. 
        //       So in this case, we have a background thread polling input from your device, 
        //       that's where we can also queue its input events.
        //
        // The original script read input on CustomDevice class. It made up some stuff
        // there for the sake of demonstration. Additionally, It polled the keyboard...
        //
        // NOTE: The keyboard there was part of OnUpdate. however,
        //       they run OnUpdate from onBeforeUpdate, i.e. from where keyboard
        //       input has not yet been processed. This means that our input will always
        //       be one frame late. Plus, because we are polling the keyboard state here
        //       on a frame-to-frame basis, we may miss inputs on the keyboard.
        //
        // NOTE: One thing we could instead is to actually use OnScreenControls that
        //       represent the controls of our device and then use that to generate
        //       input from actual human interaction.

        var state = new CustomDeviceState();

        state.x = 127;
        state.y = 127;

        // WARNING: It may be tempting to simply store some state related to updates
        //          directly on the device. For example, let's say we want scale the
        //          vector from WASD to a certain length which can be adjusted with
        //          the scroll wheel of the mouse. It seems natural to just store the
        //          current strength as a private field on CustomDevice.
        //
        //          This will *NOT* work correctly. *All* input state must be stored
        //          under the domain of the input system. InputDevices themselves
        //          cannot private store their own separate state.
        //
        //          What you *can* do however, is simply add fields your state struct
        //          (CustomDeviceState in our case) that contain the state you want
        //          to keep. It is not necessary to expose these as InputControls if
        //          you don't want to.

        // Map buttons to 1, 2, and 3.
        if (msg == "0")
            state.buttons |= 1; // |= will only ever add bits to the target

        //string msg1 = msgSplit[1];
        // Map the stick.
        if (msg == "right")
            state.x -= 127;
        if (msg == "left")
            state.x += 127;
        if (msg == "up")
            state.y += 127;
        if (msg == "down")
            state.y -= 127;

        // Finally, queue the event.
        // NOTE: We are replacing the current device state wholesale here. An alternative
        //       would be to use QueueDeltaStateEvent to replace only select memory contents.
        InputSystem.QueueStateEvent(CustomDevice.current, state);
    }
    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
