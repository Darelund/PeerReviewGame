using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "ScriptableObject/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public List<Info> DialogueInfo;

}
[System.Serializable]
public class Info
{
    [TextArea(4, 8)]
    public string Dialogue;
}