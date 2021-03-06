﻿using System;

namespace RogueSharp
{
   /// <summary>
   /// A class that defines a rectangle
   /// </summary>
   public class Rectangle : IEquatable<Rectangle>
   {
      private static readonly Rectangle _emptyRectangle = new Rectangle();
      /// <summary>
      /// Specifies the Height of the Rectangle
      /// </summary>
      public int Height { get; set; }
      /// <summary>
      /// Specifies the Width of the Rectangle
      /// </summary>
      public int Width { get; set; }
      /// <summary>
      /// Specifies the x-coordinate of the Rectangle with 0 being to the left
      /// and increasing as the Rectangle is moved to the right
      /// </summary>
      public int X { get; set; }
      /// <summary>
      /// Specifies the y-coordinate of the Rectangle with 0 being at the top 
      /// and increasing as the Rectangle is moved downwards
      /// </summary>
      public int Y { get; set; }
      /// <summary>
      /// Initializes a new instance of Rectangle
      /// </summary>
      public Rectangle()
      {
      }
      /// <summary>
      /// Initializes a new instance of Rectangle
      /// </summary>
      /// <param name="x">The x-coordinate of the Rectangle with 0 being to the left</param>
      /// <param name="y">The y-coordinate of the Rectangle with 0 being at the top</param>
      /// <param name="width">Width of the Rectangle</param>
      /// <param name="height">Height of the Rectangle</param>
      public Rectangle( int x, int y, int width, int height )
      {
         X = x;
         Y = y;
         Width = width;
         Height = height;
      }
      /// <summary>
      /// Returns a Rectangle with all of its values set to zero
      /// </summary>
      public static Rectangle Empty
      {
         get
         {
            return _emptyRectangle;
         }
      }
      /// <summary>
      /// Returns the x-coordinate of the left side of the rectangle
      /// </summary>
      public int Left
      {
         get
         {
            return X;
         }
      }
      /// <summary>
      /// Returns the x-coordinate of the right side of the rectangle
      /// </summary>
      public int Right
      {
         get
         {
            return ( X + Width );
         }
      }
      /// <summary>
      /// Returns the y-coordinate of the top of the rectangle
      /// </summary>
      public int Top
      {
         get
         {
            return Y;
         }
      }
      /// <summary>
      /// Returns the y-coordinate of the bottom of the rectangle
      /// </summary>
      public int Bottom
      {
         get
         {
            return ( Y + Height );
         }
      }
      /// <summary>
      /// Gets or sets the Point representing the upper-left value of the Rectangle
      /// </summary>
      public Point Location
      {
         get
         {
            return new Point( X, Y );
         }
         set
         {
            if ( value == null )
            {
               throw new ArgumentNullException( "value" );
            }

            X = value.X;
            Y = value.Y;
         }
      }
      /// <summary>
      /// Returns the Point that specifies the center of the rectangle
      /// </summary>
      public Point Center
      {
         get
         {
            return new Point( X + ( Width / 2 ), Y + ( Height / 2 ) );
         }
      }
      /// <summary>
      /// Returns a value that indicates whether the Rectangle is empty
      /// true if the Rectangle is empty; otherwise false
      /// </summary>
      public bool IsEmpty
      {
         get
         {
            return ( ( ( ( Width == 0 ) && ( Height == 0 ) ) && ( X == 0 ) ) && ( Y == 0 ) );
         }
      }
      /// <summary>
      /// Determines whether two Rectangle instances are equal
      /// </summary>
      /// <param name="other">The Rectangle to compare this instance to</param>
      /// <returns>True if the instances are equal; False otherwise</returns>
      /// <exception cref="NullReferenceException">Thrown if .Equals is invoked on null Rectangle</exception>
      public bool Equals( Rectangle other )
      {
         if ( other == null )
         {
            return false;
         }

         return this == other;
      }
      /// <summary>
      /// Compares two rectangles for equality
      /// </summary>
      /// <param name="a">Rectangle on the left side of the equals sign</param>
      /// <param name="b">Rectangle on the right side of the equals sign</param>
      /// <returns>True if the rectangles are equal; False otherwise</returns>
      public static bool operator ==( Rectangle a, Rectangle b )
      {
         if ( ReferenceEquals( a, null) && ReferenceEquals( b, null) )
         {
            return true;
         }
         if ( ReferenceEquals( a, null ) || ReferenceEquals( b, null ) )
         {
            return false;
         }

         return ( ( a.X == b.X ) && ( a.Y == b.Y ) && ( a.Width == b.Width ) && ( a.Height == b.Height ) );
      }
      /// <summary>
      /// Determines whether this Rectangle contains a specified point represented by its x and y-coordinates
      /// </summary>
      /// <param name="x">The x-coordinate of the specified point</param>
      /// <param name="y">The y-coordinate of the specified point</param>
      /// <returns>True if the specified point is contained within this Rectangle; False otherwise</returns>
      public bool Contains( int x, int y )
      {
         return ( ( ( ( X <= x ) && ( x < ( X + Width ) ) ) && ( Y <= y ) ) && ( y < ( Y + Height ) ) );
      }
      /// <summary>
      /// Determines whether this Rectangle contains a specified Point
      /// </summary>
      /// <param name="value">The Point to evaluate</param>
      /// <returns>True if the specified Point is contained within this Rectangle; False otherwise</returns>
      public bool Contains( Point value )
      {
         if ( value == null )
         {
            return false;
         }

         return ( ( ( ( X <= value.X ) && ( value.X < ( X + Width ) ) ) && ( Y <= value.Y ) ) && ( value.Y < ( Y + Height ) ) );
      }
      /// <summary>
      /// Determines whether this Rectangle entirely contains the specified Rectangle
      /// </summary>
      /// <param name="value">The Rectangle to evaluate</param>
      /// <returns>True if this Rectangle entirely contains the specified Rectangle; False otherwise</returns>
      public bool Contains( Rectangle value )
      {
         if ( value == null )
         {
            return false;
         }

         return ( ( ( ( X <= value.X ) && ( ( value.X + value.Width ) <= ( X + Width ) ) ) && ( Y <= value.Y ) )
                  && ( ( value.Y + value.Height ) <= ( Y + Height ) ) );
      }
      /// <summary>
      /// Compares two rectangles for inequality
      /// </summary>
      /// <param name="a">Rectangle on the left side of the equals sign</param>
      /// <param name="b">Rectangle on the right side of the equals sign</param>
      /// <returns>True if the rectangles are not equal; False otherwise</returns>
      public static bool operator !=( Rectangle a, Rectangle b )
      {
         return !( a == b );
      }
      /// <summary>
      /// Changes the position of the Rectangles by the values of the specified Point
      /// </summary>
      /// <param name="offset">The values to adjust the position of the Rectangle by</param>
      /// <exception cref="ArgumentNullException">Thrown if offset is null</exception>
      public void Offset( Point offset )
      {
         if ( offset == null )
         {
            throw new ArgumentNullException( "offset", "Point offset cannot be null" );
         }

         X += offset.X;
         Y += offset.Y;
      }
      /// <summary>
      /// Changes the position of the Rectangle by the specified x and y offsets
      /// </summary>
      /// <param name="offsetX">Change in the x-position</param>
      /// <param name="offsetY">Change in the y-position</param>
      public void Offset( int offsetX, int offsetY )
      {
         X += offsetX;
         Y += offsetY;
      }
      /// <summary>
      /// Pushes the edges of the Rectangle out by the specified horizontal and vertical values
      /// </summary>
      /// <param name="horizontalValue">Value to push the sides out by</param>
      /// <param name="verticalValue">Value to push the top and bottom out by</param>
      /// <exception cref="OverflowException">Thrown if the new width or height exceed Int32.MaxValue, or new X or Y are smaller than int32.MinValue</exception>
      public void Inflate( int horizontalValue, int verticalValue )
      {
         X -= horizontalValue;
         Y -= verticalValue;
         Width += horizontalValue * 2;
         Height += verticalValue * 2;            
      }
      /// <summary>
      /// Determines whether two Rectangle instances are equal
      /// </summary>
      /// <param name="obj">The Object to compare this instance to</param>
      /// <returns>True if the instances are equal; False otherwise</returns>
      /// <exception cref="NullReferenceException">Thrown if .Equals is invoked on null Rectangle</exception>
      public override bool Equals( object obj )
      {
         Rectangle rectangle = obj as Rectangle;
         if ( rectangle == null )
         {
            return false;
         }

         return Equals( rectangle );
      }
      /// <summary>
      /// Returns a string that represents the current Rectangle
      /// </summary>
      /// <returns>A string that represents the current Rectangle</returns>
      public override string ToString()
      {
         return string.Format( "{{X:{0} Y:{1} Width:{2} Height:{3}}}", X, Y, Width, Height );
      }
      /// <summary>
      /// Gets the hash code for this object which can help for quick checks of equality
      /// or when inserting this Rectangle into a hash-based collection such as a Dictionary or Hashtable 
      /// </summary>
      /// <returns>An integer hash used to identify this Rectangle</returns>
      public override int GetHashCode()
      {
         return ( X ^ Y ^ Width ^ Height );
      }
      /// <summary>
      /// Determines whether this Rectangle intersects with the specified Rectangle
      /// </summary>
      /// <param name="value">The Rectangle to evaluate</param>
      /// <returns>True if the specified Rectangle intersects with this one; False otherwise</returns>
      public bool Intersects( Rectangle value )
      {
         if ( value == null )
         {
            return false;
         }

         return value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;
      }
      /// <summary>
      /// Determines whether this Rectangle intersects with the specified Rectangle
      /// </summary>
      /// <param name="value">The Rectangle to evaluate</param>
      /// <param name="result">True if the specified Rectangle intersects with this one; False otherwise</param>
      public void Intersects( ref Rectangle value, out bool result )
      {
         if ( value == null )
         {
            result = false;
            return;
         }

         result = value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;
      }
      /// <summary>
      /// Creates a Rectangle defining the area where one Rectangle overlaps with another Rectangle
      /// </summary>
      /// <param name="value1">The first Rectangle to compare</param>
      /// <param name="value2">The second Rectangle to compare</param>
      /// <returns>The area where the two specified Rectangles overlap. If the two Rectangles do not overlap the resulting Rectangle will be Empty</returns>
      public static Rectangle Intersect( Rectangle value1, Rectangle value2 )
      {
         Rectangle rectangle;
         Intersect( ref value1, ref value2, out rectangle );
         return rectangle;
      }
      /// <summary>
      /// Creates a Rectangle defining the area where one Rectangle overlaps with another Rectangle
      /// </summary>
      /// <param name="value1">The first Rectangle to compare</param>
      /// <param name="value2">The second Rectangle to compare</param>
      /// <param name="result">The area where the two specified Rectangles overlap. If the two Rectangles do not overlap the resulting Rectangle will be Empty</param>
      public static void Intersect( ref Rectangle value1, ref Rectangle value2, out Rectangle result )
      {
         if ( value1 != null && value2 != null && value1.Intersects( value2 ) )
         {
            int rightSide = Math.Min( value1.X + value1.Width, value2.X + value2.Width );
            int leftSide = Math.Max( value1.X, value2.X );
            int topSide = Math.Max( value1.Y, value2.Y );
            int bottomSide = Math.Min( value1.Y + value1.Height, value2.Y + value2.Height );
            result = new Rectangle( leftSide, topSide, rightSide - leftSide, bottomSide - topSide );
         }
         else
         {
            result = new Rectangle( 0, 0, 0, 0 );
         }
      }
      /// <summary>
      /// Creates a new Rectangle that exactly contains the specified two Rectangles
      /// </summary>
      /// <param name="value1">The first Rectangle to contain</param>
      /// <param name="value2">The second Rectangle to contain</param>
      /// <returns>A new Rectangle that exactly contains the specified two Rectangles</returns>
      /// <exception cref="NullReferenceException">Thrown if either rectangle is null</exception>
      public static Rectangle Union( Rectangle value1, Rectangle value2 )
      {
         if ( value1 == null )
         {
            throw new ArgumentNullException( "value1", "Rectangle cannot be null" );
         }
         if ( value2 == null )
         {
            throw new ArgumentNullException( "value2", "Rectangle cannot be null" );
         }

         int x = Math.Min( value1.X, value2.X );
         int y = Math.Min( value1.Y, value2.Y );
         return new Rectangle( x, y, Math.Max( value1.Right, value2.Right ) - x, Math.Max( value1.Bottom, value2.Bottom ) - y );
      }
      /// <summary>
      /// Creates a new Rectangle that exactly contains the specified two Rectangles
      /// </summary>
      /// <param name="value1">The first Rectangle to contain</param>
      /// <param name="value2">The second Rectangle to contain</param>
      /// <param name="result">A new Rectangle that exactly contains the specified two Rectangles</param>
      /// <exception cref="NullReferenceException">Thrown if either rectangle is null</exception>
      public static void Union( ref Rectangle value1, ref Rectangle value2, out Rectangle result )
      {
         if ( value1 == null )
         {
            throw new ArgumentNullException( "value1", "Rectangle cannot be null" );
         }
         if ( value2 == null )
         {
            throw new ArgumentNullException( "value2", "Rectangle cannot be null" );
         }

         result = new Rectangle();
         result.X = Math.Min( value1.X, value2.X );
         result.Y = Math.Min( value1.Y, value2.Y );
         result.Width = Math.Max( value1.Right, value2.Right ) - result.X;
         result.Height = Math.Max( value1.Bottom, value2.Bottom ) - result.Y;
      }
   }
}