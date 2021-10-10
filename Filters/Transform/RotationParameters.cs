namespace MyPhotoshop
{
    public class RotationParameters : IParameters
    {
        [ParameterInfo(Name="Угол", MaxValue=359, MinValue=0, Increment=1, DefaultValue=0)]
        public double Angle { get; set; }
    }
}