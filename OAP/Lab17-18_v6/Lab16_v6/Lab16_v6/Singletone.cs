public class ProgramObject
{
    public Interface Interface { get; set; }
    public void Launch(string _backgroundColor, string _font, string _size)
    {
        Interface = Interface.getInstance(_backgroundColor,_font,_size);
    }
}
public class Interface
{
    private static Interface instance;

    public string backgroundColor { get; private set; }

    public string font { get; private set; }

    public string size { get; private set; }


    protected Interface(string _bgc, string _font, string _size)
    {
        this.backgroundColor = _bgc;
        this.font = _font;
        this.size = _size;
    }

    public static Interface getInstance(string _backgroundColor, string _font, string _size)
    {
        if (instance == null)
            instance = new Interface(_backgroundColor,_font,_size);

        return instance;
    }
}