namespace __MD.Script.Identifier.Contract
{
    public interface IMDConvertable<out T>
    {
        /************************************************************************************************************************/

        /// <summary>Returns the equivalent of this object as <typeparamref name="T"/>.</summary>
        T Convert();

        /************************************************************************************************************************/
    }
}