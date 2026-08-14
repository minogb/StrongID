using System.Numerics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Strong.ID {
    public interface IID<T> where T : IComparable {
        T Value { get; }
    }
    public class GenericID<T, J>: IID<J>, IComparable<GenericID<T, J>> where J : IComparable {
        protected J ProtectedValue;
        public J Value =>  ProtectedValue;
        private GenericID() {

        }
        public GenericID(J value) {
            if(value == null) throw new ArgumentNullException("ID must have a non-null value");
            ProtectedValue = value;
        }
        public static explicit operator J(GenericID<T,J> id) {
            return id.Value;
        }
        public static explicit operator GenericID<T, J>(J id) {
            return new GenericID<T,J>(id);
        }
        public override string ToString() {
#pragma warning disable CS8603 // Possible null reference return. Its marked as not null.
            return Value.ToString();
#pragma warning restore CS8603 // Possible null reference return.
        }
        public override bool Equals(object obj) {
            var other = obj as GenericID<T, J>;
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            if (other == null) return false;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8604 // Possible null reference argument.
            return other.Value.Equals(Value);
        }
        public override int GetHashCode() {
            return Value.GetHashCode();
        }
        public int CompareTo(object obj) {
            var other = obj as GenericID<T,J>;
            return this.CompareTo(other);
        }

        public int CompareTo(GenericID<T, J> other) {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            if (other == null) return -1;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8604 // Possible null reference argument.
            return this.Value.CompareTo(other.Value);
        }
        public static bool operator ==(GenericID<T, J> left, GenericID<T, J> right) {
            if (ReferenceEquals(left, null)) {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(GenericID<T, J> left, GenericID<T, J> right) {
            return !(left == right);
        }

        public static bool operator <(GenericID<T, J> left, GenericID<T, J> right) {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(GenericID<T, J> left, GenericID<T, J> right) {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(GenericID<T, J> left, GenericID<T, J> right) {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(GenericID<T, J> left, GenericID<T, J> right) {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
    public class ID<T> : GenericID<T, int> {
        public ID(int value) : base(value) {
        }
    }
    public class BigID<T> : GenericID<T, BigInteger> {
        public BigID(BigInteger value) : base(value) {
        }
    }
    public class LooseID<T> : GenericID<T, string> {
        public LooseID(string value) : base(value) {
        }
    }
}
