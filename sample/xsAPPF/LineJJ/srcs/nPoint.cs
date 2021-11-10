using System;
using System.Drawing;

namespace LineJJ
{
  public class LinePoint
  {
    public Point ptBasePoint = new Point(250, 35);
    public Point ptAGV;
    public Point ptParking;

    public Point ptOffset;

    public Point[] ptLineRect = new Point[2];

    public Point ptEnd01;
    public Point ptEnd02;


    public Point[] ptCurveA = new Point[2];
    public Point[] ptCurveB = new Point[2];
    public Point[] ptCurveC = new Point[2];

    public Point[] ptA4 = new Point[24];
    public Point[] ptB4 = new Point[24];
    public Point[] ptC4 = new Point[24];
    public Point[] ptD4 = new Point[24];
    public Point[] ptE4 = new Point[24];


    public LinePoint(int offsetX, int offsetY)
    {
      Init(offsetX, offsetY);
    }

    private void Init(int offsetX, int offsetY)
    {
      ptAGV = ptBasePoint;
      ptParking = ptBasePoint;

      ptOffset.X = (-1) * offsetX;
      ptOffset.Y = (-1) * offsetY;

      ptParking.X += ptOffset.X;
      ptParking.Y += ptOffset.Y;

      ptCurveA[0] = new Point(ptParking.X, ptParking.Y + 75);
      ptCurveA[1] = new Point(ptCurveA[0].X - 30, ptCurveA[0].Y + 30);

      ptCurveB[0] = new Point(ptCurveA[1].X - 60, ptCurveA[1].Y);
      ptCurveB[1] = new Point(ptCurveB[0].X - 30, ptCurveB[0].Y + 30);

      ptCurveC[0] = new Point(ptCurveB[0].X, ptCurveB[1].Y + 325);
      ptCurveC[1] = new Point(ptCurveB[1].X, ptCurveC[0].Y + 30);

      ptLineRect[0] = new Point(950 + ptOffset.X, ptCurveA[1].Y);
      ptLineRect[1] = new Point(ptCurveC[1].X, ptCurveC[1].Y);



      ptA4[14] = new Point(ptCurveB[1].X, 225);
      ptB4[13] = new Point(ptCurveB[1].X, 240);
      ptC4[12] = new Point(ptCurveB[1].X, 255);
      ptD4[11] = new Point(ptCurveB[1].X, 270);
      ptE4[10] = new Point(ptCurveB[1].X, 285);


      ptAGV.X = ptAGV.X + ptOffset.X;
      ptAGV.Y = ptAGV.Y + ptOffset.Y;


      ptEnd01.X = ptLineRect[0].X;
      ptEnd01.Y = ptLineRect[0].Y;

      ptEnd02.X = ptLineRect[0].X;
      ptEnd02.Y = ptLineRect[1].Y;

      ptParking = ptAGV;



      //ptA4[03].X = offset;
      //ptA4[06].X = offset;
      //ptA4[09].X = offset;
      //ptA4[14].X = offset;
      ptA4[17].X = ptParking.X + offsetX;
      ptA4[20].X = ptLineRect[0].Y;
      ptA4[23].X = ptParking.X + offsetX + 560;
      ptA4[23].Y = ptLineRect[0].Y;

      //ptB4[01].X = offset;
      //ptB4[04].X = offset;
      //ptB4[07].X = offset;
      //ptB4[13].X = offset;
      //ptB4[15].X = offset;
      //ptB4[18].X = offset;
      //ptB4[21].X = offset;

      //ptC4[01].X = offset;
      //ptC4[04].X = offset;
      //ptC4[07].X = offset;
      //ptC4[12].X = offset;
      //ptC4[15].X = offset;
      //ptC4[18].X = offset;
      //ptC4[21].X = offset;

      //ptD4[01].X = offset;
      //ptD4[04].X = offset;
      //ptD4[07].X = offset;
      //ptD4[11].X = offset;
      //ptD4[15].X = offset;
      //ptD4[18].X = offset;
      //ptD4[21].X = offset;

      ptE4[01].X = ptParking.X + offsetX + 655;
      ptE4[01].Y = ptLineRect[1].Y;
      //ptD4[02].X = offset;
      //ptD4[04].X = offset;
      //ptD4[05].X = offset;
      //ptD4[07].X = offset;
      //ptD4[08].X = offset;
      //ptD4[10].X = offset;
      //ptD4[15].X = offset;
      //ptD4[16].X = offset;
      //ptD4[18].X = offset;
      //ptD4[19].X = offset;
      //ptD4[21].X = offset;
      //ptD4[22].X = offset;

    }
  };


}
