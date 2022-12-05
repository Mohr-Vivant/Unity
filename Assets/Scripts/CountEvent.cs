
using UnityEngine;
using UnityEngine.Events;

public class CountEvent : MonoBehaviour
{
    public int minimum = 0, startCount = 1, maximum = 3;
    public UnityEvent eventAtMinimum, eventAtMaximum, eventOnRemove, eventOnAdd;

    [ContextMenu("Add One")]
    public void Add_One(){
        Add_Or_Remove_Number(1);
    }
    [ContextMenu("Remove One")]
    public void Remove_One(){
        Add_Or_Remove_Number(-1);
    }

    public void Add_Or_Remove_Number(int number)
    {
        if (number > 0 && startCount >= minimum){
            if (startCount < maximum)
                eventOnAdd.Invoke();
            if (startCount < maximum && startCount + number >= maximum)
                eventAtMaximum.Invoke();
        }
        if (number < 0 && startCount <= maximum){
            if (startCount > minimum)
                eventOnRemove.Invoke();
            if (startCount > minimum && startCount + number <= minimum)
                eventAtMinimum.Invoke();
        }
        startCount += number;
    }
}
