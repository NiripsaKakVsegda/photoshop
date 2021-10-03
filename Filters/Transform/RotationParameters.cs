namespace MyPhotoshop
{
    public class RotationParameters : IParameters
    {
        public double Angle { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new []
            {
                new ParameterInfo { Name="Угол", MaxValue=359, MinValue=0, Increment=1, DefaultValue=0 }
				
            };
        }

        public void SetValues(double[] values)
        {
            Angle = values[0];
        }
    }
}