using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.Aop
{
    public class JoinPoint : IEquatable<JoinPoint>
    {
        public MethodBase pointcutMethod;
        public MethodBase concernMethod;

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
            return this.pointcutMethod == other.concernMethod && this.concernMethod == other.concernMethod;
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
            if (other is JoinPoint) return Equals((JoinPoint)other);
            return false;
        }

        public override int GetHashCode()
        {
            return this.pointcutMethod.GetHashCode() ^ this.concernMethod.GetHashCode();
        }

        #endregion
    }
}
