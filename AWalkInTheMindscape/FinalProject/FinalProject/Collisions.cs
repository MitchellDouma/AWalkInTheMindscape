using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/// 
/// <summary>
/// Simple collision management system that returns a bitmask of colliding sides
/// between 2 rectangles or a rectangle and a set of rectangles.
///
/// *** closer to perfect 11/26/2017 :)
/// 
/// Revision History
/// 2.1         refactor to improve debug-ability.  
///                 and found another error!  edge case of left and right now works  (11/26/17)
/// 2.0         while in use, found a bug with TOP collisions (some weird edge condition)
///                 couldn't find the bug.  too complicated.  recreated from scratch using 
///                 the very-Unity-esque hitBoxes on all 4 edges.  and still has bug (10/10/17)
/// 1.1         made properties for both vert and horiz sensitivity
///             added horizontal sensitivity to collison checks
/// 1.0         added into this project, based on v1.0 code, checked-in: 10/8/2017

/// </summary>
namespace PROG2370CollisionLibrary
{
    [Flags]
    public enum Sides
    {
        None = 0,
        TOP = 1,
        BOTTOM = 2,
        LEFT = 4,
        RIGHT = 8
    }

    public static class Collisions
    {
        const int SENSITIVITY = 1;      //this is new!

        public static Sides CheckCollisions(this Rectangle sourceRectangle, List<Rectangle> obstacleRectangles)
        {
            Sides collisions = Sides.None;

            foreach (Rectangle r in obstacleRectangles)
                collisions = collisions | sourceRectangle.CheckCollisions(r);
            return collisions;
        }

        public static Sides CheckCollisions(this Rectangle sourceRectangle, Rectangle obstacleRectangle)
        {
            Sides collisions = Sides.None;

            Rectangle topBoundingBox = sourceRectangle.GetTopBoundingBox();
            if (topBoundingBox.Intersects(obstacleRectangle))
                collisions = collisions | Sides.TOP;

            Rectangle bottomBoundingBox = sourceRectangle.GetBottomBoundingBox();
            if (bottomBoundingBox.Intersects(obstacleRectangle))
                collisions = collisions | Sides.BOTTOM;

            Rectangle leftBoundingBox = sourceRectangle.GetLeftBoundingBox();
            if (leftBoundingBox.Intersects(obstacleRectangle))
                collisions = collisions | Sides.LEFT;

            Rectangle rightBoundingBox = sourceRectangle.GetRightBoundingBox();
            if (rightBoundingBox.Intersects(obstacleRectangle))
                collisions = collisions | Sides.RIGHT;

            return collisions;
        }

        public static Rectangle GetTopBoundingBox(this Rectangle sourceRectangle)
        {
            return new Rectangle(sourceRectangle.X + SENSITIVITY,
                                 sourceRectangle.Y - SENSITIVITY,
                                 sourceRectangle.Width - (2 * SENSITIVITY),
                                 (2 * SENSITIVITY));
        }

        public static Rectangle GetBottomBoundingBox(this Rectangle sourceRectangle)
        {
            return new Rectangle(sourceRectangle.X + SENSITIVITY,
                                 sourceRectangle.Y + sourceRectangle.Height - SENSITIVITY,
                                 sourceRectangle.Width - (2 * SENSITIVITY),
                                 (2 * SENSITIVITY));
        }

        public static Rectangle GetLeftBoundingBox(this Rectangle sourceRectangle)
        {
            return new Rectangle(sourceRectangle.X - SENSITIVITY,
                             sourceRectangle.Y + (2 * SENSITIVITY),
                             (2 * SENSITIVITY),
                             sourceRectangle.Height - (2 * SENSITIVITY));
        }

        public static Rectangle GetRightBoundingBox(this Rectangle sourceRectangle)
        {
            return new Rectangle(sourceRectangle.X + sourceRectangle.Width - SENSITIVITY,
                            sourceRectangle.Y + (2 * SENSITIVITY),
                            (2 * SENSITIVITY),
                            sourceRectangle.Height - (2 * SENSITIVITY));
        }

        /// <summary>
        /// borrowed from XNA platformer kit as described:
        /// https://gamedev.stackexchange.com/questions/45838/get-collision-details-from-rectangle-intersects
        /// Calculates the signed depth of intersection between two rectangles.
        /// </summary>
        /// <returns>
        /// The amount of overlap between two intersecting rectangles. These
        /// depth values can be negative depending on which wides the rectangles
        /// intersect. This allows callers to determine the correct direction
        /// to push objects in order to resolve collisions.
        /// If the rectangles are not intersecting, Vector2.Zero is returned.
        /// </returns>
        public static Vector2 GetIntersectionDepth(this Rectangle rectA, Rectangle rectB)
        {
            // Calculate half sizes.
            float halfWidthA = rectA.Width / 2.0f;
            float halfHeightA = rectA.Height / 2.0f;
            float halfWidthB = rectB.Width / 2.0f;
            float halfHeightB = rectB.Height / 2.0f;

            // Calculate centers.
            Vector2 centerA = new Vector2(rectA.Left + halfWidthA, rectA.Top + halfHeightA);
            Vector2 centerB = new Vector2(rectB.Left + halfWidthB, rectB.Top + halfHeightB);

            // Calculate current and minimum-non-intersecting distances between centers.
            float distanceX = centerA.X - centerB.X;
            float distanceY = centerA.Y - centerB.Y;
            float minDistanceX = halfWidthA + halfWidthB;
            float minDistanceY = halfHeightA + halfHeightB;

            // If we are not intersecting at all, return (0, 0).
            if (Math.Abs(distanceX) >= minDistanceX || Math.Abs(distanceY) >= minDistanceY)
                return Vector2.Zero;

            // Calculate and return intersection depths.
            float depthX = distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
            float depthY = distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
            return new Vector2(depthX, depthY);
        }

        private static bool inRange(int actual, int target, int range)
        {
            bool returnValue = false;

            int lowerbound = target - range;
            int upperbound = target + range;

            if (actual > lowerbound && actual < upperbound)
                returnValue = true;
            return returnValue;
        }
    }
}
