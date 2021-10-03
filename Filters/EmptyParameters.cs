namespace MyPhotoshop
{
    public class EmptyParameters : IParameters
    {
        public ParameterInfo[] GetDescription()
        {
            return new ParameterInfo[] { };
        }

        public void SetValues(double[] values)
        {
        }
    }
}