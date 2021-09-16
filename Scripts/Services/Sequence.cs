using System.Collections;
using UnityEngine;

public delegate YieldInstruction SequenceAction();

public class Sequence : MonoBehaviour
{
    private SequenceAction[] _sequenceActions;
    private const string SequenceName = nameof(Sequence);

    public static Sequence Create(params SequenceAction[] actions)
    {
        var sequence = new GameObject(SequenceName).AddComponent<Sequence>();
        sequence.Initialize(actions);
        return sequence;
    }

    public void Execute() => StartCoroutine(ExecuteAll());

    private void Initialize(SequenceAction[] actions)
    {
        _sequenceActions = actions;
    }

    private IEnumerator ExecuteAll()
    {
        if (_sequenceActions == null)
            Destroy(gameObject);

        foreach (var yieldInstruction in _sequenceActions)
            yield return yieldInstruction?.Invoke();

        Destroy(gameObject);
    }
}
