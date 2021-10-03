using System;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public Pixel(double r, double g, double b)
        {
            this.r = this.g = this.b = 0;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public static Pixel operator *(Pixel pixel, double value)
        {
            return new Pixel(Trim(pixel.r*value), Trim(pixel.g*value), Trim(pixel.b*value));
        }
        
        public static Pixel operator *(double value, Pixel pixel)
        {
            return pixel * value;
        }
        
        double Check(double value)
        {
            if (value < 0 || value > 1) throw new ArgumentException();
            return value;
        }
        
        public static double Trim(double value) => value > 1 ? 1 : value < 0 ? 0 : value;
        
        private double r;
        public double R
        {
            get => r;
            set => r = Check(value);
        }
        
        private double g;
        public double G
        {
            get => g;
            set => g = Check(value);
        }
        
        private double b;
        public double B
        {
            get => b;
            set => b = Check(value);
        }
    }
}