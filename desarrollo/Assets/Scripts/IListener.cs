using UnityEngine;
using System.Collections;
//-----------------------------------------------------------
//Enum defining all possible game events
//More events should be added to the list
public enum EVENT_TYPE
{
    GAME_INIT,
    GAME_END,
    GAME_PAUSE,
    CAM_UPDATE,
    SCENE_TEXTS
};
//-----------------------------------------------------------
//Listener interface to be implemented on Listener classes
public interface IListener
{
    //Notification function invoked when events happen
    void OnEvent(EVENT_TYPE Event_Type, Component Sender, System.Object Param = null);

}
//-----------------------------------------------------------