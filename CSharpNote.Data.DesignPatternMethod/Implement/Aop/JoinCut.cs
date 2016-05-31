using System;
using System.Reflection;

namespace CSharpNote.Data.DesignPattern.Implement.Aop
{
    public class JoinPoint : IEquatable<JoinPoint>
    {
        public MethodBase concernMethod;
        public MethodBase pointcutMethod;

        private JoinPoint(MethodBase pointcutMethod, MethodBase concernMethod)
        {
            this.pointcutMethod = pointcutMethod;
            this.concernMethod = concernMethod;
        }

        public static JoinPoint Create(MethodBase pointcutMethod, MethodBase concernMethod)
        {
            return new JoinPoint(pointcutMethod, concernMethod);
        }

        #region Equatable

        public bool Equals(JoinPoint other)
        {
            return pointcutMethod == other.concernMethod && concernMethod == other.concernMethod;
        }

        public static bool operator ==(JoinPoint x, JoinPoint y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(JoinPoint x, JoinPoint y)
        {
            return !(x == y);
        }

        public override bool Equals(object other)
        {
            if (other is JoinPoint) return Equals((JoinPoint) other);
            return false;
        }

        public override int GetHashCode()
        {
            return pointcutMethod.GetHashCode() ^ concernMethod.GetHashCode();
        }

        #endregion
    }
}