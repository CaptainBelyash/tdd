﻿using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;

[assembly: InternalsVisibleTo("TagsCloudVisualization_Tests")]
namespace TagsCloudVisualization
{
    public class BadLayouter : IRectangleLayouter
    {
        public Point Center { get; }
        public List<Rectangle> Rectangles => rectangles.ToList();

        private List<Rectangle> rectangles;
        private Point nextPos;

        public BadLayouter(Point center)
        {
            rectangles = new List<Rectangle>();
            Center = center;
            nextPos = center;
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            // Имитация плохой формы
            var rectangle = GetNextRectangle(rectangleSize);
            rectangles.Add(rectangle);
            return rectangle;
        }

        private Rectangle GetNextRectangle(Size rectangleSize)
        {
            var rectangle = new Rectangle(nextPos, rectangleSize);
            // Имитация возможного пересечения
            if (rectangles.Count != 10)
                nextPos.X += rectangle.Width;
            return rectangle;
        }
    }
}