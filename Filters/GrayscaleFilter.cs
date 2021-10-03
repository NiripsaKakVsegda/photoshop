namespace MyPhotoshop
{
    public class GrayscaleFilter : PixelFilter<EmptyParameters>
    {
		
        public override string ToString ()
        {
            return "Ч\\Б эффект";
        }

        public override Pixel ProcessPixel(Pixel original, EmptyParameters parameters)
        {
            var median = (original.R + original.G + original.B) / 3;
            return new Pixel(median, median, median);
        }
    }
}