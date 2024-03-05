using UnityEditor;

[CustomEditor(typeof(Interacteble),true)]
public class InteractibleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interacteble interacteble = (Interacteble)target;

        if(target.GetType() == typeof(EventOnlyInteracteble))
        {
            interacteble.promptMessage = EditorGUILayout.TextField("Prompt Message", interacteble.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents.", MessageType.Info);
            if(interacteble.GetComponent<InteractionEvent>() == null)
            {
                interacteble.useEvents = true;
                interacteble.gameObject.AddComponent<InteractionEvent>();
            }
        } 
        else
        { 

            base.OnInspectorGUI();

            if( interacteble.useEvents )
            {
                //we are using events. add the component
                if(interacteble.GetComponent<InteractionEvent>() == null )
                {
                    interacteble.gameObject.AddComponent<InteractionEvent>();
                }
            }
            else
            {
                //we are not using events. remove the component
                if (interacteble.GetComponent<InteractionEvent>() != null)
                {
                    DestroyImmediate(interacteble.GetComponent<InteractionEvent>());
                }
            }
        }
    }
}
