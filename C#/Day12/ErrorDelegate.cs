// delegate void ErrorDelegate(string message);

class Button
{
    //Declare delegate
    public delegate void clickHandler();


    //Declear an event with delegate
    public event clickHandler Clicked;  //clicked is the event name 


    //Method that raise the event
    public void Click()
    {
        Clicked?.Invoke();
    }

}


