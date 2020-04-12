using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MsgPack.Repro
{
    [DataContract]
    public struct ApiResult<T> : IEquatable<ApiResult<T>>
    {
        [DataMember(Order = 0)]
        public bool? IsSuccesful { get; set; }

        [DataMember(Order = 1)]
        public IList<string> ErrorCodes { get; set; }

        [DataMember(Order = 2)]
        public T Result { get; set; }

        public bool HasFailed()
        {
            return !IsSuccesful.HasValue || !IsSuccesful.Value;
        }

        public bool HasSucceeded()
        {
            return IsSuccesful is true;
        }

        public bool Equals(ApiResult<T> other) => other.IsSuccesful == IsSuccesful && other.ErrorCodes == ErrorCodes && ((Result is null && other.Result == null) || Result.Equals(other.Result));
    }
}