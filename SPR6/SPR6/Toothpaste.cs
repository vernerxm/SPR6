namespace SPR6;
//Component
public abstract class ToothPaste
{
   public abstract string prepare() ;
   ~ToothPaste() { }
}
//Concrete component
class MintToothPaste : ToothPaste
{
    public override string prepare()
    {
        return "mint tooth paste";
    }
}
//Decorator
 public abstract class ToothPasteDecorator : ToothPaste
{
    protected ToothPaste decoratedToothPaste;

    public ToothPasteDecorator(ToothPaste _decoratedToothPaste)
    {
        decoratedToothPaste = _decoratedToothPaste;
    }
}
//Concrete decorators
class TubeDecorator : ToothPasteDecorator
{
    public TubeDecorator(ToothPaste _decoratedToothPaste) : base(_decoratedToothPaste) {}
  public  override string prepare()
    {
        return decoratedToothPaste.prepare() + " in a white tube";
    }
}
  class GumsDecorator : ToothPasteDecorator
{
    public GumsDecorator(ToothPaste _decoratedToothPaste) : base(_decoratedToothPaste) {}
    public  override string prepare()
    {
        return decoratedToothPaste.prepare() + " for sensitive gums";
    }
}
class PackagDecorator : ToothPasteDecorator
{
    public PackagDecorator(ToothPaste _decoratedToothPaste) : base(_decoratedToothPaste) {}
    public  override string prepare()
    {
        return decoratedToothPaste.prepare() + " in promotional packaging";
    }
}
public class Program
{
    static void Main()
    {
        var mintToothPaste = new MintToothPaste();
        var tubeDecorator = new TubeDecorator(mintToothPaste);
        var gumsDecorator = new GumsDecorator(tubeDecorator);
        var packageDecorator = new PackagDecorator(gumsDecorator);
        var preparedToothPaste = packageDecorator.prepare();
        
        Console.WriteLine("Toothpaste : "+preparedToothPaste);
    }
}