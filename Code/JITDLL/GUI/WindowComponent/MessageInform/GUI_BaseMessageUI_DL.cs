using UnityEngine;
using System.Collections;

public abstract class GUI_BaseMessageUI_DL : GUI_Window_DL
{
    public EMessageType MessageType = EMessageType.MESSAGE_TYPE_COMMON;
    public abstract void ShowMessage(MessageArg arg);

    public void ShowNextMessage()
    {
        MessageArg arg = GUI_MessageManager.Instance.GetNextMessage(MessageType);
        if (arg == null)
        {
            HideWindow();
        }
        else
        {
            ShowMessage(arg);
        }
    }

    protected override void CopyDataFromDataScript()
    {
        base.CopyDataFromDataScript();
        GUI_BaseMessageUI dataComponent = gameObject.GetComponent<GUI_BaseMessageUI>();
        if (dataComponent == null)
        {
            UnityEngine.Debug.LogError("[�ȸ���]û���ҵ����������GUI_BaseMessageUI_DL,GameObject��" + gameObject.name, gameObject);
        }
        else
        {
            MessageType = dataComponent.MessageType;
        }
    }
}
