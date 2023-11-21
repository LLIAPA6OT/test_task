    class FindSquare
    {

        /// <summary>
        /// Площадь ткруга по радиусу
        /// </summary>
        public static double GetCyrcleSquare(double r)
        {
            return Math.PI * r * r;
        }

        private static void CheckIsPossible(double[] sides)
        {
            if (sides[0] >= sides[1] + sides[2])
            {
                throw new Exception("Такого треугольника не существует");
            }
        }
        private static bool CheckIsRectangular(double[] sides)
        {
            return sides[0] * sides[0] == sides[1] * sides[1] + sides[2] * sides[2];
        }

        /// <summary>
        /// Проверка на то, является ли треугольник прямоугольным
        /// Возвращает исключение если наибольшая из сторон больше или равна сумме других сторон
        /// </summary>
        public static bool CheckIsRectangular(double sideA, double sideB, double sideC)
        {
            var arr = new List<double> { sideA, sideB, sideC }.OrderByDescending(x => x).ToArray();
            CheckIsPossible(arr);
            return CheckIsRectangular(arr);
        }

        /// <summary>
        /// Площадь треугольника по трем сторонам
        /// Возвращает исключение если наибольшая из сторон больше или равна сумме других сторон
        /// </summary>
        public static double GetTriangleSquare(double sideA, double sideB, double sideC)
        {
            CheckIsPossible(new List<double> { sideA, sideB, sideC }.OrderByDescending(x => x).ToArray());
            var p = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }

        private static bool CheckIsOnOneLine(Point point1, Point point2, Point point3)
        {
            return (point3.Y - point1.Y) * (point2.X - point1.X) == (point2.Y - point1.Y) * (point3.X - point1.X);
        }

        private static bool ParityCheck(Point p1, Point p2, Point p3, Point p4)
        {
            return ((p3.X - p2.X) * (p2.Y - p1.Y) - (p3.Y - p2.Y) * (p2.X - p1.X)) * ((p4.X - p2.X) * (p2.Y - p1.Y) - (p4.Y - p2.Y) * (p2.X - p1.X)) < 0;
        }

        private static double GetSquare(Point point1, Point point2, Point point3, Point point4)
        {
            return GetSegmentLength(point1, point2) * GetSegmentLength(point3, point4) * GetAngleBetweenLinesSin(point1, point2, point3, point4) / 2;
        }

        private static double GetAngleBetweenLinesSin(Point p11, Point p12, Point p21, Point p22)
        {
            return Math.Sin(Math.Acos(((p12.X - p11.X) * (p22.X - p21.X) + (p12.Y - p11.Y) * (p22.Y - p21.Y)) / Math.Sqrt(Math.Pow(p12.X - p11.X, 2) + Math.Pow(p12.Y - p11.Y, 2)) / Math.Sqrt(Math.Pow(p22.X - p21.X, 2) + Math.Pow(p22.Y - p21.Y, 2))));
        }

        private static double GetSegmentLength(Point point1, Point point2)
        {
            return Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
        }

        /// <summary>
        /// Площадь четырехугольника по вершинам
        /// Возвращает исключение если несколько вершин совпадают или три или более вершины находятся на одной прямой
        /// </summary>
        public static double GetQuadrilateralSquare(Point pointA, Point pointB, Point pointC, Point pointD)
        {
            if (new List<Point>() { pointA, pointB, pointC, pointD }.Distinct().Count() < 4)
            {
                throw new Exception("Несколько вершин совпадают");
            }
            if (CheckIsOnOneLine(pointA, pointB, pointC) || CheckIsOnOneLine(pointA, pointB, pointD) || CheckIsOnOneLine(pointA, pointC, pointD) || CheckIsOnOneLine(pointB, pointC, pointD))
            {
                throw new Exception("Три или более вершины находятся на одной прямой");
            }
            if (ParityCheck(pointA, pointC, pointB, pointD) || ParityCheck(pointB, pointD, pointA, pointC))
            {
                return GetSquare(pointA, pointC, pointB, pointD);
            }
            if (ParityCheck(pointA, pointB, pointC, pointD) || ParityCheck(pointC, pointD, pointA, pointB))
            {
                return GetSquare(pointA, pointB, pointC, pointD);
            }
            return GetSquare(pointA, pointD, pointB, pointC);
        }

    }
