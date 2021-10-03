﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyPhotoshop
{
    public class FreeTransformer : ITransformer<EmptyParameters>
    {
        private Func<Size, Size> sizeTransformer;
        private Func<Point, Size, Point> pointTransformer;
        private Size oldSize;

        public FreeTransformer(Func<Size, Size> sizeTransformer, Func<Point, Size, Point> pointTransformer)
        {
            this.sizeTransformer = sizeTransformer;
            this.pointTransformer = pointTransformer;
        }
        
        public void Prepare(Size size, EmptyParameters parameters)
        {
            oldSize = size;
            ResultSize = sizeTransformer(oldSize);
        }

        public Size ResultSize { get; private set; }
        public Point? MapPoint(Point newPoint) => pointTransformer(newPoint, oldSize);
    }
}